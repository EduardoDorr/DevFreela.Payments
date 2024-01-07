using System.Text;
using System.Text.Json;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MediatR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using DevFreela.Payments.Application.Commands;

namespace DevFreela.Payments.Infrastructure.Consumers;

public class ProcessPaymentConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    private readonly string _queue;

    public ProcessPaymentConsumer(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;

        var connectionFactory = new ConnectionFactory
        {
            HostName = configuration.GetSection("Services:RabbitMq:HostName").Value,
            UserName = configuration.GetSection("Services:RabbitMq:UserName").Value,
            Password = configuration.GetSection("Services:RabbitMq:Password").Value
        };

        _queue = configuration.GetSection("Services:RabbitMq:Queue").Value;

        _connection = connectionFactory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare
            (
                queue: _queue,
                durable: false,
                exclusive: false,
                autoDelete: true,
                arguments: null
            );
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var bytes = eventArgs.Body.ToArray();
            var paymentInfoJson = Encoding.UTF8.GetString(bytes);
            var paymentInfo = JsonSerializer.Deserialize<CreatePaymentCommand>(paymentInfoJson);

            await ProcessPayment(paymentInfo);

            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };

        _channel.BasicConsume
            (
                queue: _queue,
                autoAck: false,
                consumer: consumer
            );

        return Task.CompletedTask;
    }

    private async Task ProcessPayment(CreatePaymentCommand paymentInfo)
    {
        using (var scope = _serviceProvider.CreateAsyncScope())
        {
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            await mediator.Send(paymentInfo);
        }
    }
}