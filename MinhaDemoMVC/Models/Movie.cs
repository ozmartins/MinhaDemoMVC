using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaDemoMVC.Models
{
    public class Movie
    {   
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is mandatory")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Title must hava 3 to 60 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Release date is mandatory")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid format for release date")]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\W-]*$", ErrorMessage = "Invalid format for genre")]
        [StringLength(60, ErrorMessage = "Genre can have 60 characters maximum"), Required(ErrorMessage = "Genre is mandatory")]
        public string Genre { get; set; }
        
        [Range(1, 1000, ErrorMessage = "Price must be between 1 and 1000, inclusive")]
        [Required(ErrorMessage = "Price is mandatory")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        [RegularExpression(@"^[0-5]*$", ErrorMessage = "Grade must be a a number between 1 and 5")]
        public int Grade { get; set; }
    }
}
