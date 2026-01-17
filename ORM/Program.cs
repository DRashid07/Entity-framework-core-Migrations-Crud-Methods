using Microsoft.EntityFrameworkCore;
using ORM.Data;
using ORM.Models;

namespace ORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            using (var context = new AppDbContext(new DbContextOptions<AppDbContext>()))
            {
                var author1 = new Author
                {
                    Name = "Nizami Gəncəvi",
                    Country = "Azerbaijan"
                };

                var author2 = new Author
                {
                    Name = "Fyodor Dostoyevski",
                    Country = "Russia"
                };

                context.AddAuthor(author1);
                context.AddAuthor(author2);

                Console.WriteLine("Authors added successfully!");
            }

            
            using (var context = new AppDbContext(new DbContextOptions<AppDbContext>()))
            {
                var book1 = new Book
                {
                    Title = "Leyli və Məcnun",
                    Year = 1188,
                    AuthorId = 1
                };

                var book2 = new Book
                {
                    Title = "Cinayət və Cəza",
                    Year = 1866,
                    AuthorId = 2
                };

                context.AddBook(book1);
                context.AddBook(book2);

                Console.WriteLine("Books added successfully!");
            }

            
            using (var context = new AppDbContext(new DbContextOptions<AppDbContext>()))
            {
                var authors = context.GetAllAuthors();
                Console.WriteLine("\n--- Bütün Authors ---");
                foreach (var author in authors)
                {
                    Console.WriteLine(author);
                    foreach (var book in author.Books)
                    {
                        Console.WriteLine($"  - {book.Title}");
                    }
                }
            }

            
            using (var context = new AppDbContext(new DbContextOptions<AppDbContext>()))
            {
                var author = context.GetAuthorById(1);
                Console.WriteLine("\n--- Author by Id ---");
                Console.WriteLine(author);
            }

           
            using (var context = new AppDbContext(new DbContextOptions<AppDbContext>()))
            {
                var author = context.GetAuthorById(1);
                if (author != null)
                {
                    author.Country = "Azərbaycan";
                    context.UpdateAuthor(author);
                    Console.WriteLine("\n--- Author updated ---");
                }
            }

           
            using (var context = new AppDbContext(new DbContextOptions<AppDbContext>()))
            {
                var books = context.GetAllBooksWithAuthors();
                Console.WriteLine("\n--- Bütün Books with Authors ---");
                foreach (var book in books)
                {
                    Console.WriteLine(book);
                }
            }

            
            using (var context = new AppDbContext(new DbContextOptions<AppDbContext>()))
            {
                var book = context.Books.FirstOrDefault();
                if (book != null)
                {
                    book.Year = 1190;
                    context.UpdateBook(book);
                    Console.WriteLine("\n--- Book updated ---");
                }
            }

            
            using (var context = new AppDbContext(new DbContextOptions<AppDbContext>()))
            {
                
                var authorToDelete = context.GetAuthorById(2);
                if (authorToDelete != null)
                {
                    foreach (var book in authorToDelete.Books.ToList())
                    {
                        context.DeleteBook(book.Id);
                    }
                    context.DeleteAuthor(2);
                    Console.WriteLine("\n--- Author deleted ---");
                }
            }

            Console.WriteLine("\nAll operations completed!");
        }
    }
}

