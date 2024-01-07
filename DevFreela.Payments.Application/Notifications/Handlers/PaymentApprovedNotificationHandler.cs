using System.Text;
using System.Text.Json;

using Microsoft.Extensions.Configuration;

using MediatR;

using DevFreela.Payments.Domain.Interfaces;

namespace DevFreela.Payments.Application.Notifications.Handlers;

public class PaymentApprovedNotificationHandler : INotificationHandler<PaymentApprovedNotification>
{
    private readonly IMessageBusService _messageBusService;
    private readonly string _queue;

    public PaymentApprovedNotificationHandler(IMessageBusService messageBusService, IConfiguration configuration)
    {
        _messageBusService = messageBusService;
        _queue = configuration.GetSection("Services:RabbitMq:PaymentApprovedQueue").Value;

        if (string.IsNullOrWhiteSpace(_queue))
            throw new ArgumentNullException($"The queue name of {nameof(_queue)} cannot be null or empty");
    }

    public Task Handle(PaymentApprovedNotification notification, CancellationToken cancellationToken)
    {
        var projectIdJson = JsonSerializer.Serialize(notification);
        var projectIdBytes = Encoding.UTF8.GetBytes(projectIdJson);

        _messageBusService.Publish(_queue, projectIdBytes);

        return Task.CompletedTask;
    }
}