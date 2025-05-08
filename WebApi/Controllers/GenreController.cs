using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Book;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var genres = _genreService.GetAll();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var genre = _genreService.GetById(id);
            if (genre == null)
                return NotFound();
            return Ok(genre);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Genre newGenre)
        {
            _genreService.Add(newGenre);
            return Ok(newGenre);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Genre updatedGenre)
        {
            var genre = _genreService.GetById(id);
            if (genre == null)
                return NotFound();

            _genreService.Update(id, updatedGenre);
            return Ok(updatedGenre);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var genre = _genreService.GetById(id);
            if (genre == null)
                return NotFound();

            _genreService.Delete(id);
            return Ok();
        }
    }
}