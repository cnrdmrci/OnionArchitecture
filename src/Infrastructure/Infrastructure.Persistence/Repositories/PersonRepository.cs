using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PersonRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Person> GetByIdAsync(int id)
    {
        return await _dbContext.Persons.FindAsync(id);
    }

    public async Task AddAsync(Person person)
    {
        await _dbContext.Persons.AddAsync(person);
    }
}