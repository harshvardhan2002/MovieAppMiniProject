using System;

namespace MovieAppLayered.Exceptions
{
    
    public class FormatOfInputException : Exception
    {
        public FormatOfInputException(string message) : base(message) { }
    }

}