using System.ComponentModel.DataAnnotations.Schema;

namespace Coc.Entities;

public class Role : BaseEntity
{
    [Column(TypeName = "varchar(64)")]
    public string RoleName { get; set; }
    public string Description { get; set; }
    public bool NeedApproval { get; set; }
    public bool OnlyShowDivisionConsultation { get; set; }
    public bool OnlyShowPerangkatDaerahConsultation { get; set; }
    public bool OnlyShowOwnConsultation { get; set; }
    public List<RolePermission> RolePermission { get; set; }
}