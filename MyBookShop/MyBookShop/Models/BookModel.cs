using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyBookShop.Models
{
    public class BookModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is required.")]
        public string MyFields { get; set; }
        public int id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        
        public string Category { get; set; }
        [Required(ErrorMessage ="Please choose language for book.")]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage ="Please Enter the total pages.")]
        [Display(Name="Total Pages of Book")]
        public int? TotalPages { get; set; }//we set the nullable , coz of taking nueric value.
    }
}
