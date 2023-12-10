using System.Data;
using System.Diagnostics;
using DotNetOracleConsoleSample.DotNet.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetOracleConsoleSample.DotNet.Test
{
    /// <summary>
    /// <see cref="OracleBulkInsertHelper"/> のテストクラスです。
    /// </summary>
    [TestClass]
    public class OracleBulkInsertHelperTest
    {
        [TestMethod]
        public void OracleBulkInsert_正常系()
        {
            // Prepare
            var db = new OracleDbContext("User Id=sample;Password=samplepw;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)))");

            var dt = new DataTable();
            dt.TableName = "BLOG";
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("NAME", typeof(string));
            dt.Columns.Add("UPDATED", typeof(DateTime));

            for (var i = 0; i < 10000; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = i;
                dr["NAME"] = "Hello " + i;
                dr["UPDATED"] = DateTime.Now;
                dt.Rows.Add(dr);
            }

            // Execute 1 Loop Insert
            // --------------------------------------------------------------------------------
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE BLOG");
            var sw = new Stopwatch();
            sw.Start();

            foreach (DataRow row in dt.Rows)
            {
                db.Database.ExecuteSqlRaw($"INSERT INTO BLOG (ID, NAME, UPDATED) VALUES ({row["ID"]}, '{row["NAME"]}', TO_DATE('{row["UPDATED"]:yyyy/MM/dd HH:mm:ss}', 'YYYY/MM/DD HH24:MI:SS'))");
            }

            Console.WriteLine($"Loop Insert: {sw.ElapsedMilliseconds:N} ms");

            // Execute 2 Bulk Insert
            // --------------------------------------------------------------------------------
            db.Database.ExecuteSqlRaw("TRUNCATE TABLE BLOG");
            sw.Restart();

            OracleBulkInsertHelper.OracleBulkInsert(dt, db);

            Console.WriteLine($"Bulk Insert: {sw.ElapsedMilliseconds:N} ms");
        }
    }
}