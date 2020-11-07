using System.Collections.Generic;
using System.Linq;
using DotNetOracleConsoleSample.Core.Extensions;
using DotNetOracleConsoleSample.Core.Models;

namespace DotNetOracleConsoleSample.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO 設定化する
            var db = new OracleDbContext("User Id=sample;Password=samplepw;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)))");
            // var blog = db.Blogs.ToList();
            var blog = db.SqlQuery<Blog>("SELECT * FROM SAMPLE.\"Blogs\"").ToList();
        }
    }
}
