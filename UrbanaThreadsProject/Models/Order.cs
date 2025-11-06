using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrbanaThreadsProject.Models
{
    [Table("Orders")] 
    public class Order
    {
        [Key]
        [Column("order_id")] 
        public int OrderId { get; set; }

        [Column("customer_name")] 
        public string CustomerName { get; set; }

        [Column("order_date")] 
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Column("total_amount")] 
        public decimal TotalAmount { get; set; } = 0.00m;

        [Column("status")] 
        public string Status { get; set; } = "Pending";

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
