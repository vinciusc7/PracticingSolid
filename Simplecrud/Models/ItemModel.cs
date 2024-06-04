using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Simplecrud.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Price { get; set; }
    }
}
