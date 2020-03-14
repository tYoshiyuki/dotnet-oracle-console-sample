using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using DotNetOracleConsoleSample.Models;

namespace DotNetOracleConsoleSample
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //var order = new Order
            //{
            //    OrderId = 1,
            //    OrderDetailId = 1,
            //    OrderName = "Sample001"
            //};

            //var orderList = new List<Order> { order, order, order };
            //var dic = orderList.ToDictionary(_ => _).ToList();

            var db = new OracleDbContext();
            var time = db.Database.SqlQuery<DateTime>("SELECT SYSDATE FROM DUAL").FirstOrDefault();

            var type = Assembly.GetExecutingAssembly()
                .GetTypes().FirstOrDefault(t => t.Name == "Blog");
            var obj = await db.Set(type).ToListAsync();

            var db2 = new OracleDbContextSub();
            db2.Database.ExecuteSqlCommand("TRUNCATE TABLE SAMPLE2.\"Blogs\"");
            db2.BulkInsert(obj);
        }
    }
}
