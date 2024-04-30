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
               new BookModel(){Id=1,Title="Mvc",Author="Kittu",Description="Description About Mvc Book" },
               new BookModel(){Id=1,Title="AspMvc",Author="Pawan",Description="Description About AspMvc Book" },
               new BookModel(){Id=1,Title="Core",Author="Ram",Description="Description About Core Book" },
               new BookModel(){Id=1,Title="C#",Author="Sathish",Description="Description About C# Book" },
               new BookModel(){Id=1,Title="Java",Author="Tej",Description="Description About Java Book" },
               new BookModel(){Id=1,Title="JavaScript",Author="Sai",Description="Description About JavaScript" }

            };
        }
    }
}
