using Domain.Common;

namespace Domain.Entities;

public class Person : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
}