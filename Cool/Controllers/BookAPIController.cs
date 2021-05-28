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
        private readonly ResponseDto _response;
        private readonly IBookRepository _bookRepository;

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
                var bookDtos = await _bookRepository.GetBooks();
                _response.IsSuccess = true;
                _response.Result = bookDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() {ex.ToString()};
            }

            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var bookDto = await _bookRepository.GetBook(id);
                _response.IsSuccess = true;
                _response.Result = bookDto;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] BookDto bookDto)
        {
            try
            {
                var model = await _bookRepository.CreateUpdateBook(bookDto);
                _response.IsSuccess = true;
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() {ex.ToString()};
            }

            return _response;
        }
        
        [HttpPut]
        public async Task<object> Put([FromBody] BookDto bookDto)
        {
            try
            {
                var model = await _bookRepository.CreateUpdateBook(bookDto);
                _response.IsSuccess = true;
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                var isSuccess = await _bookRepository.DeleteBook(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}