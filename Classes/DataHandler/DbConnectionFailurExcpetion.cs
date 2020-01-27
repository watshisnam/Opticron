using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Opticron.Classes
{
    public class DbConnectionFailurExcpetion : Exception
    {
        public DbConnectionFailurExcpetion()
        {
        }

        public DbConnectionFailurExcpetion(string message) : base(message)
        {
        }

        public DbConnectionFailurExcpetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbConnectionFailurExcpetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
