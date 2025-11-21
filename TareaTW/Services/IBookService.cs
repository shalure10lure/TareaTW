using TareaTW.Models;
using TareaTW.Models.Dtos;

namespace TareaTW.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetOne(Guid id);
        Task<Book> Create(CreateBookDto dto);
        Task<Book> Update(UpdateBookDto dto, Guid id);
        Task Delete(Guid id);
    }
}
