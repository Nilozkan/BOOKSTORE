using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Book;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private string GetGenreName(int genreId)
{
        return genreId switch
        {
            1 => "Personal Growth",
            2 => "Science Fiction",
            3 => "Romance",
            _ => "Unknown"
        };
}
        private static List<Book> BookList = new List<Book>()
        {
            new Book{
                Id =1,
                Title="Lean Startup",
                GenreId= 1, //Personal Growth
                PageCount= 200,
                PublishDate = new DateTime(2001,06,12)
            },

                new Book{
                Id =2,
                Title="Herland",
                GenreId= 2, //Science Fiction
                PageCount= 250,
                PublishDate = new DateTime(2023,12,21)
            },
                new Book{
                Id =3,
                Title="Dune",
                GenreId= 2, //Science Fiction
                PageCount= 540,
                PublishDate = new DateTime(2001,12,21)
            }

        };
        
        [HttpGet]
        public Book Get([FromQuery] string id){
            var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = BookList.SingleOrDefault(book => book.Id == id);
            if (book == null)
                return NotFound();

            var viewModel = new GetBookViewModel
            {
                Title = book.Title,
                Genre = GetGenreName(book.GenreId),
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.ToString("dd.MM.yyyy")
            };

            return Ok(viewModel);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            var book = BookList.SingleOrDefault(book => book.Id == id);
            if (book == null)
                return NotFound();

            book.Title = updatedBook.Title;
            book.GenreId = updatedBook.GenreId;
            book.PageCount = updatedBook.PageCount;
            book.PublishDate = updatedBook.PublishDate;

            return Ok();
        }


    }
}