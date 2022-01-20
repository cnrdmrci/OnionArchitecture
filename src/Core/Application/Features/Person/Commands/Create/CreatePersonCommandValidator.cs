using FluentValidation;

namespace Application.Features.Person.Commands.Create;

public class CreatePersonCommandValidator  : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .Configure(rule => rule.MessageBuilder = _ => "Name can not be empty.");
        
        RuleFor(x => x.Surname)
            .NotEmpty()
            .NotNull()
            .Configure(rule => rule.MessageBuilder = _ => "Surname can not be empty.");
    }
}