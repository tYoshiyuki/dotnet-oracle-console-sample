using Microsoft.EntityFrameworkCore;

namespace DotNetOracleConsoleSample.Core.Models
{
    class OracleDbContext : DbContext
    {
        private readonly string _connectionString;

        public OracleDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(_connectionString);
        }

        public DbSet<Blog> Blogs { get; set; }

    }
}
