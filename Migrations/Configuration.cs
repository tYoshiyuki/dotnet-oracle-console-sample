using DotNetOracleConsoleSample.Models;

namespace DotNetOracleConsoleSample.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DotNetOracleConsoleSample.Models.OracleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DotNetOracleConsoleSample.Models.OracleDbContext context)
        {
            context.Blogs.Add(new Blog { Id = 1, Name = "Sample001" });
            context.Blogs.Add(new Blog { Id = 2, Name = "Sample002" });
            context.Blogs.Add(new Blog { Id = 3, Name = "Sample003" });
        }
    }
}
