using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LetterMastersAPI.Exceptions

{
    public class EncoderException : Exception
    {
        public EncoderException()
        { }

        public EncoderException(string message)
            : base(message)
        { }

        public EncoderException(string message, Exception innerException)
            : base(message, innerException)
        { }

    }
}
