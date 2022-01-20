namespace Application.Interfaces.Repositories;

public interface IApplicationDbContext
{
    Task<int> SaveChangesAsync();
}