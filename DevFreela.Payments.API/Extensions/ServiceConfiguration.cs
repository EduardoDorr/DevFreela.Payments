using System.Text.Json.Serialization;

using Microsoft.OpenApi.Models;

using DevFreela.Payments.Application;
using DevFreela.Payments.Infrastructure;

namespace DevFreela.Payments.API.Extensions;

public static class ServiceConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddApplication()
                .AddInfrastructure();

        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        });

        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "DevFreela.Payments.API",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Eduardo Dörr",
                    Email = "edudorr@hotmail.com",
                    Url = new Uri("https://github.com/EduardoDorr")
                }
            });
        });

        services.AddEndpointsApiExplorer();

        return services;
    }
}