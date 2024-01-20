using System.ComponentModel.DataAnnotations.Schema;

namespace MovieLibrary
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
        public string Streaming { get; set; }
    }
}
