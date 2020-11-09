using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetOracleConsoleSample.Models
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext() : base("OracleDbContext")
        {
            this.Database.Log = Console.WriteLine;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SAMPLE");
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
