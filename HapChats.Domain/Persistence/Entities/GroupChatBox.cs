using HapChats.Domain.Persistence.Common;
using System.ComponentModel.DataAnnotations;

namespace HapChats.Domain.Persistence.Entities;

public record GroupChatBox : Auditable
{
    [Required]
    public List<Guid> UsersInChatIds { get; set; }
}
