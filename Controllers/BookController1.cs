using KittuBookStore.Models;
using KittuBookStore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KittuBookStore.Controllers
{
    public class BookController1 : Controller
    {
        private readonly BookRepository _bookRepository;
        private readonly IWebHostEnvironment _WebHostEnvironment;

        public BookController1(BookRepository bookRepository, IWebHostEnvironment WebHostEnvironment)
        {
            _bookRepository = bookRepository;
            _WebHostEnvironment = WebHostEnvironment;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);

        }
        public async Task<ViewResult> GetBook(int id)
        {
            var data1 = await _bookRepository.GetBookById(id);
            return View(data1);
        }
        public List<BookModel> SearchBooks(string bookname, string author)
        {
            return _bookRepository.SearchBook(bookname, author);
        }
        public ViewResult AddBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel();

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {

                if(bookModel.CoverPhoto!=null)
                {
                    string folder = "books/cover/";    
                   bookModel.CoverImageUrl= await UploadImage(folder,bookModel.CoverPhoto);

                }
                if (bookModel.GalleryFiles != null)
                {

                    string folder = "books/gallery/";
                    bookModel.GalleryUrl = new List<GalleryModel>();
                    foreach(var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name=file.Name,
                            URL = await UploadImage(folder, file)
                        };
                        bookModel.GalleryUrl.Add(gallery);
                       
                    }
                }
                if (bookModel.BookPdf != null)
                {
                    string folder = "books/pdf/";
                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);

                }


                int Id = await _bookRepository.AddBook(bookModel);
                if (Id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId = Id });
                }


            }

            return View();
        }

        private async Task<string> UploadImage(string folderPath,IFormFile file)
        {
           
            folderPath += Guid.NewGuid().ToString() + "_" +file.FileName;
            
            string serverfolder = Path.Combine(_WebHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
            return "/"+ folderPath;
        }
    }
}