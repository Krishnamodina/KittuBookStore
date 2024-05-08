using KittuBookStore.Data;
using KittuBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace KittuBookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext? _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int>AddNewBook(BookModel model)
        {
            var newbook = new Book();
            {
             
                
                    newbook.Title = model.Title;
                    newbook.Description = model.Description;
                newbook.Author = model.Author;
                newbook.Category = model.Category;  
               newbook.Language = model.Language;   
                newbook.TotalPages= model.TotalPages;   

            };
           await _context.Books.AddAsync(newbook);
            await _context.SaveChangesAsync(); 
            return newbook.Id;  
        }
        public  async Task<List<BookModel>> GetAllBooks()
        {
            var books=new List<BookModel>();    
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any()==true)
            {
                foreach(var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,   
                        Title = book.Title, 
                        Description = book.Description,
                        Category = book.Category,   
                        Id = book.Id,  
                        Language = book.Language,   
                        TotalPages = book.TotalPages,   

                    });
                       
                }
            }
            return books;
        }
        public async Task<BookModel?> GetBookById (int id)
        {
            var book =await _context.Books.FindAsync(id);
            if(book != null)
            {
                var bookDetails = new BookModel()
                {

                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    Category = book.Category,
                    Id = book.Id,
                    Language = book.Language,
                    TotalPages = book.TotalPages,
                };
                return bookDetails;
            }
            return null;
        }
        public List<BookModel> SearchBook(string title,string author) { 
            return DataSource().Where(x =>x.Title.Contains(title)||x.Author.Contains(author)).ToList();   
        }
        private List<BookModel> DataSource() 
        {
            return new List<BookModel>()
            {
               new BookModel(){Id=1,Title="Mvc",Author="Kittu",Description="Description About Mvc Book",Category="Design",Language="English",TotalPages=235},
               new BookModel(){Id=2,Title="AspMvc",Author="Pawan",Description="Description About AspMvc Book",Category="FrameWork",Language="English",TotalPages=594},
               new BookModel(){Id=3,Title="DOtNetCore",Author="Ram",Description="Description About Core Book" ,Category="FrameWork",Language="English",TotalPages=3827},
               new BookModel(){Id=4,Title="C#",Author="Sathish",Description="Description About C# Book" ,Category="Programming",Language="English",TotalPages=357},
               new BookModel(){Id=5,Title="Java",Author="Tej",Description="Description About Java Book",Category="Programming",Language="English",TotalPages=2281},
               new BookModel(){Id=6,Title="JavaScript",Author="Sai",Description="Description About JavaScript" ,Category="Scripting",Language="English",TotalPages=1892}

            };
        }
    }
}
