using System;

namespace MovieAppLayered.Exceptions
{
    public class NoSuchMovieNameExistsException : Exception
    {
        public NoSuchMovieNameExistsException(string message) : base(message) { }
    }
}