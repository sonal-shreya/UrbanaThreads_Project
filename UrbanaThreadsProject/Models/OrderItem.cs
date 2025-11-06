using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanaThreadsProject.Models
{
    [Table("OrderItem")] 
    public class OrderItem
    {
        [Key]
        [Column("order_item_id")] 
        public int OrderItemId { get; set; }

        [Column("order_id")] 
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [Column("product_id")] 
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Column("quantity")] 
        public int Quantity { get; set; } = 1;

        [Column("unit_price")] 
        public decimal UnitPrice { get; set; }
    }
}
