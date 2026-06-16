using Microsoft.EntityFrameworkCore;
using Api.Entities;
using Api.Enums;

namespace Api.Accounts.Seeders;

public class NavigationMenuSeeder(
    ModelBuilder modelBuilder
    )
{
    private readonly ModelBuilder _modelBuilder = modelBuilder;

    public void Seed()
    {
        _modelBuilder.Entity<NavigationMenu>().HasData(
            new NavigationMenu { Id = new Guid("f5c9220d-8997-4607-b34b-7c5a63c97b84"), Name = "Management User", ControllerName = "dashboard-user", Order = 1, GroupId = new Guid("4adece20-8676-4937-8479-2c6ca6c9ec7a"), PermissionMethod = PermissionMethod.FullAccess },
            new NavigationMenu { Id = new Guid("cdf366d8-2936-45a3-b740-7441815161be"), Name = "Management Role", ControllerName = "dashboard-role", Order = 2, GroupId = new Guid("4adece20-8676-4937-8479-2c6ca6c9ec7a"), PermissionMethod = PermissionMethod.FullAccess },
            new NavigationMenu { Id = new Guid("bc4f03bb-7bf2-492d-b0d8-2d688f2617c7"), Name = "Audit Log", ControllerName = "audit-log", Order = 3, PermissionMethod = PermissionMethod.FullAccess },
            new NavigationMenu { Id = new Guid("cb9a248e-585b-4055-bd25-67e5fe49bfcf"), Name = "Site Config", ControllerName = "site-config", Order = 4, GroupId = new Guid("ef93b0ac-aea0-4080-bd4e-89e4052fea12"), PermissionMethod = PermissionMethod.FullAccess }
        );
    }
}