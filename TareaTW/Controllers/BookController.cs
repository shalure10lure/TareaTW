using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TareaTW.Models;
using TareaTW.Models.Dtos;
using TareaTW.Services;

namespace TareaTW.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BookController:ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        // GET: /api/book
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            IEnumerable<Book> items = await _service.GetAll();
            return Ok(items);
        }

        // GET: /api/book/{id}
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var book = await _service.GetOne(id);
            return Ok(book);
        }

        // POST: /api/book
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var book = await _service.Create(dto);

            return CreatedAtAction(nameof(GetOne), new { id = book.Id }, book);
        }

        // PUT: /api/book/{id}
        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto dto, Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var book = await _service.Update(dto, id);

            return CreatedAtAction(nameof(GetOne), new { id = book.Id }, book);
        }

        // DELETE: /api/book/{id}
        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            await _service.Delete(id);

            return NoContent();
        }
    }
}
