using Microsoft.AspNetCore.Identity;

namespace HapChats.Domain.Persistence.Entities;

public class NewIdentityUser : IdentityUser
{
    public Guid ProfileId { get; set; }
}
