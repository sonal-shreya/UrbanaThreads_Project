using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanaThreadsProject.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key]
        [Column("inventory_id")]
        public int InventoryId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Column("stock_quantity")]
        public int StockQuantity { get; set; } = 0;

        [Column("reorder_level")]
        public int ReorderLevel { get; set; } = 10;

        [Column("last_restocked")]  
        public DateTime? LastRestocked { get; set; }
    }
}
