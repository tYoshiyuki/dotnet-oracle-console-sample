using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetOracleConsoleSample.Core.Models
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
