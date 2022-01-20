using Application.Common.Model;
using Application.Interfaces.Repositories;
using MapsterMapper;
using MediatR;

namespace Application.Features.Person.Commands.Create;

public class CreatePersonCommandHandler  : IRequestHandler<CreatePersonCommand, ServiceResult>
{
    private readonly IPersonRepository _personRepository;
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper, IApplicationDbContext context)
    {
        _personRepository = personRepository;
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<ServiceResult> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Domain.Entities.Person>(request);
        await _personRepository.AddAsync(person);
        await _context.SaveChangesAsync();

        return ServiceResult.Success(new CreatePersonCommandViewModel{PersonId = person.Id});
    }
}