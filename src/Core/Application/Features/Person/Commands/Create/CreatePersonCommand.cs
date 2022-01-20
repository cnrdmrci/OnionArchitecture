using Application.Common.Model;
using MediatR;

namespace Application.Features.Person.Commands.Create;

public class CreatePersonCommand : IRequest<ServiceResult>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
}