using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Backend.DTO
{
    public class BookBaseDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublishedYear { get; set; }
        public string Description { get; set; }
    }
}
