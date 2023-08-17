using BookStore.Book.Entity;

namespace BookStore.Book.Interface;

public interface IBookServices
{
    BookEntity AddBook(BookEntity newBook);
    BookEntity GetBookById(int id);
    IEnumerable<BookEntity> GetAllBooks();
    BookEntity UpdateBook(int id, BookEntity updatedBook);
    bool DeleteBook(int id);
}
