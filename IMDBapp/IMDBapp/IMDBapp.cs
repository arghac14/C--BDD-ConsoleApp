using System;
using IMDBapp.Domain;
using IMDBapp.Repository;
using System.Linq;
using System.Collections.Generic;
namespace IMDBapp
{
    class IMDBapp
    {
        static void ChangeConsoleColour()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        static void ResetConsoleColour()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        static List<Actors> AllActors(IMDBservices imdb)
        {
            int i = 1;
            foreach (var actor in imdb.GetAllActors())
            {
                Console.WriteLine("    {0}     {1}", i, actor.ActorName);
                i += 1;
            }
           
            return imdb.GetAllActors();
        }

        static List<Producers> AllProducers(IMDBservices imdb)
        {
            int i = 1;
            foreach (var producer in imdb.GetAllProducers())
            {
                Console.WriteLine("    {0}      {1}", i, producer.ProducerName);
                i += 1;
            }
            
            return imdb.GetAllProducers();
        }

        static void AddMovieToIMDB(IMDBservices imdb)
        {

            string movieName, year, plot;
            List<Actors> actors = new List<Actors>();
            Producers producers;

            Console.Write("\nName: ");
            movieName = Console.ReadLine();

            if (string.IsNullOrEmpty(movieName))
            {
                ChangeConsoleColour();
                Console.WriteLine("\nMovie name can't be empty!");
                ResetConsoleColour();
                return;
            }

            Console.Write("\nYear of Release (dd/mm/yy): ");
            year = Console.ReadLine();

            if (string.IsNullOrEmpty(year))
            {
                ChangeConsoleColour();
                Console.WriteLine("Release Date can't be empty!");
                return;
            }

            DateTime dDate;
    
            if (DateTime.TryParse(year, out dDate))
            {
                 String.Format("{0:d/MM/yyyy}", dDate);
            }
            
            else
            {
                Console.WriteLine("\nInvalid Date!");
                return;
            }

            Console.Write("\nPlot: ");
            plot = Console.ReadLine();

            if (string.IsNullOrEmpty(plot))
            {
                ChangeConsoleColour();
                Console.WriteLine("\nPlot can't be empty!");
                return;
            }

            // Taking Actors' list
            Console.WriteLine("\nActors' List: ");

            List<Actors> temp_actors_obj;
            temp_actors_obj = AllActors(imdb);

            if (!temp_actors_obj.Any())
            {
                ChangeConsoleColour();
                Console.WriteLine("\nActors' list is Empty! You need to add some actors first!");
                return;
            }

            List<String> temp_actors;
            temp_actors = temp_actors_obj.Select(x => x.ActorName).ToList();

            Console.Write("\nChoose Actors (By Sl. no.): ");
            List<string> actorList = new List<string>();
            List<int> actorsindex = new List<int>();
            string actorinput = Console.ReadLine();

            if (string.IsNullOrEmpty(actorinput))
            {
                ChangeConsoleColour();
                Console.WriteLine("\nActor list can't be empty!");
                return;
            }

            actorList = actorinput.Split(' ').ToList();

            if (actorList.Count > temp_actors_obj.Count || actorList.Count < 1)
            {
                ChangeConsoleColour();
                Console.WriteLine("\nChoose only valid actors from the list!");
                return;
            }

            foreach (var i in actorList)
            {
                if (Convert.ToInt32(i) > temp_actors_obj.Count || Convert.ToInt32(i) < 1)
                {
                    ChangeConsoleColour();
                    Console.WriteLine("\nChoose only valid actors from the list!");
                    return;
                }

                actorsindex.Add(Convert.ToInt32(i));
            }

            foreach (var i in actorsindex)
            {
                actors.Add(temp_actors_obj[i - 1]);
            }

            //Taking Producer

            int producerIndex;
            Console.WriteLine("Producers' list");

            List<Producers> temp_producers_obj;
            temp_producers_obj = AllProducers(imdb);


            if (!temp_producers_obj.Any())
            {
                ChangeConsoleColour();
                Console.WriteLine("\nProducers' list is Empty! You need to add some producers first!");
                return;
            }

            List<String> temp_producers;
            temp_producers = temp_producers_obj.Select(x => x.ProducerName).ToList();

            Console.Write("\nChoose a producer (By Sl. no.): ");
            var producerInput = Console.ReadLine();

            if (string.IsNullOrEmpty(producerInput))
            {
                ChangeConsoleColour();
                Console.WriteLine("\nProducer name can't be empty!");
                return;
            }
            producerIndex = Convert.ToInt32(producerInput);

            if(producerIndex > temp_producers.Count || producerIndex < 1)
            {
                ChangeConsoleColour();
                Console.WriteLine("\nChoose a valid producer from the list!");
                return;
            }

            producers = temp_producers_obj[producerIndex - 1];

            imdb.AddMovie(movieName, year, plot, actors, producers);

        }

        public static void AddActorToIMDB(IMDBservices imdb)
        {
            string actorName;
            string actorDOB;
            Console.Write("\nActor's Name: ");
            actorName = Console.ReadLine();
            Console.Write("Actor's Date of Birth(dd/mm/yyyy): ");
            actorDOB = Console.ReadLine();
            imdb.AddActor(actorName, actorDOB);
        }

        public static void AddProducerToIMDB(IMDBservices imdb)
        {
            string producerName;
            string producerDOB;
            Console.Write("\nProducer's Name: ");
            producerName = Console.ReadLine();
            Console.Write("Producer's Date of Birth(dd/mm/yyyy): ");
            producerDOB = Console.ReadLine();
            imdb.AddProducer(producerName, producerDOB);

        }

        public static void ListMovies(IMDBservices imdb)
        {
            int id = 1;
            Console.WriteLine("\n ID\t Movie \t\t\t Release Date  \tPlot\t\t\tProducer \t Actors \t ");
            foreach (var movie in imdb.GetAllMovies())
            {
                Console.Write(" {0}\t {1} \t {2}  \t{3}\t", id, movie.Name, movie.Year, movie.Plot);
                Console.Write(movie.Producer.ProducerName + "\t");
                foreach (var actor in movie.Actors.ToList())
                {
                    Console.Write("{0}, ", actor.ActorName);
                }
                id += 1;
                Console.WriteLine();
            }
        }

        public static void DeleteMovie(IMDBservices imdb)
        {
            ListMovies(imdb);
            Console.Write("\nEnter the ID of the movie that you want to delete from IMDB database: ");
            int movieID = Convert.ToInt32(Console.ReadLine());
            imdb.DeleteByID(movieID);
        }

        static void Main(string[] args)
        {

            int choice;
            IMDBservices imdb = new IMDBservices();


            // Adding few sample data
            imdb.AddActor("Matt Damon", "01/01/1980");
            imdb.AddActor("Christian Bale","01/01/1975");
            imdb.AddProducer("James Mangold", "01/01/1985");
            imdb.AddProducer("PC1", "03/03/2001");
            var movie = "Ford vs Ferrari";
            var year = "01/01/2019";
            var plot = "American Car Movie";
            var actors = new List<Actors>();
            var actor1 = new Actors();
            actor1.ActorName = "M Damon";
            actor1.ActorDOB = "01/01/1980";
            var actor2 = new Actors();
            actor2.ActorName = "C Bale";
            actor2.ActorDOB = "01/01/1975";
            actors.Add(actor1);
            actors.Add(actor2);
            var producer = new Producers();
            producer.ProducerName = "J Mangold";
            producer.ProducerDOB = "01/01/1985";
            imdb.AddMovie(movie,year,plot,actors,producer);
           
            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n|_____________IMDB________________|");
                Console.WriteLine("|          1. Add Movie           |");
                Console.WriteLine("|          2. List Movies         |");
                Console.WriteLine("|          3. Add Actor           |");
                Console.WriteLine("|          4. Add Producer        |");
                Console.WriteLine("|          5. Delete Movie        |");
                Console.WriteLine("|          6. Exit                |");
                Console.WriteLine("|_________________________________|");
                Console.Write("\nChoose any option and press Enter: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: AddMovieToIMDB(imdb);
                            break;
                    case 2: ListMovies(imdb);
                            break;
                    case 3: AddActorToIMDB(imdb);
                            break;
                    case 4: AddProducerToIMDB(imdb);
                            break;
                    case 5: DeleteMovie(imdb);
                            break;
                    case 6:
                            System.Environment.Exit(0);
                            break;
                    default: break;

                }

            }

        }
    }
}
