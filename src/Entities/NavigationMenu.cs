using System.ComponentModel.DataAnnotations.Schema;
using Coc.Enums;

namespace Coc.Entities;

public class NavigationMenu : BaseEntity
{
    [Column(TypeName = "varchar(64)")]
    public string Name { get; set; }
    [Column(TypeName = "varchar(64)")]
    public string ControllerName { get; set; }
    public int Order { get; set; }
    public Guid? GroupId { get; set; }
    [ForeignKey("GroupId")]
    public NavigationMenuGroup Group { get; set; }
    public PermissionMethod PermissionMethod { get; set; }
}