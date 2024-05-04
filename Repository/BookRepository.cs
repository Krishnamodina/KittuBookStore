   using KittuBookStore.Models;

namespace KittuBookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById (int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return DataSource().FirstOrDefault(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
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
