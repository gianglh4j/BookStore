using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book :BaseEntity

    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string BookImage { get; set; }
        [Required]
        public int BookPrice { get; set; }
        [Required]
        public bool isDeleted { get; set; }

        public ICollection<Book_BookType> Book_BookTypes { get; set; }
        public ICollection<OrderB_Detail> OrderB_Details { get; set; }


    }
}
