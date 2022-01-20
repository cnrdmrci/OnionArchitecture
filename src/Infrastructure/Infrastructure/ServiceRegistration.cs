using Application.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureRegistration(this IServiceCollection services)
    {
        services.AddTransient<IDateTime, DateTimeService>();
    }
}