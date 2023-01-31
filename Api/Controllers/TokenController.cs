using Api.Functions.Token.Queries;
using HapChats.Domain.Persistence.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private IMediator _mediator;

    public TokenController(IMediator med) {
        _mediator = med;
    }

    [HttpPost]
    public async Task<IActionResult> GetToken([FromBody] UserDto credentials) 
    {
        var request = new GetValidToken()
        {
            Username = credentials.Username,
            Password = credentials.Password
        };

        var token = _mediator.Send(request).Result;

        if (token.Item2 == false)
            return BadRequest(token.Item1);

        return Ok(token.Item1);
    }
}
