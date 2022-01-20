using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceRegistration(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("inMemoryDb"));
        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        services.AddTransient<IPersonRepository, PersonRepository>();
    }
}