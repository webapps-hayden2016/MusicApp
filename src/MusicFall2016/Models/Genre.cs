using System.ComponentModel.DataAnnotations;

namespace MusicFall2016.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        [Required (ErrorMessage = "Please enter a genre")]
        [StringLength(20, ErrorMessage = "The genre name must be between 1 and 20 characters!")]
        public string Name { get; set; }
    }
}