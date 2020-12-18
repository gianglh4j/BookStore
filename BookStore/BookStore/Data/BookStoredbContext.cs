using BookStore.Models;
using Microsoft.EntityFrameworkCore;


namespace BookStore.Data
{
    public class BookStoredbContext : DbContext
    {
        public BookStoredbContext(DbContextOptions<BookStoredbContext> options) : base(options)
        {
       
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Book_BookType> Book_BookTypes { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<OrderB> OrderBs { get; set; }
        public DbSet<OrderB_Detail> OrderB_Details { get; set; }
       // public DbSet<UserB> UserBs { get; set; }

   


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Book_BookType>().ToTable("Book_BookType");
            modelBuilder.Entity<BookType>().ToTable("BookType");
            modelBuilder.Entity<OrderB>().ToTable("OrderB");
            modelBuilder.Entity<OrderB_Detail>().ToTable("OrderB_Detail");
          
          
            
        }
    }
    
}
    

