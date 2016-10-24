using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicFall2016.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        [Required(ErrorMessage = "Please enter the name of the album!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a price!")]
        [Range(0.01, 100.00, ErrorMessage = "Must be a price between {1} and {2}!")]
        public decimal Price { get; set; }

        // Foreign key
        public int ArtistID { get; set; }
        // Navigation property
        public virtual Artist Artist { get; set; }

        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
