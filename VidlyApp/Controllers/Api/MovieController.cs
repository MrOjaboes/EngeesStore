using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyApp.Models;

namespace VidlyApp.Controllers.Api
{
    public class MovieController : ApiController
    {
        private VidlyAppContext _db = new VidlyAppContext();
        // GET: api/Customer
        public IEnumerable<Movie> GetMovies()
        {
            return _db.Movies.ToList();

        }

        // GET: api/Customer/5
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();
            //throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(movie);

        }

        // POST: api/Customer
        [System.Web.Http.HttpPost]
        public IHttpActionResult AddMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);

        }

        // PUT: api/Customer/5
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var MovieInDb = _db.Movies.FirstOrDefault(m => m.Id == id);
            if (MovieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            MovieInDb.Name = movie.Name;
            MovieInDb.GenreId = movie.GenreId;
            MovieInDb.DateAdded = MovieInDb.DateAdded;
            MovieInDb.ReleaseDate = movie.ReleaseDate;
            MovieInDb.NumberInStock = movie.NumberInStock;
            MovieInDb.NumberAvailable = movie.NumberAvailable;
            _db.SaveChanges();
            return Ok(movie);
        }

        // DELETE: api/Customer/5
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteMovie(int id, Movie movie)
        {
            var MovieInDb = _db.Movies.FirstOrDefault(m => m.Id == id);
            if (MovieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _db.Movies.Remove(MovieInDb);
            _db.SaveChanges();
            return Ok(movie);
        }
    }
}
