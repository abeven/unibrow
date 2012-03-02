using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow.Sources
{
    public class Delegated : ISource
    {
        private Func<string> func;
        public Delegated(Func<string> func)
        {
            this.func = func;
        }
        public string Get()
        {
            return func();
        }
    }
}
