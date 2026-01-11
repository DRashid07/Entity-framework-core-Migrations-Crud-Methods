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
    }
}
