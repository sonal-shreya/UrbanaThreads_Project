using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanaThreadsProject.Models
{
    [Table("Category")] 
    public class Category
    {
        [Key]
        [Column("category_id")] 
        public int CategoryId { get; set; }

        [Required]
        [Column("name")] 
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
