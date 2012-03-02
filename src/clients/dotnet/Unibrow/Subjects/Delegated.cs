using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow.Subjects
{
    public class Delegated : ISubject
    {
        Func<KeyValuePair<string,string>> func;
        public Delegated(Func<KeyValuePair<string, string>> func)
        {
            this.func = func;
        }


        public KeyValuePair<string, string> Get()
        {
            return func();
        }
    }
}
