using MovieAppLayered.Exceptions;
using MovieAppLayered.Models;
using MovieAppLayered.Services;
using System.Collections.Generic;
using System.Linq;

namespace MovieAppLayered.Controller
{
    public class MovieManager
    {
        private List<Movie> movies = new List<Movie>();

        public MovieManager()
        {
            movies = MovieSerializer.Deserialize();
        }

        public void Create(int movieId, string movieName, string movieGenre, int movieYear)
        {
            if (movies.Count >= 5)
            {
                throw new NoMoreMovieCanBeAddedException("Cannot add more movies. Maximum limit of 5 reached.");
            }

            if (movies.Any(m => m.MovieId == movieId))
            {
                throw new MovieAlreadyExistsException("A movie with this ID already exists.");
            }

            var movie = new Movie(movieId, movieName, movieGenre, movieYear);
            movies.Add(movie);
        }

        public Movie GetMovieById(int movieId)
        {
            var movie = movies.FirstOrDefault(m => m.MovieId == movieId);
            if (movie == null)
            {
                throw new NoSuchMovieIdExistsException($"No movie found with ID: {movieId}");
            }
            return movie;
        }

        public Movie GetMovieByName(string movieName)
        {
            var movie = movies.FirstOrDefault(m => m.MovieName.Equals(movieName, StringComparison.OrdinalIgnoreCase));
            if (movie == null)
            {
                throw new NoSuchMovieNameExistsException($"No movie found with name: {movieName}");
            }
            return movie;
        }

        public List<Movie> GetAllMovies()
        {
            return movies;
        }

        public void ClearMovieById(int movieId)
        {
            var movie = GetMovieById(movieId); // This will throw if the movie doesn't exist.
            movies.Remove(movie);
        }

        public void UpdateMovie(int movieId, string movieName, string movieGenre, int movieYear)
        {
            var movie = GetMovieById(movieId); // This will throw if the movie doesn't exist.

            movie.MovieName = movieName;
            movie.MovieGenre = movieGenre;
            movie.MovieYear = movieYear;
        }

        public void ClearAllMovies()
        {
            movies.Clear();
        }
    }
}
