using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class OrderB_Detail : BaseEntity
    {
        [Key]
        public int Order_DetailId { get; set; }
        public int Amount { get; set; }
        public int BookId { get; set; }

        public int OrderId { get; set; }



        public Book Book { get; set; }
        public OrderB OrderB { get; set; }
    }
}
