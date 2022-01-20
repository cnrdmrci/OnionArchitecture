using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Persistence.Context;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IDateTime _dateTime;

    public ApplicationDbContext(DbContextOptions options, IDateTime dateTime): base(options)
    {
        _dateTime = dateTime;
    }
    
    public DbSet<Person> Persons { get; set; }
    
    public async Task<int> SaveChangesAsync()
    {
        foreach (EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = _dateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedDate = _dateTime.Now;
                    break;
            }
        }
        return await base.SaveChangesAsync();
    }
}