using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LikesApp.Core.Entities;
using LikesApp.EntityFramework.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LikesApp.EntityFramework
{
    public class LikesDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public DbSet<PageLike> PageLikes { get; set; }

        public LikesDbContext() : base("name=LikesDbConnection")
        {
            Database.CreateIfNotExists();
        }

        public static LikesDbContext Create()
        {
            return new LikesDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<PageLike>().HasKey(l => l.Id);

            modelBuilder.Entity<ApplicationUser>().HasKey(u => u.Id);
            modelBuilder.Entity<ApplicationRole>().HasKey(r => r.Id);

            modelBuilder.Entity<ApplicationUserRole>()
                .HasKey(r => new { r.UserId, r.RoleId })
                .ToTable("AspNetUserRoles");

            modelBuilder.Entity<ApplicationUserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("AspNetUserLogins");
        }
    }
}
