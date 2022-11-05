using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class MillDataException : Exception
    {
        public MillDataException()
        {
        }

        public MillDataException(string? message) : base(message)
        {
        }

        public MillDataException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MillDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
