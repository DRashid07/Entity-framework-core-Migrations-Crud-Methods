using Microsoft.EntityFrameworkCore;
using ORM.Data;
using ORM.Models;

namespace ORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext>()))
            {

                var group = new Group
                {
                    Name = "A Grubu"
                };


                var student1 = new Student
                {
                    Name = "Ali Yılmaz",
                    Age = 20,
                    Group = group,
                    StudentDetail = new StudentDetail
                    {
                        Address = "Address 1",
                        PhoneNumber = "555-0001"
                    }
                };

                var student2 = new Student
                {
                    Name = "Ayşe Demir",
                    Age = 22,
                    Group = group,
                    StudentDetail = new StudentDetail
                    {
                        Address = "Address 2",
                        PhoneNumber = "555-0002"
                    }
                };

                context.Groups.Add(group);
                context.Students.Add(student1);
                context.Students.Add(student2);
                context.SaveChanges();

                Console.WriteLine("Data saved successfully!");
            }
            using (var context = new AppDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext>()))
            {
                var students = context.Students
                    .Include(s => s.Group)
                    .Include(s => s.StudentDetail)
                    .ToList();
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
            using (var context = new AppDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext>()))
            {
                context.CreateModels(
                    new Group { Name = "C grubu" },
                    new Student
                    {
                        Name = "Rashid Dursunov",
                        Age = 21,
                        GroupId = 2,
                        StudentDetail = new StudentDetail
                        {
                            Address = "Address nese",
                            PhoneNumber = "055-5555"
                        }
                    };
            }

        }
    }
}

