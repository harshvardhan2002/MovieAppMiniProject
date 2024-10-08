using MovieAppLayered.Controller;
using MovieAppLayered.Exceptions;
using MovieAppLayered.Services;
using System;

namespace MovieApplicationWithDLL.Presentation
{
    public class MovieStore
    {
        static MovieManager manager;

        public static void DisplayMenu()
        {
            manager = new MovieManager();

            while (true)
            {
                Console.WriteLine("Welcome to Movie App\nWhat do you wish to do:");
                Console.WriteLine("1. Add new movie");
                Console.WriteLine("2. Edit Movie");
                Console.WriteLine("3. Find Movie by Id");
                Console.WriteLine("4. Find Movie By Name");
                Console.WriteLine("5. Display All Movies");
                Console.WriteLine("6. Remove Movie By Id");
                Console.WriteLine("7. Clear All Movies");
                Console.WriteLine("8. Exit (occurs after serialization)");

                int choice = Convert.ToInt32(Console.ReadLine());
                DoTasks(choice);
            }
        }

        public static void DoTasks(int choice)
        {
            switch (choice)
            {
                case 1:
                    CreateMovie();
                    break;
                case 2:
                    EditMovie();
                    break;
                case 3:
                    DisplayMovieById();
                    break;
                case 4:
                    DisplayMovieByName();
                    break;
                case 5:
                    DisplayAllMovies();
                    break;
                case 6:
                    RemoveMovieById();
                    break;
                case 7:
                    ClearAllMovies();
                    break;
                case 8:
                    SerializeMoviesBeforeExit();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }

        public static void CreateMovie()
        {
            try
            {
                var movies = manager.GetAllMovies();
                if (movies.Count >= 5)
                {
                    Console.WriteLine("No more movies can be added.");
                    return;
                }
                Console.WriteLine("Enter Movie Id: ");
                int movieId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Movie Name: ");
                string movieName = Console.ReadLine();
                Console.WriteLine("Enter Movie Genre: ");
                string movieGenre = Console.ReadLine();
                Console.WriteLine("Enter Movie Year: ");
                int movieYear = Convert.ToInt32(Console.ReadLine());

                manager.Create(movieId, movieName, movieGenre, movieYear);
                Console.WriteLine("Movie added successfully!");
            }
            catch (NoMoreMovieCanBeAddedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (MovieAlreadyExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatOfInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public static void EditMovie()
        {
            try
            {
                Console.WriteLine("Enter Movie Id to edit: ");
                int movieId = Convert.ToInt32(Console.ReadLine());
                var movie = manager.GetMovieById(movieId);

                if (movie != null)
                {
                    Console.WriteLine("Enter new Movie Name: ");
                    string movieName = Console.ReadLine();
                    Console.WriteLine("Enter new Movie Genre: ");
                    string movieGenre = Console.ReadLine();
                    Console.WriteLine("Enter new Movie Year: ");
                    int movieYear = Convert.ToInt32(Console.ReadLine());

                    manager.UpdateMovie(movieId, movieName, movieGenre, movieYear);
                    Console.WriteLine("Movie updated successfully!");
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }
            }
            catch (NoSuchMovieIdExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatOfInputException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public static void DisplayMovieById()
        {
            try
            {
                Console.WriteLine("Enter Movie Id: ");
                int movieId = Convert.ToInt32(Console.ReadLine());
                var movie = manager.GetMovieById(movieId);
                Console.WriteLine(movie != null ? movie.ToString() : "Movie not found.");
            }
            catch (NoSuchMovieIdExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public static void DisplayMovieByName()
        {
            try
            {
                Console.WriteLine("Enter Movie Name: ");
                string movieName = Console.ReadLine();
                var movie = manager.GetMovieByName(movieName);
                Console.WriteLine(movie != null ? movie.ToString() : "Movie not found.");
            }
            catch (NoSuchMovieNameExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public static void DisplayAllMovies()
        {
            var movies = manager.GetAllMovies();
            if (movies.Count > 0)
            {
                foreach (var movie in movies)
                {
                    Console.WriteLine(movie);
                }
            }
            else
            {
                Console.WriteLine("No movies found.");
            }
        }

        public static void RemoveMovieById()
        {
            try
            {
                Console.WriteLine("Enter Movie Id to remove: ");
                int movieId = Convert.ToInt32(Console.ReadLine());
                manager.ClearMovieById(movieId);
                Console.WriteLine($"Movie with Id {movieId} removed.");
            }
            catch (NoSuchMovieIdExistsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public static void ClearAllMovies()
        {
            manager.ClearAllMovies();
            Console.WriteLine("All movies have been cleared.");
        }

        public static void SerializeMoviesBeforeExit()
        {
            MovieSerializer.Serialize(manager.GetAllMovies());
            Console.WriteLine("Movies have been serialized.");
        }
    
    /*public static void CreateMovie()
    {
        var movies = manager.GetAllMovies();
        if (movies.Count >= 5)
        {
            Console.WriteLine("No more movies can be added.");
            return;
        }
        Console.WriteLine("Enter Movie Id: ");
        int movieId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Movie Name: ");
        string movieName = Console.ReadLine();
        Console.WriteLine("Enter Movie Genre: ");
        string movieGenre = Console.ReadLine();
        Console.WriteLine("Enter Movie Year: ");
        int movieYear = Convert.ToInt32(Console.ReadLine());

        manager.Create(movieId, movieName, movieGenre, movieYear);
    }

    public static void EditMovie()
    {
        Console.WriteLine("Enter Movie Id to edit: ");
        int movieId = Convert.ToInt32(Console.ReadLine());
        var movie = manager.GetMovieById(movieId);

        if (movie != null)
        {
            Console.WriteLine("Enter new Movie Name: ");
            string movieName = Console.ReadLine();
            Console.WriteLine("Enter new Movie Genre: ");
            string movieGenre = Console.ReadLine();
            Console.WriteLine("Enter new Movie Year: ");
            int movieYear = Convert.ToInt32(Console.ReadLine());

            manager.UpdateMovie(movieId, movieName, movieGenre, movieYear);
            Console.WriteLine("Movie updated successfully!");
        }
        else
        {
            Console.WriteLine("Movie not found.");
        }
    }

    public static void DisplayMovieById()
    {
        Console.WriteLine("Enter Movie Id: ");
        int movieId = Convert.ToInt32(Console.ReadLine());
        var movie = manager.GetMovieById(movieId);
        Console.WriteLine(movie != null ? movie.ToString() : "Movie not found.");
    }

    public static void DisplayMovieByName()
    {
        Console.WriteLine("Enter Movie Name: ");
        string movieName = Console.ReadLine();
        var movie = manager.GetMovieByName(movieName);
        Console.WriteLine(movie != null ? movie.ToString() : "Movie not found.");
    }

    public static void DisplayAllMovies()
    {
        var movies = manager.GetAllMovies();
        if (movies.Count > 0)
        {
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }
        else
        {
            Console.WriteLine("No movies found.");
        }
    }

    public static void RemoveMovieById()
    {
        Console.WriteLine("Enter Movie Id to remove: ");
        int movieId = Convert.ToInt32(Console.ReadLine());
        manager.ClearMovieById(movieId);
        Console.WriteLine($"Movie with Id {movieId} removed.");
    }

    public static void ClearAllMovies()
    {
        manager.ClearAllMovies();
        Console.WriteLine("All movies have been cleared.");
    }

    public static void SerializeMoviesBeforeExit()
    {
        MovieSerializer.Serialize(manager.GetAllMovies());
        Console.WriteLine("Movies have been serialized.");
    }
    */
}
}
