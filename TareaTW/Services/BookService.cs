using TareaTW.Models;
using TareaTW.Models.Dtos;
using TareaTW.Repositories;

namespace TareaTW.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<Book> Create(CreateBookDto dto)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Author = dto.Author,
                Year = dto.Year,
                Description = dto.Description
            };

            await _repo.Add(book);
            return book;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Book> GetOne(Guid id)
        {
            return await _repo.GetOne(id);
        }

        public async Task<Book> Update(UpdateBookDto dto, Guid id)
        {
            Book? book = await GetOne(id);
            if (book == null) throw new Exception("Book doesn't exist.");

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Year = dto.Year;
            book.Description = dto.Description;

            await _repo.Update(book);
            return book;
        }

        public async Task Delete(Guid id)
        {
            Book? book = (await GetAll()).FirstOrDefault(b => b.Id == id);
            if (book == null) return;

            await _repo.Delete(book);
        }
    }
}
