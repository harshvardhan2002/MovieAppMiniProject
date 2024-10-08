using System;

namespace MovieAppLayered.Exceptions
{
    public class NoSuchMovieIdExistsException : Exception
    {
        public NoSuchMovieIdExistsException(string message) : base(message)
        {
        }
    }


}