using Api.Accounts.Seeders;
using Api.Configs;
using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Api.Helpers;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
    public DbSet<Media> Medias { get; set; }
    public DbSet<NavigationMenu> NavigationMenus { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<NavigationMenuGroup> NavigationMenuGroups { get; set; }
    public DbSet<SiteConfig> SiteConfigs { get; set; }

    private AppSettings _appSettings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (_appSettings != null)
        {
            // Use logger when db logging is enabled
            if (_appSettings.EnableDBLogging)
            {
                options.EnableSensitiveDataLogging();
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            }
        }

        options.AddInterceptors(new AutofillDateTimeInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Accounts Module Seeder Start
        new RoleSeeder(modelBuilder).Seed();
        new AccountSeeder(modelBuilder).Seed();
        new NavigationMenuGroupSeeder(modelBuilder).Seed();
        new NavigationMenuSeeder(modelBuilder).Seed();
        new RolePermissionSeeder(modelBuilder).Seed();
        // Accounts Module Seeder End

        modelBuilder.Entity<Media>()
            .HasIndex(x => x.AuthorId)
            .IsUnique(false);

        modelBuilder.ApplyGlobalFilters<ISoftDelete>(x => x.DeletedAt == null);
    }
}
