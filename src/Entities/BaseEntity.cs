using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities;

public class BaseEntity : IBaseEntity, ISoftDelete
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public DateTime? DeletedAt { get; set; }
    [NotMapped]
    bool ISoftDelete.ForceDeleted { get; set; }
}