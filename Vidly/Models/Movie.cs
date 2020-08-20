using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name ="Genre")]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Range(1,20, ErrorMessage = "The filed Number in Stock must be between 1 and 20")]
        [Display(Name ="Number in Stock")]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

        public byte[] MovieImage { get; set; }

        [NotMapped]
        public string ImageUrl { get; set; }
    }
}