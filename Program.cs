using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetOracleConsoleSample.Models;

namespace DotNetOracleConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new OracleDbContext();
            var blogs = db.Blogs.ToList();

        }
    }
}
