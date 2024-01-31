using System.ComponentModel.DataAnnotations;

namespace BooksApp.Models
{
    public class Book
    {
        [Key] //data annotation, defines pk
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePublished { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

    }
}
