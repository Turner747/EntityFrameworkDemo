using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkDemo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Column(TypeName = "REAL(6,2)")]
        public decimal Price { get; set; }
    }
}
