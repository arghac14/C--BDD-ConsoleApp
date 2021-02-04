using System;
using System.Collections.Generic;
using IMDBapp.Domain;
using System.Linq;

namespace IMDBapp.Repository
{
    public class MovieRepository
    {
        public List<Movie> _movies;
        public List<Actor> _actors;
        public List<Producer> _producers;

        public MovieRepository()
        {
            _movies = new List<Movie>();
            _actors = new List<Actor>();
            _producers = new List<Producer>();
        }
        
        public void AddMovieData(Movie movie)
        {
            _movies.Add(movie);
        }
        public List<Movie> GetMoviesData()
        {
            return _movies.ToList();
        }

        public void AddActorData(Actor actor)
        {
            _actors.Add(actor);
        }
        public List<Actor> GetActorsData()
        {
            return _actors.ToList();
        }

        public void AddProducerData(Producer producer)
        {
            _producers.Add(producer);
        }
        public List<Producer> GetProducersData()
        {
            return _producers.ToList();
        }
    }
}
