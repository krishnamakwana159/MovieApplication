using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            int choice;
            var dbContext = new DemoDbEntities();
            while(flag)
            {
                Console.WriteLine("Select an option you want to perform:");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Delete Movie by name");
                Console.WriteLine("3. List of Movies");
                Console.WriteLine("4. Add Actor");
                Console.WriteLine("5. Delete Actor by name");
                Console.WriteLine("6. List of Actors");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Movie Name : ");
                        string name = Console.ReadLine();

                        var check = dbContext.Movies.Where(t => t.MovieName == name);
                        Console.WriteLine(check.Count());
                        if (check.Count() >= 1)
                        {
                            Console.WriteLine("Movie is already in the list !!");
                        }
                        else
                        {
                            var movie = new Movy()
                            {
                                MovieName = name
                            };
                            try
                            {
                                dbContext.Movies.Add(movie);
                                dbContext.SaveChanges();
                                Console.WriteLine("Movie is added !!");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }

                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter movie name to delete : ");
                        string del = Console.ReadLine();
                        var delMovie = dbContext.Movies.Where(t => t.MovieName == del);
                       
                        if (delMovie.Count() == 1)
                        {
                            try
                            {
                                dbContext.Movies.Remove(dbContext.Movies.Single(t => t.MovieName == del));
                                dbContext.SaveChanges();
                                Console.WriteLine("Movie is removed !!");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Movie is not available in the list");                            
                        }
                        break;

                    case 3:
                        var movieList = dbContext.Movies;
                        try
                        {
                            foreach (var movy in movieList)
                            {

                                Console.WriteLine("Movie Name : " + movy.MovieName);                                
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter Actor Name : ");
                        string Aname = Console.ReadLine();

                        var checkActor = dbContext.Actors.Where(t => t.ActorName == Aname);
                        
                        if (checkActor.Count() >= 1)
                        {
                            Console.WriteLine("Actor is already in the list !!");
                        }
                        else
                        {
                            var actor = new Actor()
                            {
                                ActorName = Aname
                            };
                            try
                            {
                                dbContext.Actors.Add(actor);
                                dbContext.SaveChanges();
                                Console.WriteLine("Actor is added !!");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }

                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter Actor name to delete : ");
                        string delA = Console.ReadLine();
                        var delActor = dbContext.Actors.Where(t => t.ActorName == delA);

                        if (delActor.Count() == 1)
                        {
                            try
                            {
                                dbContext.Actors.Remove(dbContext.Actors.Single(t => t.ActorName == delA));
                                dbContext.SaveChanges();
                                Console.WriteLine("Actor is removed !!");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Actor is not available in the list");
                        }
                        break;

                    case 6:
                        var actorList = dbContext.Actors;
                        try
                        {
                            foreach (var actor in actorList)
                            {

                                Console.WriteLine("Actor Name : " + actor.ActorName);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;

                    case 7:
                        flag = false;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}