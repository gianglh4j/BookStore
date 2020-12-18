using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DTO;
using BookStore.Models;

namespace BookStore.DTO
{
    public class BookDTO
    {
        
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public int BookPrice { get; set; }

         public bool isDeleted { get; set; }

        public List<BookTypeDTO> BookTypes { get; set; }


    }
    public class BookTypeDTO
    {
        public int BookTypeId { get; set; }
        public string BookTypeName { get; set; }
    }
    public class BookDTORes
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookImage { get; set; }
        public int BookPrice { get; set; }

        public List<BookTypeDTORes> BookTypes { get; set; }


    }

    public class BookTypeDTORes
    {

        public int BookTypeId { get; set; }
        public string BookTypeName { get; set; }


    }


    public class BookTypeDTORes3
    {
        public List<BookDTORes> Books { get; set; }

    }







}
