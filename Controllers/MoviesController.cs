using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Models.Movie> movies = new List<Models.Movie>()
        { 
             new Models.Movie() { ID = Guid.NewGuid(), MovieName = "Movie1" },
            new Models.Movie() { ID = Guid.NewGuid(), MovieName = "Movie2" },
            new Models.Movie() { ID = Guid.NewGuid(), MovieName = "Movie3" },
            new Models.Movie() { ID = Guid.NewGuid(), MovieName = "Movie4" },
            new Models.Movie() { ID = Guid.NewGuid(), MovieName = "Movie5" }
        };

[HttpGet]
public Models.Movie[] Get()
{
    return movies.ToArray();
}

[HttpPost]
public void Post([FromBody] Models.Movie movie)
{
    if (movie.ID == Guid.Empty)
        movie.ID = Guid.NewGuid();

    movies.Add(movie);
}

[HttpPut]
public void Put([FromBody] Models.Movie movie)
{
    Models.Movie currentMovie = movies.FirstOrDefault(x => x.ID == movie.ID);
    currentMovie.MovieName = movie.MovieName;
}

[HttpDelete]
public void Delete(Guid id)
{
    movies.RemoveAll(movie => movie.ID == id);

    //foreach (Models.Movie movie in movies)
    //{
    //    if (movie.ID == id)
    //    {
    //        movies.Remove(movie);
    //    }
    //}
}
    }
}
