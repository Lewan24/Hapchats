using HapChats.Domain.Persistence.Dtos;
using MediatR;

namespace Api.Functions.Token.Queries;

/// <summary>
/// Request returns a tuple that contains valid token as string and a bool that means is request ok - true, or bad - false
/// </summary>
public class GetValidToken : UserDto, IRequest<(string, bool)>{}

public class GetValidTokenHandler : IRequestHandler<GetValidToken, (string, bool)>
{
	public Task<(string, bool)> Handle(GetValidToken request, CancellationToken cancellationToken)
	{
		if (string.IsNullOrWhiteSpace(request.Password) || string.IsNullOrWhiteSpace(request.Username))
			return Task.FromResult(("Invalid Token", false));

		return Task.FromResult(("Valid Token", true));
	}
}