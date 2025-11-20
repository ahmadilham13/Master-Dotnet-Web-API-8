using Coc.Enums;

namespace Coc.Entities;

public class RolePermission : BaseEntity
{
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    public Guid NavigationMenuId { get; set; }
    public NavigationMenu NavigationMenu { get; set; }
    public PermissionMethod PermissionMethod { get; set; }
}