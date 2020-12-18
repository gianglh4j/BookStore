using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookType : BaseEntity
    {
       

        [Key]
        public int BookTypeId { get; set; }
        public string BookTypeName { get; set; }

        public ICollection<Book_BookType> Book_BookTypes { get; set; }

    }
}
