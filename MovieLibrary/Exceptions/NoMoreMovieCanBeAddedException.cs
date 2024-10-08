using System;

namespace MovieAppLayered.Exceptions
{
    public class NoMoreMovieCanBeAddedException : Exception
    {
        public NoMoreMovieCanBeAddedException(string message) : base(message) { }
    }

}