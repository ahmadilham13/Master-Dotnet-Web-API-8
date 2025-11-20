using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Coc.Enums;

[DefaultValue(null)]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AuditLogAction
{
    Create,
    Update,
    Delete,
    Rollback
}