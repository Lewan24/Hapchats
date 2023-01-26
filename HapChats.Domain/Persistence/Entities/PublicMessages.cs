using HapChats.Domain.Persistence.Common;
using System.ComponentModel.DataAnnotations;

namespace HapChats.Domain.Persistence.Entities;

public record PublicMessages : Auditable
{
    [Required]
    [StringLength(255)]
    public string Msg { get; set; }

    [Required]
    public Guid UserId { get; set; }
}
