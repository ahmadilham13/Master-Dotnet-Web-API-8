using Microsoft.EntityFrameworkCore;
using Api.Entities;
using Api.Enums;
using Api.Helpers;

namespace Api.Accounts.Seeders;

public class AccountSeeder(
    ModelBuilder modelBuilder
    )
{
    private readonly ModelBuilder _modelBuilder = modelBuilder;

    public void Seed()
    {
        _modelBuilder.Entity<Account>().HasData(
            new Account { Id = new Guid("8f8884ac-e5ff-4ab2-92f6-5c328d2f6e97"), Username = "superadmin", FullName = "Super Admin", Email = "superadmin@admin.com", PasswordHash = "$2a$11$f5E2RfGFfjSUi8IaMZcQzOEtsNYBDl2077tPMztZU.j0eeiRJDoQO", RoleId = SiteHelper.SuperAdminRoleId, Verified = DateTime.Parse("2024-08-21 10:12:34"), Created = DateTime.Parse("2024-08-21 10:12:34") },
            new Account { Id = new Guid("dc323466-0729-4f4c-82c4-43560ae1113c"), Username = "admin", FullName = "Admin", Email = "admin@admin.com", PasswordHash = "$2a$11$g0hpbIHewxnYhIz85wSV9.lg1mUOOJlclLEs5ixBIeAk6ZZEinrjy", RoleId = new Guid("0c4db327-d216-43ab-b7de-3898e8f72add"), Verified = DateTime.Parse("2024-08-21 10:12:34"), Created = DateTime.Parse("2024-08-21 10:12:34") }
        );

        _modelBuilder.Entity<Account>()
            .HasIndex(x => x.RoleId)
            .IsUnique(false);

        _modelBuilder.Entity<Account>()
            .Property( x => x.Status )
            .HasDefaultValue(AccountStatus.Active);
    }
}