using Application.Features.Person.Commands.Create;
using Application.Features.Person.Queries;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Common;

namespace WebApi.Controllers.v1;

[ApiVersion("1.0")]
public class PersonController : BaseApiController
{
    [HttpGet, Route("{id}")]
    public async Task<IActionResult> GetPerson(int id)
    {
        var query = new GetPersonByIdQuery { Id = id };
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson(CreatePersonCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}