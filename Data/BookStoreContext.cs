using Microsoft.EntityFrameworkCore;

namespace KittuBookStore.Data
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options) { 
        }
        public DbSet<Book> Books { get; set; }

       
    }
}
