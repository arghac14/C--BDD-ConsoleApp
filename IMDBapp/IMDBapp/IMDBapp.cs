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

        static List<Actor> AllActors(IMDBservices imdb)
        {
            int i = 1;
            imdb.GetAllActors().ForEach(actor =>
            {
                Console.WriteLine("    {0}     {1}", i, actor.Name);
                i += 1;
            });

            return imdb.GetAllActors();
        }

        static List<Producer> AllProducers(IMDBservices imdb)
        {
            int i = 1;
            imdb.GetAllProducers().ForEach(producer =>
            {
                Console.WriteLine("    {0}      {1}", i, producer.Name);
                i += 1;
            });

            return imdb.GetAllProducers();
        }

        static void AddMovieToIMDB(IMDBservices imdb)
        {

            string movieName, year, plot;
            List<Actor> actors = new List<Actor>();
            Producer producers;

            Console.Write("\nName: ");
            movieName = Console.ReadLine();

            if (string.IsNullOrEmpty(movieName))
            {
                ChangeConsoleColour();
                Console.WriteLine("\nMovie name can't be empty!");
                ResetConsoleColour();
                return;
            }

            Console.Write("\nYear of Release (yyyy): ");
            year = Console.ReadLine();

            if (string.IsNullOrEmpty(year))
            {
                ChangeConsoleColour();
                Console.WriteLine("Release Date can't be empty!");
                return;
            }


            if (Convert.ToInt32(year) < 1000 || Convert.ToInt32(year) > 2021)
            {
                ChangeConsoleColour();
                Console.WriteLine("\nInvalid Year!");
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

            List<Actor> temp_actors_obj;
            temp_actors_obj = AllActors(imdb);

            if (!temp_actors_obj.Any())
            {
                ChangeConsoleColour();
                Console.WriteLine("\nActors' list is Empty! You need to add some actors first!");
                return;
            }

            List<String> temp_actors;
            temp_actors = temp_actors_obj.Select(x => x.Name).ToList();

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

            actorList.ForEach(i =>
            {
                if (Convert.ToInt32(i) > temp_actors_obj.Count || Convert.ToInt32(i) < 1)
                {
                    ChangeConsoleColour();
                    Console.WriteLine("\nChoose only valid actors from the list!");
                    return;
                }

                actorsindex.Add(Convert.ToInt32(i));
            });

            actorsindex.ForEach(i =>
            {
                actors.Add(temp_actors_obj[i - 1]);
            });

            //Taking Producer

            int producerIndex;
            Console.WriteLine("Producers' list");

            List<Producer> temp_producers_obj;
            temp_producers_obj = AllProducers(imdb);


            if (!temp_producers_obj.Any())
            {
                ChangeConsoleColour();
                Console.WriteLine("\nProducers' list is Empty! You need to add some producers first!");
                return;
            }

            List<String> temp_producers;
            temp_producers = temp_producers_obj.Select(x => x.Name).ToList();

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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nData Added!");

        }

        public static void AddActorToIMDB(IMDBservices imdb)
        {
            string actorName;
            string actorDOB;

            Console.Write("\nActor's Name: ");
            actorName = Console.ReadLine();

            if (string.IsNullOrEmpty(actorName))
            {
                ChangeConsoleColour();
                Console.WriteLine("\nActor name can't be empty!");
                return;
            }

            Console.Write("Actor's Date of Birth(dd/mm/yyyy): ");
            actorDOB = Console.ReadLine();

            if (string.IsNullOrEmpty(actorDOB))
            {
                ChangeConsoleColour();
                Console.WriteLine("\nActor's DOB can't be empty!");
                return;
            }

            imdb.AddActor(actorName, actorDOB);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nData Added!");
        }

        public static void AddProducerToIMDB(IMDBservices imdb)
        {
            string producerName;
            string producerDOB;

            Console.Write("\nProducer's Name: ");
            producerName = Console.ReadLine();

            if (string.IsNullOrEmpty(producerName))
            {
                ChangeConsoleColour();
                Console.WriteLine("\nProducer name can't be empty!");
                return;
            }


            Console.Write("Producer's Date of Birth(dd/mm/yyyy): ");
            producerDOB = Console.ReadLine();

            if (string.IsNullOrEmpty(producerDOB))
            {
                ChangeConsoleColour();
                Console.WriteLine("\nProducer's DOB can't be empty!");
                return;
            }

            imdb.AddProducer(producerName, producerDOB);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nData Added!");

        }

        public static void ListMovies(IMDBservices imdb)
        {
            int id = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n ID\t Movie \t\t\t Release Year  \tPlot\t\t\tProducer \t Actors \t \n");
            ResetConsoleColour();
            if (!imdb.GetAllMovies().Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo movies in database!");
                return;
            }

            imdb.GetAllMovies().ForEach(movie =>
            {
                Console.Write(" {0}\t {1} \t\t {2}  \t\t{3}\t\t", id, movie.Name, movie.Year, movie.Plot);
                Console.Write(movie.Producer.Name + "\t");
                foreach (var actor in movie.Actors.ToList())
                {
                    Console.Write("{0}, ", actor.Name);
                }
                id += 1;
                Console.WriteLine();
            });
        }

        public static void DeleteMovie(IMDBservices imdb)
        {
            ListMovies(imdb);
            Console.Write("\nEnter the ID of the movie that you want to delete from IMDB database: ");
            int movieID = Convert.ToInt32(Console.ReadLine());
            imdb.DeleteByID(movieID);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nData deleted!");
        }

        static void Main(string[] args)
        {

            int choice;
            IMDBservices imdb = new IMDBservices();
           
                while (true)
                {
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\t\t\t\t\t _______________IMDB______________");
                    Console.WriteLine("\t\t\t\t\t|          1. Add Movie           |");
                    Console.WriteLine("\t\t\t\t\t|          2. List Movies         |");
                    Console.WriteLine("\t\t\t\t\t|          3. Add Actor           |");
                    Console.WriteLine("\t\t\t\t\t|          4. Add Producer        |");
                    Console.WriteLine("\t\t\t\t\t|          5. Delete Movie        |");
                    Console.WriteLine("\t\t\t\t\t|          6. Exit                |");
                    Console.WriteLine("\t\t\t\t\t|_________________________________|");
                    Console.Write("\nChoose any option and press Enter: ");

                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddMovieToIMDB(imdb);
                            break;
                        case 2:
                            ListMovies(imdb);
                            break;
                        case 3:
                            AddActorToIMDB(imdb);
                            break;
                        case 4:
                            AddProducerToIMDB(imdb);
                            break;
                        case 5:
                            DeleteMovie(imdb);
                            break;
                        case 6:
                            System.Environment.Exit(0);
                            break;
                        default: break;

                    }
                }
                catch(Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input! \n\n{0}", e.Message);
                    ResetConsoleColour();
                    continue;
                    
                }
             }
         }

    }
}
