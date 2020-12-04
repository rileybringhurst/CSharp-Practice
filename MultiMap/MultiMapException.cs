using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Util
{
    public class MultiMapException : Exception
    {

        public MultiMapException() : base() { }

        public MultiMapException(string exMessage):base(exMessage){}

        public MultiMapException(Exception ExceptionParam, string ExMessage) : base(ExMessage, ExceptionParam) { }

    }
}
