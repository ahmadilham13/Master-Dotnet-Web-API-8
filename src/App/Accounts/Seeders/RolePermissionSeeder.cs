using Microsoft.EntityFrameworkCore;
using Api.Entities;
using Api.Enums;

namespace Api.Accounts.Seeders;

public class RolePermissionSeeder(
    ModelBuilder modelBuilder
    )
{
    private readonly ModelBuilder _modelBuilder = modelBuilder;

    public void Seed()
    {
        var roleId = new Guid("0c4db327-d216-43ab-b7de-3898e8f72add");
        
        _modelBuilder.Entity<RolePermission>().HasData(
            new RolePermission { Id = new Guid("c8fd6452-6930-41d0-a13e-e1fd09914261"), RoleId = roleId, NavigationMenuId = new Guid("f5c9220d-8997-4607-b34b-7c5a63c97b84"), PermissionMethod = PermissionMethod.FullAccess },
            new RolePermission { Id = new Guid("dec0458d-8964-4bc1-87da-7b8e5b4c58ba"), RoleId = roleId, NavigationMenuId = new Guid("cdf366d8-2936-45a3-b740-7441815161be"), PermissionMethod = PermissionMethod.FullAccess },
            new RolePermission { Id = new Guid("81a067f3-4e2f-42b0-b5eb-79e79f0f6a7a"), RoleId = roleId, NavigationMenuId = new Guid("bc4f03bb-7bf2-492d-b0d8-2d688f2617c7"), PermissionMethod = PermissionMethod.FullAccess },
            new RolePermission { Id = new Guid("a0e0490b-3523-4b07-9bb9-3ca7276d9378"), RoleId = roleId, NavigationMenuId = new Guid("cb9a248e-585b-4055-bd25-67e5fe49bfcf"), PermissionMethod = PermissionMethod.FullAccess }
        );
    }
}