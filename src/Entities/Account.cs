using System.ComponentModel.DataAnnotations.Schema;
using Coc.Enums;
using Coc.Helpers;

namespace Coc.Entities;

public class Account : BaseEntity
{
    [Column(TypeName = "varchar(150)")]
    public string Username { get; set; }
    [Column(TypeName = "varchar(150)")]
    public string NIP { get; set; }
    public string FullName { get; set; }
    public AccountStatus Status { get; set; }
    #nullable enable
    [Column(TypeName = "varchar(150)")]
    public string? Email { get; set; }
    [Column(TypeName = "varchar(150)")]
    public string? PasswordHash { get; set; }
    [Column(TypeName = "varchar(80)")]
    public string? VerificationToken { get; set; }
    public DateTime? Verified { get; set; }
    public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
    public bool SendEmailNotification { get; set; }
    public bool HandleAllDivision { get; set; }
    #nullable disable
    public Guid RoleId { get; set; }
    public Role Role { get; set; }
    public Guid? AvatarId { get; set; }
    [ForeignKey("AvatarId")]
    public Media Avatar { get; set; }
    [Column(TypeName = "varchar(80)")]
    public string ResetToken { get; set; }
    public DateTime? ResetTokenExpires { get; set; }
    public DateTime? PasswordReset { get; set; }
    public DateTime? LockedUntil { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; }

    public bool OwnsToken(string token)
    {
        return RefreshTokens?.Find(x => x.Token == token) != null;
    }

    // Method to check if the current account is a Super Admin
    public bool IsSuperAdmin()
    {
        return this.RoleId == SiteHelper.SuperAdminRoleId;
    }
}