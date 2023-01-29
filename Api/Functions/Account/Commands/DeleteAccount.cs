using MediatR;

namespace Api.Functions.Account.Commands;

public class DeleteAccountQuery : IRequest<bool>
{
}

public class DeleteAccountHandler : IRequestHandler<DeleteAccountQuery, bool>
{
    Task<bool> IRequestHandler<DeleteAccountQuery, bool>.Handle(DeleteAccountQuery request, CancellationToken cancellationToken)
    {
        // TODO: Implement delete function
        return Task.FromResult(false);
    }
}
