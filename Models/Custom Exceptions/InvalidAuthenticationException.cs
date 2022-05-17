using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Custom_Exceptions
{
    public class InvalidAuthenticationException : Exception
    {
        public InvalidAuthenticationException()
        {

        }

        public InvalidAuthenticationException(string message) : base(message)
        {

        }
    }
}
