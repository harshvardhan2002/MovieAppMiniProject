using System;

namespace MovieAppLayered.Exceptions
{
    public class MovieAlreadyExistsException : Exception
    {
        public MovieAlreadyExistsException(string message) : base(message) { }
    }
}