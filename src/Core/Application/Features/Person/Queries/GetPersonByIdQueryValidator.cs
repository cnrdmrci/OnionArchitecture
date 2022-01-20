using FluentValidation;

namespace Application.Features.Person.Queries;

public class GetPersonByIdQueryValidator : AbstractValidator<GetPersonByIdQuery>
{
    public GetPersonByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(0).WithMessage("Id can not be zero")
            .GreaterThanOrEqualTo(1).WithMessage("Id must be greather than zero");
    }
}