using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Api.Enums;

[Flags]
public enum PermissionMethod
{
    None = 0,
    View = 1 << 0,  // 1
    Create = 1 << 1, // 2
    Update = 1 << 2, // 4
    Delete = 1 << 3, // 8
    FullAccess = View | Create | Update | Delete, // Combination of all
}