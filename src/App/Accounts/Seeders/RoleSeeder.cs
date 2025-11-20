using Microsoft.EntityFrameworkCore;
using Coc.Entities;
using Coc.Helpers;

namespace Coc.Accounts.Seeders;

public class RoleSeeder(
    ModelBuilder modelBuilder
    )
{
    private readonly ModelBuilder _modelBuilder = modelBuilder;

    public void Seed()
    {
        _modelBuilder.Entity<Role>().HasData(
            new Role { Id = SiteHelper.SuperAdminRoleId, RoleName = "Super Admin", NeedApproval = false },
            new Role { Id = new Guid("0c4db327-d216-43ab-b7de-3898e8f72add"), RoleName = "Admin", NeedApproval = false }
        );
    }
}