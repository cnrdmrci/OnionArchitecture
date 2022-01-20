using Application.Common.Model;
using MediatR;

namespace Application.Features.Person.Queries;

public class GetPersonByIdQuery : IRequest<ServiceResult>
{
    public int Id { get; set; }
}