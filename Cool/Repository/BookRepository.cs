using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cool.Models;
using Cool.Models.DbContexts;
using Cool.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Cool.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public BookRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            IEnumerable<Book> bookList = await _db.Books.ToListAsync();
            return _mapper.Map<IEnumerable<BookDto>>(bookList);
        }

        public async Task<BookDto> GetBook(int bookId)
        {
            var book = await _db.Books.Where(x => x.Id == bookId).FirstOrDefaultAsync();
            return _mapper.Map<BookDto>(book);
        }

        public async Task<BookDto> CreateUpdateBook(BookDto bookDto)
        {
            var book = _mapper.Map<BookDto, Book>(bookDto);
            if (book.Id > 0)
            {
                _db.Books.Update(book);
            }
            else
            {
                _db.Books.Add(book);
            }

            await _db.SaveChangesAsync();
            return _mapper.Map<Book, BookDto>(book);
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            var book = await _db.Books.Where(u => u.Id == bookId).FirstOrDefaultAsync();
            if (book == null)
            {
                return false;
            }

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}