﻿using BookStore.DTO;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Repository;
namespace BookStore.DomainLogic

{
    public interface IBookLogic
    {
        Task<Book> AddBook(Book book, List<BookTypeDTO> bookTypes);
        Task<Book> UpdateBook(Book book, List<BookTypeDTO> bookTypes);
        Task<Book> getBook(int bookId);

        Task<IEnumerable<Book>> getBooks();

        Task<BookType> getBooksFollowType(int typeId);

    }
    public class BookLogic : IBookLogic
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBook_BookTypeLogic _book_BookTypeLogic;


        public BookLogic(IBookRepository bookRepository, IBook_BookTypeLogic book_BookTypeLogic)
        {
            this._bookRepository = bookRepository;
            this._book_BookTypeLogic = book_BookTypeLogic;
         

        }

        public async Task<Book> AddBook(Book book, List<BookTypeDTO> bookTypes)
        {



            var result =  await _bookRepository.AddBook(book);



            //add to Book_BookType table
            foreach (BookTypeDTO bookType in bookTypes)
            {
                Book_BookType book_BookType = new Book_BookType() { BookTypeId = bookType.BookTypeId, BookId = result.BookId };
                await _book_BookTypeLogic.addBook_BookType(book_BookType);

            }

            return result;

        }

        public async Task<Book> getBook(int bookId)
        {
            var result = await _bookRepository.GetBook(bookId);
            return result;
        }

        public async Task<IEnumerable<Book>> getBooks()
        {
            var result = await _bookRepository.GetBooks();
            return result;
        }

        public async Task<BookType> getBooksFollowType(int typeId)
        {
            var result = await _bookRepository.GetBooksFollowType(typeId);
            return result;
        }

        public async Task<Book> UpdateBook(Book book, List<BookTypeDTO> bookTypes)
        {
            var result = await _bookRepository.UpdateBook(book);

        
            if(bookTypes != null) {
                //remove last book_bookType 
                await _book_BookTypeLogic.deleteBook_BookTypes(book.BookId);
                //add new book-booktypes 
                foreach (BookTypeDTO bookType in bookTypes)
                {
                    Book_BookType book_BookType = new Book_BookType() { BookTypeId = bookType.BookTypeId, BookId = result.BookId };
                    await _book_BookTypeLogic.addBook_BookType(book_BookType);

                }
            }
            
            
            return result;

        }

       
    }
}
