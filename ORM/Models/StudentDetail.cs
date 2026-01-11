namespace ORM.Models
{
    public class StudentDetail
    {
        public int Id { get; set; }
        public string Address { get; set; }=null!;
        public string PhoneNumber { get; set; }=null!;
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
    }
}
