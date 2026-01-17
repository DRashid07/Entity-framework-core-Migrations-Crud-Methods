using Microsoft.EntityFrameworkCore;
using ORM.Models;

namespace ORM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=SUN06\\MAIN;Database=ORMDb;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public void CreateModels(Group groupName,Student studentName,StudentDetail studentAddress)
        {
            Groups.Add(groupName);
            Students.Add(studentName);
            StudentDetails.Add(studentAddress);
            
            SaveChanges();
        }
        // Author CRUD metodları

        // Author əlavə et
        public void AddAuthor(Author author)
        {
            Authors.Add(author);
            SaveChanges();
        }

        // Bütün author-ları gətir
        public List<Author> GetAllAuthors()
        {
            return Authors.Include(a => a.Books).ToList();
        }

        // Id-yə görə author gətir
        public Author? GetAuthorById(int id)
        {
            return Authors.Include(a => a.Books).FirstOrDefault(a => a.Id == id);
        }

        // Author update et
        public void UpdateAuthor(Author author)
        {
            Authors.Update(author);
            SaveChanges();
        }

        // Author sil
        public void DeleteAuthor(int id)
        {
            var author = Authors.Find(id);
            if (author != null)
            {
                Authors.Remove(author);
                SaveChanges();
            }
        }

        // Book CRUD metodları

        // Book əlavə et (AuthorId ilə)
        public void AddBook(Book book)
        {
            Books.Add(book);
            SaveChanges();
        }

        // Book-ları Author ilə birlikdə gətir (Include)
        public List<Book> GetAllBooksWithAuthors()
        {
            return Books.Include(b => b.Author).ToList();
        }

        // Book update et
        public void UpdateBook(Book book)
        {
            Books.Update(book);
            SaveChanges();
        }

        // Book sil
        public void DeleteBook(int id)
        {
            var book = Books.Find(id);
            if (book != null)
            {
                Books.Remove(book);
                SaveChanges();
            }
        }
    }
}
