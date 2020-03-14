using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetOracleConsoleSample.Models
{
    public class OracleDbContextSub : DbContext
    {
        public OracleDbContextSub() : base("OracleDbContextSub")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SAMPLE2");
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
