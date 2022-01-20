using Domain.Entities;
using Mapster;

namespace Application.Dto;

public class PersonDto : IRegister
{
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Person, PersonDto>();
    }
}