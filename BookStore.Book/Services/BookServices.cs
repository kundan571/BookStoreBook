using BookStore.Book.Entity;
using BookStore.Book.Interface;

namespace BookStore.Book.Services;

public class BookServices : IBookServices
{
    private readonly BookContext _db;
   // private readonly IConfiguration _config;
    public BookServices(BookContext db, IConfiguration config)
    {
        _db = db;
        
    }
    public BookEntity AddBook(BookEntity newBook)
    {
        _db.Books.Add(newBook);
        _db.SaveChanges();
        return newBook;
    }
    public BookEntity GetBookById(int id)
    {
        BookEntity book = _db.Books.FirstOrDefault(x => x.BookId == id);
        return book;
    }
    public IEnumerable<BookEntity> GetAllBooks()
    {
        IEnumerable<BookEntity> books = _db.Books;
        return books;
    }
    public BookEntity UpdateBook(int id, BookEntity updatedBook)
    {
        BookEntity book = _db.Books.FirstOrDefault(x => x.BookId == id);
        if (book != null)
        {
            book.BookName = updatedBook.BookName;
            book.AuthorName = updatedBook.AuthorName;
            book.Description = updatedBook.Description;
            book.Ratings = updatedBook.Ratings;
            book.Reviews = updatedBook.Reviews;
            book.DiscountedPrice = updatedBook.DiscountedPrice;
            book.OriginalPrice = updatedBook.OriginalPrice;
            book.Quantity = updatedBook.Quantity;
            _db.Books.Update(book);
            _db.SaveChanges();
        }

        return book;
    }
    public bool DeleteBook(int id)
    {
        BookEntity book = _db.Books.FirstOrDefault(x => x.BookId == id);
        if (book != null)
        {
            _db.Books.Remove(book);
            _db.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

}
