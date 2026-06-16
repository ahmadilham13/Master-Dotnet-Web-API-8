using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Api.Enums;

[DefaultValue(null)]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AuditLogAction
{
    Create,
    Update,
    Delete,
    Rollback
}