using BooksApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Data
{
    public class BooksDBContext :  DbContext // context class allows you to communicate with database
    {
        public BooksDBContext(DbContextOptions<BooksDBContext> options) // we want to define options in our BD context class. options will hold the options
            :base(options) 
        {
            
        }
        //add the book table to the database using a DbSet object.
        public DbSet<Book> books { get; set; }//DbSet (table) of books. allows us to add a table to the database called books
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(    // model builder talks to the book entity and hasdata adds seed data to entity 

                new Book
                {
                    BookID = 1,
                    Title = "C# for Beginners",
                    Description = "This is useful",
                    Author="Salman Nazir",
                    Genre="Technology",
                    Price=19.99m,
                    DatePublished=new DateTime(2023,1,20)
                },
                new Book
                {
                    BookID = 2,
                    Title = "Advanced C#",
                    Description = "This is useful",
                    Author = "Salman Nazir",
                    Genre = "Technology",
                    Price = 15.99m,
                    DatePublished = new DateTime(2023, 10, 25)

                },
                new Book
                {
                    BookID = 3,
                    Title = "HTML for Beginners",
                    Description = "This is useful",
                    Author = "Salman Nazir",
                    Genre = "Technology",
                    Price = 10.99m,
                    DatePublished = new DateTime(2023, 10, 20)
                }

                );
        }
    }
}
