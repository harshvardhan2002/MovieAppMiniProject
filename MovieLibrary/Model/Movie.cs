using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppLayered.Models
{
    [Serializable]
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieGenre { get; set; }
        public int MovieYear { get; set; }

        public Movie(int movieId, string movieName, string movieGenre, int movieYear)
        {
            MovieId = movieId;
            MovieName = movieName;

            MovieGenre = movieGenre;
            MovieYear = movieYear;
        }
        public override string ToString()
        {
            return $"Movie Id: {MovieId}\n" +
                $"Movie Name: {MovieName}\n" +
                $"Movie Genre: {MovieGenre}\n" +
                $"Movie Year: {MovieYear}\n";
        }
    }
}