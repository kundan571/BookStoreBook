using BookStore.Book.Entity;
using BookStore.Book.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _book;
        public ResponseEntity response;

        public BookController(IBookServices book)
        {
            _book = book;
            response = new ResponseEntity();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        [Route("AddBook")]
        public ResponseEntity AddBook(BookEntity book)
        {
            BookEntity newBook = _book.AddBook(book);
            if (newBook != null)
            {
                response.Data = newBook;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Something went Wrong";
            }

            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("EditBook")]
        public ResponseEntity UpdateBook(int id, BookEntity book)
        {
            BookEntity updatedBook = _book.UpdateBook(id, book);
            if (updatedBook != null)
            {
                response.Data = updatedBook;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Something went Wrong";
            }

            return response;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("DeleteBook")]
        public ResponseEntity DeleteBook(int id)
        {
            bool result = _book.DeleteBook(id); 
            if (result != null)
            {
                response.Data = result;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Something went Wrong";
            }

            return response;
        }

        [HttpGet]
        [Route("GetById")]
        public ResponseEntity GetBook(int id)
        {
            BookEntity book = _book.GetBookById(id);
            if(book != null)
            {
                response.Data = book;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Books not found";
            }

            return response;

        }

        [HttpGet]
        [Route("GetAllBooks")]
        public ResponseEntity GetAllBooks()
        {
            IEnumerable<BookEntity> books = _book.GetAllBooks();
            if (books.Any())
            {
                response.Data = books;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Books not found";
            }

            return response;
        }
    }
}
