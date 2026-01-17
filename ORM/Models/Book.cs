namespace ORM.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Year { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public override string ToString()
        {
            return $"Book Id: {Id}, Title: {Title}, Year: {Year}, Author: {Author.Name}";
        }
    }
}