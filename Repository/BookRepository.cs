using KittuBookStore.Data;
using KittuBookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KittuBookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context=null;
        private Expression<Func<object, int, object>> book;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddBook(BookModel model)
        {
            var newBook = new Book
            {
                Title = model.Title,
                Description = model.Description,
                Author = model.Author,
                Category = model.Category,
                Language = model.Language,
               TotalPages= model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
               CoverImageUrl = model.CoverImageUrl,
               BookPdfUrl=model.BookPdfUrl, 
               
            };
            newBook.bookGalleries = new List<BookGallery>();
            foreach(var file in model.GalleryUrl)
            {
                newBook.bookGalleries.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            //newBook.bookGallery = model.Gallery?.Select(g => new BookGallery
            //{
            //    Name = g.Name,
            //    URL = g.URL
            //}).ToList();

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                 .Select(book => new BookModel { 
                  Author = book.Author, 
                  Category = book.Category, 
                  Description= book.Description,    
                  Id = book.Id,
                  Language= book.Language,  
                  Title= book.Title,    
                  TotalPages=book.TotalPages,
                  CoverImageUrl= book.CoverImageUrl 

                }).ToListAsync();
            
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                  .Select(book => new BookModel()
                  {
                      Author = book.Author,
                      Category = book.Category,
                      Description = book.Description,
                      Id = book.Id,
                      Language = book.Language,
                      Title = book.Title,
                      TotalPages = book.TotalPages,
                      CoverImageUrl = book.CoverImageUrl,
                      GalleryUrl = book.bookGalleries.Select(g => new GalleryModel()
                      {
                          Id = g.Id,
                          Name=g.Name,
                          URL=g.URL
                      }).ToList(),
                      BookPdfUrl=book.BookPdfUrl,

                  }).FirstOrDefaultAsync() ?? new BookModel();  

        }

            
        

        public List<BookModel> SearchBook(string title, string author)
        {
            

            return null;
        }
    }
}
