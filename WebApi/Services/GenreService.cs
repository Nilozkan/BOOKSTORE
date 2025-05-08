using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Book;

namespace WebApi.Services
{
    public class GenreService : IGenreService
    {
         private static List<Genre> GenreList = new List<Genre>
        {
            new Genre{ Id = 1, Name = "Personal Growth"},
            new Genre{ Id = 2, Name = "Science Fiction"},
            new Genre{ Id = 3, Name = "Novel"}
        };

        public List<Genre> GetAll() => GenreList;

        public void Add(Genre genre)
        {
            genre.Id = GenreList.Max(x => x.Id) + 1;
            GenreList.Add(genre);
        }

        public void Delete(int id)
        {
           var genre = GetById(id);
           if (genre is not null)
                GenreList.Remove(genre);
        }

        public Genre GetById(int id)=> GenreList.FirstOrDefault(g => g.Id == id);

        public void Update(int id, Genre updatedGenre)
        {
            var genre = GetById(id);
            if (genre is not null)
            {
                genre.Name = updatedGenre.Name;
            }
        }
    }
}