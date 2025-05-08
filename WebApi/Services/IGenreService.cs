using WebApi.Models.Book;
using System.Collections.Generic;

namespace WebApi.Services
{
    public interface IGenreService
    {
        List<Genre> GetAll();
        Genre GetById(int id);
        void Add(Genre genre);
        void Update(int id, Genre updatedGenre);
        void Delete(int id);
    }
}