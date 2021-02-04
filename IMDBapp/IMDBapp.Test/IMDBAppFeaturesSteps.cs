using System;
using System.Collections.Generic;
using System.Linq;
using IMDBapp;
using IMDBapp.Domain;
using IMDBapp.Repository;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace IMDBapp.Test
{
    [Binding]
    public class IMDBAppFeaturesSteps
    {

        private IMDBservices _imdbservice;

        private string _movieName, _year, _plot;
        private List<Actor> _actors;
        private Producer _producers;

        public List<Movie> movieList = new List<Movie>();
        public List<Actor> actorList = new List<Actor>();
        public Producer producerList = new Producer();

        List<ActorToMovie> actorToMovie;
        List<ProducerToMovie> producerToMovie;

        public IMDBAppFeaturesSteps()
        {
            _imdbservice = new IMDBservices();
            _actors = new List<Actor>();
            _producers = new Producer();

        }

        [BeforeScenario("list-movies", "add-movie-to-list")]
        public void AddingInitialData()
        {
            _imdbservice.AddActor("Matt Damon", "01/01/1980");
            _imdbservice.AddActor("Christian Bale", "01/01/1975");
            _imdbservice.AddProducer("James Mangold", "01/01/1985");
            _imdbservice.AddProducer("PC1", "03/03/2001");
        }

        [Given(@"movie name is ""(.*)""")]
        public void GivenMovieNameIs(string movieName)
        {
            _movieName = movieName;
        }
        
        [Given(@"year is ""(.*)""")]
        public void GivenYearIs(string year)
        {
            _year = year;
        }
        
        [Given(@"plot is ""(.*)""")]
        public void GivenPlotIs(string plot)
        {
            _plot = plot;
        }

        [Given(@"actor list is ""(.*)""")]
        public void GivenActorListIs(string actorIndices)
        {
            var temp_actors_obj = _imdbservice.GetAllActors();
            List<int> actorsindex = new List<int>();
            var actorList = actorIndices.Split(' ').ToList();
            foreach (var i in actorList)
            {
                actorsindex.Add(Convert.ToInt32(i));
            }
            foreach (var i in actorsindex)
            {
                _actors.Add(temp_actors_obj[i - 1]);
            }

        }

        [Given(@"producer list is ""(.*)""")]
        public void GivenProducerListIs(int producerIndex)
        {
            var movies_producers_obj = _imdbservice.GetAllMovies();
            var temp_producers_obj = _imdbservice.GetAllProducers();
            _producers = temp_producers_obj[producerIndex - 1];
        }

        [When(@"movie is added")]
        public void WhenMovieIsAdded()
        {
            _imdbservice.AddMovie(_movieName, _year, _plot, _actors, _producers);
            var movieList = _imdbservice.GetAllMovies();

        }

        [BeforeScenario("list-movies")]
        public void Adding()
        {
            // Adding Test Data for Checking 'list-movies' scenario
            var _movieName1 = "Ford vs Ferrari";
            var _year1 = "2019";
            var _plot1 = "American Car Movie";
            List<Actor> _actors1 = new List<Actor>();
            var _actor1 = new Actor()
            {
                Name = "Matt Damon",
                DOB = "01/01/1980"
            };
            var _actor2 = new Actor()
            {
                Name = "Christian Bale",
                DOB = "01/01/1975"
             };

            _actors1.Add(_actor1);
            _actors1.Add(_actor2);

            var _producer1 = new Producer()
            {
                Name = "James Mangold",
                DOB = "01/01/1985"
            };

            _imdbservice.AddMovie(_movieName1, _year1, _plot1, _actors1, _producer1);

            var _movieName2 = "Avengers";
            var _year2 = "2019";
            var _plot2 = "American Sci-Fi Movie";
            List<Actor> _actors2 = new List<Actor>();
            var _actor3 = new Actor()
            {
                Name = "RDJ",
                DOB = "01/01/1980"
            };
            var _actor4 = new Actor()
            {
                Name = "Chris Evans",
                DOB = "01/01/1975"
            };

            _actors2.Add(_actor1);
            _actors2.Add(_actor2);

            var _producer2 = new Producer()
            {
                Name = "Kevin Feigi",
                DOB = "01/01/1985"
            };

            _imdbservice.AddMovie(_movieName2, _year2, _plot2, _actors2, _producer2);

            ActorToMovie _actortomovie1 = new ActorToMovie()
            {
                Actor = _actor1.Name,
                DOB = _actor1.DOB,
                Movie = _movieName1
            };

            ActorToMovie _actortomovie2 = new ActorToMovie()
            {
                Actor = _actor2.Name,
                DOB = _actor2.DOB,
                Movie = _movieName1
            };
            ActorToMovie _actortomovie3 = new ActorToMovie()
            {
                Actor = _actor3.Name,
                DOB = _actor3.DOB,
                Movie = _movieName2
            };
            ActorToMovie _actortomovie4 = new ActorToMovie()
            {
                Actor = _actor4.Name,
                DOB = _actor4.DOB,
                Movie = _movieName2
            };

            ProducerToMovie _producertomovie1 = new ProducerToMovie()
            {
                Producer = _producer1.Name,
                DOB = _producer1.DOB,
                Movie = _movieName1
            };

            ProducerToMovie _producertomovie2 = new ProducerToMovie()
            {
                Producer = _producer2.Name,
                DOB = _producer2.DOB,
                Movie = _movieName2
            };

            actorToMovie = new List<ActorToMovie> { _actortomovie1, _actortomovie2, _actortomovie3, _actortomovie4 };
            producerToMovie = new List<ProducerToMovie> { _producertomovie1, _producertomovie2};

        }

        [When(@"all movies are fetched")]
        public void WhenAllMoviesAreFetched()
        {
            _imdbservice.GetAllMovies();
        }

        [Then(@"movie list should be-")]
        public void ThenMovieListShouldBe_(Table table)
        {
            table.CompareToSet(_imdbservice.GetAllMovies().ToList());
        }

        [Then(@"actor list should be-")]
        public void ThenActorListShouldBe_(Table table)
        {

            var actorList = _imdbservice.GetAllMovies().Select(x => x.Actors).ToList().LastOrDefault();
            table.CompareToSet(actorList);
        }

        [Then(@"actor list should show-")]
        public void ThenActorListShouldShow_(Table table)
        {

            var actorList = _imdbservice.GetAllMovies().Select(x => x.Actors).ToList().Last();
            table.CompareToSet(actorToMovie);
        }

        [Then(@"producer list should be-")]
        public void ThenProducerListShouldBe_(Table table)
        {
            var producerList = _imdbservice.GetAllMovies().Select(x => x.Producer).ToList();
            table.CompareToSet(producerList);
        }
       
        [Then(@"producer list should show-")]
        public void ThenProducerListShouldShow_(Table table)
        {
            var producerList = _imdbservice.GetAllMovies().Select(x => x.Producer).ToList();
            table.CompareToSet(producerToMovie);

        }

    }
}
