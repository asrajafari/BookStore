using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(bookDTO bookDTO)
        {
            _bookService.AddBook(bookDTO);
            return CreatedAtAction(nameof(GetBookById), new { id = bookDTO.Id }, bookDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookDTO bookDTO)
        {
            _bookService.UpdateBook(id, bookDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return NoContent();
        }
    }
