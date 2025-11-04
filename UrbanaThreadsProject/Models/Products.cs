using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanaThreadsProject.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string? Description { get; set; } = string.Empty;

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Column("sku")]
        public string? SKU { get; set; } = string.Empty;

        [Column("image_url")]
        public string? ImageUrl { get; set; } = string.Empty;

        [Column("status")]
        public string Status { get; set; } = "In Stock";

        [Column("category_id")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        // ✅ Optional Inventory (avoid null crash)
        public Inventory? Inventory { get; set; }
    }
}
