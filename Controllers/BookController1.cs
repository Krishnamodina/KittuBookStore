using KittuBookStore.Models;
using KittuBookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KittuBookStore.Controllers
{
    public class BookController1 : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController1()
        {
            _bookRepository = new BookRepository();
        }
       
        public ViewResult GetAllBooks ()
        {
            var data= _bookRepository.GetAllBooks();
            return View(data);

        }
        public BookModel GetBook(int id) { 
           return _bookRepository.GetBookById(id);
        }
        public List<BookModel> SearchBooks(string bookname,string author)
        {
            return _bookRepository.SearchBook(bookname,author);
        }
    }
}
