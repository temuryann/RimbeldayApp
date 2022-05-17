using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Custom_Exceptions
{
    public class InvalidEmployeerNameException : Exception
    {
        public InvalidEmployeerNameException()
        {

        }

        public InvalidEmployeerNameException(string message) : base(message)
        {

        }
    }
}
