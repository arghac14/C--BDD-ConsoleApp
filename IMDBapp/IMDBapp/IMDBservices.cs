using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IMDBapp.Domain;
using IMDBapp.Repository;

namespace IMDBapp
{
    public class IMDBservices
    {
        private readonly MovieRepository _movieRepository;
        

        
        public IMDBservices()
        {
            _movieRepository = new MovieRepository();
        }
        
        // Movies
        public void AddMovie(string name, string year, string plot, List<Actors> actors, Producers producer)
        {
            
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Movie name can't be empty!");
            }

            DateTime dDate;

            if (DateTime.TryParse(year, out dDate))
            {
                String.Format("{0:d/MM/yyyy}", dDate);
            }
            else
            {
                throw new Exception("Invalid Date!");
            }

            if (string.IsNullOrEmpty(plot))
            {
                throw new ArgumentException("Plot can't be empty!");
            }

            if (!actors.Any())
            {
                throw new ArgumentException("Invalid choice of Actor!");
            }

            //if (string.IsNullOrEmpty(producer))
            //{
            //    throw new ArgumentException("Invalid choice of Producer!");
            //}

            Movies movie = new Movies()
            {
                Name = name,
                Year = year,
                Plot = plot,
                Actors = actors,
                Producer = producer
            };

            _movieRepository.AddMovieData(movie);
        }

        public List<Movies> GetAllMovies()
        {
            return _movieRepository.GetMoviesData();
        }

        //Actors
        public void AddActor(string actorName, string actorDob)
        {

            if (string.IsNullOrEmpty(actorName))
            {
                throw new ArgumentException("Actor name can't be empty!");
            }

            
            DateTime dDate;

            if (DateTime.TryParse(actorDob, out dDate))
            {
                String.Format("{0:d/MM/yyyy}", dDate);
            }
            else
            {
                throw new Exception("Invalid Date of Birth Format!");
            }


            Actors actor = new Actors()
            {
                ActorName = actorName,
                ActorDOB = actorDob
            };

            _movieRepository.AddActorData(actor);
        }

        public List<Actors> GetAllActors()
        {
            return _movieRepository.GetActorsData();
        }

        //Producers
        public void AddProducer(string producerName, string producerDob)
        {

            if (string.IsNullOrEmpty(producerName))
            {
                throw new ArgumentException("Actor name can't be empty!");
            }


            DateTime dDate;

            if (DateTime.TryParse(producerDob, out dDate))
            {
                String.Format("{0:d/MM/yyyy}", dDate);
            }
            else
            {
                throw new Exception("Invalid Date of Birth Format!");
            }


            Producers producer = new Producers()
            {
                ProducerName = producerName,
                ProducerDOB = producerDob
            };
            _movieRepository.AddProducerData(producer);
        }

        public List<Producers> GetAllProducers()
        {
            return _movieRepository.GetProducersData();
        }

        public void DeleteByID(int id)
        {
            if (id > _movieRepository._movies.Count || id <= 0)
            {
                Console.WriteLine("\nChoose a valid movie from the list to delete!");
            }
            else
            {
                _movieRepository._movies.RemoveAt(id - 1);
                Console.WriteLine("\nMovie Deleted!");
            }
        }


        //public void DeleteByName(string movieName)
        //{
        //    List<Movies> targetMovies = new List<Movies>();
        //    targetMovies = _movieRepository._movies.FindAll(x => x.Name == movieName);
        //    if (!targetMovies.Any())
        //    {
        //        Console.WriteLine("No such movie exists in database!");
        //    }
        //    else
        //    {
        //        _movieRepository._movies.RemoveAll(x => x.Name == movieName);
        //        Console.WriteLine("Movie Deleted!");
        //    }
        //}

    }
}
