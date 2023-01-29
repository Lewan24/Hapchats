using Microsoft.AspNetCore.Mvc;
using MediatR;
using Api.Functions.Account.Commands;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        var result = await _mediator.Send(new DeleteAccountQuery());

        return result is true ? Ok("Successfully deleted account,") : Ok("Unfortunately cant delete account. Try again later.");
    }
}
