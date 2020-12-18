using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class OrderB : BaseEntity
    {
        [Key]
        public int OrderId { get; set; }


        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }

        public int TotalPrice { get; set; }

        public int UserId { get; set; }

        public ICollection<OrderB_Detail> OrderB_Details { get; set; }

        
    }
}
