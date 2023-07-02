using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBookShop.Models
{
    public class BookModel
    {
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage ="Password is required.")]
        //public string MyFields { get; set; }
        public int id { get; set; }
        [Required]
        //[StringLength(100,MinimumLength =5)]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }

        public string Category { get; set; }
        [Required(ErrorMessage = "Please choose language for book.")]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "Please Enter the total pages.")]
        [Display(Name = "Total Pages of Book")]
        public int? TotalPages { get; set; }//we set the nullable , coz of taking nueric value.
        [Display(Name = "Choose Cover Photo")]
        [NotMapped]
        public IFormFile CoverPhoto { get; set; }
        [Display(Name = "Choose Photos for gallary")]
        [Required]
        [NotMapped]
        public IFormFileCollection GallaryFiles { get; set; }
        public string CoverImageUrl { get; set; }
        public List<GalleryModel> Gallery { get; set; }
        [Display(Name = "Choose Pdf file for the Book")]
        [NotMapped]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }

    }
}
