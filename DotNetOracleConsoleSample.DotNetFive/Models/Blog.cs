using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetOracleConsoleSample.DotNetFive.Models
{
    [Table("BLOG")]
    public class Blog
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }
    }
}
