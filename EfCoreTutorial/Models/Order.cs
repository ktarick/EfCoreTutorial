using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCoreTutorial.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [StringLength(1000)]
        [Required]
        public string Description { get; set; }
        public double Total { get; set; } = 0;
        public int CustomerId { get; set; }

        public Order()
        {
        }
    }
}
