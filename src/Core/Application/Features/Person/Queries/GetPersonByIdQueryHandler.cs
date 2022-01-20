using Application.Common.Model;
using Application.Dto;
using Application.Interfaces.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.Features.Person.Queries;

public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, ServiceResult>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public GetPersonByIdQueryHandler(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResult> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var person = await _personRepository.GetByIdAsync(request.Id);
        var dto = _mapper.Map<PersonDto>(person);
        var personVm = new GetPersonByIdViewModel { PersonDto = dto };

        return ServiceResult.Success(personVm);
    }
}