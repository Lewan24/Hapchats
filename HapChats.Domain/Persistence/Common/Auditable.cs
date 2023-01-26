using System.ComponentModel.DataAnnotations;

namespace HapChats.Domain.Persistence.Common;

public record Auditable
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CreatedBy { get; set; } = "";
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public string ModifiedBy { get; set; } = "";
    public DateTime ModifiedTime { get; set; } = DateTime.UtcNow;
    public bool IsInActive { get; set; } = false;
    public DateTime? DisactivateTime { get; set; }
}
