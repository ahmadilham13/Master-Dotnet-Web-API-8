using System.ComponentModel.DataAnnotations.Schema;
using Api.Enums;

namespace Api.Entities;

public class AuditLog : BaseEntity
{
    #nullable enable
    public Guid? AccountId { get; set; }
    public Account? Account { get; set; }
    public string? From { get; set; }
    public string? To { get; set; }
    #nullable disable
    [Column(TypeName = "varchar(15)")]
    public AuditLogAction Action { get; set; }
    public string Entity { get; set; }
    public string Service { get; set; }
    public string Method { get; set; }
    public Guid EntityId { get; set; }
    public string CreatedByIp { get; set; }
}