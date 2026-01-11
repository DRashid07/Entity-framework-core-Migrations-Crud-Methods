namespace ORM.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; } = null!;
        public StudentDetail StudentDetail { get; set; } = null!;

        public override string ToString()
        {
            return $"Student Id: {Id}, Name: {Name}, Age: {Age}, Group: {Group.Name}, Address: {StudentDetail.Address}, Phone: {StudentDetail.PhoneNumber}";
        }
    }
}
