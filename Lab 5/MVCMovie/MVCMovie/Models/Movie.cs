using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3, ErrorMessage = "Length of title must be from 3 to 60")]
        [Required]
        public string Title { get; set; }

        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime ReleaseDate { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "The field Genre must be a string with a maximum length of 30")]
        public string Genre { get; set; }
        

        [Range(1, 100, ErrorMessage = "Price must be from $1 to $100")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]

        public decimal Price { get; set; }

        
        [Required]
        public string Rating { get; set; }
    }

    public enum Ratings
    {
        NC17,
        R,
        PG13,
        PG,
        G,
        NR
    }
}
