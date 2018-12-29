using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies;
        public SelectList Genres;
        public string MovieGenre { get; set; }
    }

    public class ReviewViewModel
    {
        public List<Lab06.Models.Review> ReviewerName { get; set; }
        public List<String> ReviewBody { get; set; }
    }
}
