using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IBook_BookTypeRepository
    {

        Task<Book_BookType> addBook_BookType(Book_BookType book_BookType);
        Task deleteBook_BookTypes(int bookId);

    }
    public class Book_BookTypeRepository : IBook_BookTypeRepository
    {
        private readonly BookStoredbContext bookStoredbContext;
        public Book_BookTypeRepository(BookStoredbContext bookStoredbContext)
        {
            this.bookStoredbContext = bookStoredbContext;
        }

        public async Task<Book_BookType> addBook_BookType(Book_BookType book_BookType)
        {
            var result = await bookStoredbContext.Book_BookTypes.AddAsync(book_BookType);
            await bookStoredbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task deleteBook_BookTypes(int bookId)
        {

            //remove book_bookTypes 
            var book_bookTypeToRemoves = await bookStoredbContext.Book_BookTypes.Where(e => e.BookId == bookId).ToListAsync();
            bookStoredbContext.Book_BookTypes.RemoveRange(book_bookTypeToRemoves);
            await bookStoredbContext.SaveChangesAsync();

        }

       
    }
}
