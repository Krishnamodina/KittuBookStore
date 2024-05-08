using KittuBookStore.Models;
using KittuBookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KittuBookStore.Controllers
{
    public class BookController1 : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController1(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
       
        public async Task<ViewResult> GetAllBooks ()
        {
            var data=await  _bookRepository.GetAllBooks();
            return View(data);

        }
        public async Task<ViewResult> GetBook(int id) { 
           var data1=await _bookRepository.GetBookById(id);
            return View(data1);  
        }
        public List<BookModel> SearchBooks(string bookname,string author)
        {
            return _bookRepository.SearchBook(bookname,author);
        } 
        public ViewResult AddBook(bool isSuccess=false,int bookId=0)
        {
            ViewBag.IsSuccess = isSuccess;  
            ViewBag.BookId= bookId; 
            return View();
                
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
           int id=await _bookRepository.AddNewBook(bookModel);  
            if(id>0)
            {
                return RedirectToAction(nameof(AddBook), new {isSuccess=true,bookId=id });
            }
            return View();

        }


    }
}