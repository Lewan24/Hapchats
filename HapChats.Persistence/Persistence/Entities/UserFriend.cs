using System.ComponentModel.DataAnnotations;
using HapChats.Domain.Persistence.Common;

namespace HapChats.Domain.Persistence.Entities;

public record UserFriend : Auditable
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    public Guid FriendId { get; set; }
}
