using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IMDBapp.Domain;
using IMDBapp.Repository;
using System.Globalization;

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
        public void AddMovie(string name, string year, string plot, List<Actor> actors, Producer producer)
        {
            
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Movie name can't be empty!");
            }

            if (Convert.ToInt32(year) < 1000 || Convert.ToInt32(year) > 2021)
            {
                throw new Exception("Invalid Year!");
            }

            if (string.IsNullOrEmpty(plot))
            {
                throw new ArgumentException("Plot can't be empty!");
            }

            if (!actors.Any())
            {
                throw new ArgumentException("Invalid choice of Actor!");
            }


            Movie movie = new Movie()
            {
                Name = name,
                Year = year,
                Plot = plot,
                Actors = actors,
                Producer = producer
            };

            _movieRepository.AddMovieData(movie);
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetMoviesData();
        }

        //Actors
        public void AddActor(string actorName, string dob)
        {

            DateTime dDate, actorDob;

            if (string.IsNullOrEmpty(actorName))
            {
                throw new Exception("Actor name can't be empty!");
            }


            if (DateTime.TryParse(dob, out dDate))
            {
                String.Format("{0:d/MM/yyyy}", dDate);
                actorDob = DateTime.ParseExact(dob, "d/M/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                throw new Exception("Invalid Date of Birth Format!");
            }


            Actor actor = new Actor()
            {
                Name = actorName,
                DOB = actorDob
            };

            _movieRepository.AddActorData(actor);
        }

        public List<Actor> GetAllActors()
        {
            return _movieRepository.GetActorsData();
        }

        //Producers
        public void AddProducer(string producerName, string dob)
        {

            DateTime dDate, producerDob;

            if (string.IsNullOrEmpty(producerName))
            {
                throw new ArgumentException("Actor name can't be empty!");
            }

            if (DateTime.TryParse(dob, out dDate))
            {
                String.Format("{0:d/MM/yyyy}", dDate);
                producerDob = DateTime.ParseExact(dob, "d/M/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                throw new Exception("Invalid Date of Birth Format!");
            }


            Producer producer = new Producer()
            {
                Name = producerName,
                DOB = producerDob
            };
            _movieRepository.AddProducerData(producer);
        }

        public List<Producer> GetAllProducers()
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

        public void DeleteByName(string movieName)
        {
            List<Movie> targetMovies = new List<Movie>();
            targetMovies = _movieRepository._movies.FindAll(x => x.Name == movieName);
            if (!targetMovies.Any())
            {
                Console.WriteLine("No such movie exists in database!");
            }
            else
            {
                _movieRepository._movies.RemoveAll(x => x.Name == movieName);
                Console.WriteLine("Movie Deleted!");
            }
        }

    }
}
