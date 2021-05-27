using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cool.Models.Dto;

namespace Cool.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookDto>> GetBooks();
        Task<BookDto> GetBook(int bookId);
        Task<BookDto> CreateUpdateBook(BookDto bookDto);
        Task<bool> DeleteBook(int bookId);
    }
}