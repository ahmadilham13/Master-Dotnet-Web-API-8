using Microsoft.EntityFrameworkCore;
using Coc.Entities;

namespace Coc.Accounts.Seeders;

public class NavigationMenuGroupSeeder(
    ModelBuilder modelBuilder
    )
{
    private readonly ModelBuilder _modelBuilder = modelBuilder;

    public void Seed()
    {
        _modelBuilder.Entity<NavigationMenuGroup>().HasData(
            new NavigationMenuGroup { Id = new Guid("4adece20-8676-4937-8479-2c6ca6c9ec7a"), Name = "Account" },
            new NavigationMenuGroup { Id = new Guid("ef93b0ac-aea0-4080-bd4e-89e4052fea12"), Name = "Setting" }
        );
    }
}