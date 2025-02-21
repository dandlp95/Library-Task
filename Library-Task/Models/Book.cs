namespace Library_Task.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required int PublishedYear { get; set; }
    }
}
