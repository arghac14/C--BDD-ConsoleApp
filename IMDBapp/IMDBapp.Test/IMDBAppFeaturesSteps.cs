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
        private List<Actors> _actors;
        private Producers _producers;

        public List<Movies> movieList = new List<Movies>();
        public List<Actors> actorList = new List<Actors>();
        public Producers producerList = new Producers();


        public IMDBAppFeaturesSteps()
        {
            _imdbservice = new IMDBservices();
            _actors = new List<Actors>();
            _producers = new Producers();

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

        //[Given(@"actor list is-")]
        //public void GivenActorListIs_(Table table)
        //{
        //    _actors = table.CreateSet<Actors>().ToList();
        //}

        //[Given(@"producer list is-")]
        //public void GivenProducerListIs_(Table table)
        //{
        //    _producers = table.CreateInstance<Producers>();

        //}

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
            var _movieName = "Ford vs Ferrari";
            var _year = "01/01/2019";
            var _plot = "American Car Movie";
            List<Actors> _actors = new List<Actors>();
            var _actor1 = new Actors();
            _actor1.ActorName = "Matt Damon";
            _actor1.ActorDOB = "01/01/1980";
            var _actor2 = new Actors();
            _actor2.ActorName = "Christian Bale";
            _actor2.ActorDOB = "01/01/1975";
            _actors.Add(_actor1);
            _actors.Add(_actor2);
            var _producer = new Producers();
            _producer.ProducerName = "James Mangold";
            _producer.ProducerDOB = "01/01/1985";

            _imdbservice.AddMovie(_movieName, _year, _plot, _actors, _producer);
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

        [Then(@"producer list should be-")]
        public void ThenProducerListShouldBe_(Table table)
        {
            var producerList = _imdbservice.GetAllMovies().Select(x => x.Producer).ToList();
            table.CompareToSet(producerList);
        }
    }
}
