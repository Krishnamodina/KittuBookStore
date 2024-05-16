using KittuBookStore.Data;
using System.ComponentModel.DataAnnotations;
namespace KittuBookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Please Enter The Book Title")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "*Please Enter The Author Name")]
        public string Author { get; set; }

        public string Category { get; set; }


        [Required(ErrorMessage = "*Please select language")]

        public string Language { get; set; }

        [Required(ErrorMessage = "*Please Enter The Total Pages")]
        [Display(Name = "Total Pages of Book")]

        public int? TotalPages { get; set; }
        
        public IFormFile? CoverPhoto { get; set; }
        public string? CoverImageUrl {  get; set; }  
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public IFormFileCollection? GalleryFiles { get; set; }
        public List<GalleryModel>? GalleryUrl { get; set; }
        public IFormFile? BookPdf{ get; set; }
        public string? BookPdfUrl { get; set; }
    }  
}
        
    
    

