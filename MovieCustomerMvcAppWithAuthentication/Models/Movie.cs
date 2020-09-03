using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMvcAppWithAuthentication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Release Date Field is Mandatory")]
        public DateTime ReleaseDate { get; set; }
        [Range(1,20,ErrorMessage ="Field Number should be between from 1 to 20")]
        public int NoOfStock { get; set; }
        [Required(ErrorMessage ="Name Field is Mandatory")]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Genre Field is Mandatory")]
        public int GenreId { get; set; }
    }
}