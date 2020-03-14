using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetOracleConsoleSample.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Key]
        public int OrderDetailId { get; set; }

        public string OrderName { get; set; }
    }
}
