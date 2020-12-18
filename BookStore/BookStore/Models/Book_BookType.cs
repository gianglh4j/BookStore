using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book_BookType : BaseEntity
    {
        [Key]      
        public int Book_BookTypeId { get; set; }
        public int BookId { get; set; }
        public int BookTypeId { get; set; }

        public Book Book { get; set; }
        public BookType BookType { get; set; }
    }
}
