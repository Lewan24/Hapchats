using System.ComponentModel.DataAnnotations;
using System.Security;
using HapChats.Domain.Persistence.Common;

namespace HapChats.Domain.Persistence.Entities;

public record User : Auditable
{
    [Required]
    [StringLength(40)]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(50)]
    public SecureString Password { get; set; }

    public Guid UserProfileId { get; set; }
}
