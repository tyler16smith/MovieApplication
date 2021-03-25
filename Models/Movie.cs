using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApplication.Models
{
    public class Movie
    {
        // all data for the DB
        [Key]
        public int MovieId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }
        public string Edited { get; set; }
        public string LentTo { get; set; }

        [StringLength(25, ErrorMessage = "The note cannot exceed 25 characters.")]
        public string Notes { get; set; }
    }
}
