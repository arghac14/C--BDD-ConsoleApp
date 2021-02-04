using System;
using System.Collections.Generic;
using IMDBapp.Domain;
using System.Linq;

namespace IMDBapp.Repository
{
    public class MovieRepository
    {
        public List<Movies> _movies;
        public List<Actors> _actors;
        public List<Producers> _producers;

        public MovieRepository()
        {
            _movies = new List<Movies>();
            _actors = new List<Actors>();
            _producers = new List<Producers>();
        }
        
        public void AddMovieData(Movies movie)
        {
            _movies.Add(movie);
        }
        public List<Movies> GetMoviesData()
        {
            return _movies.ToList();
        }

        public void AddActorData(Actors actor)
        {
            _actors.Add(actor);
        }
        public List<Actors> GetActorsData()
        {
            return _actors.ToList();
        }

        public void AddProducerData(Producers producer)
        {
            _producers.Add(producer);
        }
        public List<Producers> GetProducersData()
        {
            return _producers.ToList();
        }
    }
}
