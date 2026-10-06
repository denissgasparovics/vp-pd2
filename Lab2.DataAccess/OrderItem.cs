using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.DataAccess
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string ProductName {  get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        [Range(typeof(decimal), "0.01", "100000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;
    }
}
