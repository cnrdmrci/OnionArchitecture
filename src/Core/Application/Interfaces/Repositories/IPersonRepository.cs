using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IPersonRepository
{
    Task<Person> GetByIdAsync(int id);
    Task AddAsync(Person person);
}