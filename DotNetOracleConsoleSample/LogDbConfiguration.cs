using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetOracleConsoleSample
{
    class LogDbConfiguration : DbConfiguration
    {
        public LogDbConfiguration()
        {
            // SetDatabaseLogFormatter((context, writeAction) => new LogFormatter(context, writeAction));
        }
    }
}
