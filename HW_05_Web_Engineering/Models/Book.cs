namespace HW_05_Web_Engineering.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }   
    }
}
