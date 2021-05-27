using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cool.Models.Dto;
using Cool.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cool.Controllers
{
    [Route("api/books")]
    public class BookApiController : Controller
    {
        private ResponseDto _response;
        private IBookRepository _bookRepository;

        public BookApiController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<BookDto> bookDtos = await _bookRepository.GetBooks();
                _response.Result = bookDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() {ex.ToString()};
            }

            return _response;
        }
    }
}