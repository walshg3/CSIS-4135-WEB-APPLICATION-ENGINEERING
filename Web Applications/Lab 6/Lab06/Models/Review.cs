using System.Collections;
using System.ComponentModel.DataAnnotations;


namespace Lab06.Models
{
    public class Review
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 2, ErrorMessage = "Name must have at least 2 characters")]
        [Required]
        public string Reviewer { get; set; }

        [StringLength(1500, MinimumLength = 20, ErrorMessage = "Your review must have at least 20 characters.")]
        [Required]
        public string UserReview { get; set; }

        [Required]
        public int MovieID { get; set; }

        [Required]
        public string MovieTitle { get; set; }
    }
    
}
