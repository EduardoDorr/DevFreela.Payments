using Microsoft.Extensions.DependencyInjection;

using DevFreela.Payments.Domain.Interfaces;
using DevFreela.Payments.Infrastructure.Consumers;
using DevFreela.Payments.Infrastructure.MessageBus;

namespace DevFreela.Payments.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddServices();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IMessageBusService, MessageBusService>();
        services.AddHostedService<ProcessPaymentConsumer>();

        return services;
    }
}