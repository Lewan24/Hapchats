using HapChats.Domain.Persistence.Common;
using System.ComponentModel.DataAnnotations;

namespace HapChats.Domain.Persistence.Entities;

public record UserProfile : Auditable
{
    [Required]
    public Guid UserId { get; set; }
    public string ProfileImageUri { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";

    [Required]
    [Range(13, 99)]
    public short Age { get; set; }
}
