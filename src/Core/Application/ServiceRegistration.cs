using System.Reflection;
using Application.Common.Behaviours;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceRegistration
{
    public static void AddApplicationRegistration(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();

        services.AddSingleton(GetConfiguredMappingConfig());
        services.AddScoped<IMapper, ServiceMapper>();
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(assm);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
    }
    
    private static TypeAdapterConfig GetConfiguredMappingConfig()
    {
        var config = TypeAdapterConfig.GlobalSettings;

        IList<IRegister> registers = config.Scan(Assembly.GetExecutingAssembly());

        config.Apply(registers);

        return config;
    }
}