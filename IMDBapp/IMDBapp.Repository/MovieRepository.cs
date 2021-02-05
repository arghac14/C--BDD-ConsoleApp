using System;
using System.Collections.Generic;
using IMDBapp.Domain;
using System.Linq;

namespace IMDBapp.Repository
{
    public class MovieRepository
    {
        public List<Movie> _movies;

        public MovieRepository()
        {
            _movies = new List<Movie>();
        }
        public void AddMovieData(Movie movie)
        {
            _movies.Add(movie);
        }
        public List<Movie> GetMoviesData()
        {
            return _movies.ToList();
        }
    }
}
