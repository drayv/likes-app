using System.Data.Entity.Migrations;

namespace LikesApp.EntityFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LikesApp.EntityFramework.LikesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LikesDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
