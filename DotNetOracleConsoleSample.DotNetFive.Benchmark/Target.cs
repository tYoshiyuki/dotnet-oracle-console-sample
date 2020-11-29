using System.Linq;
using BenchmarkDotNet.Attributes;
using DotNetOracleConsoleSample.DotNetFive.Extensions;
using DotNetOracleConsoleSample.DotNetFive.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetOracleConsoleSample.DotNetFive.Benchmark
{
    public class Target
    {
        private readonly int loopCnt = 1000;

        [Benchmark]
        public void SqlQuery()
        {
            var db = new OracleDbContext("User Id=sample;Password=samplepw;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)))");

            var i = 0;
            while (true)
            {
                var result = db.SqlQuery<Blog>("SELECT * FROM SAMPLE.\"Blogs\"").ToList();
                i++;
                if (i > loopCnt) break;
            }
        }

        [Benchmark]
        public void FromSqlRaw()
        {
            var db = new OracleDbContext("User Id=sample;Password=samplepw;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)))");

            var i = 0;
            while (true)
            {
                var result = db.Blogs.FromSqlRaw("SELECT * FROM SAMPLE.\"Blogs\"").ToList();
                i++;
                if (i > loopCnt) break;
            }
        }
    }
}
