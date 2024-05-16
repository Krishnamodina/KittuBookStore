using System.Security.Principal;

namespace KittuBookStore.Data
{
    public class Book
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? BookPdfUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int? TotalPages { get; set; }
        public ICollection<BookGallery> bookGalleries { get; set;}
     
        

    }
}
