using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow.Sources
{
    public class StaticName : ISource
    {
        private string name;
        public StaticName(string name)
        {
            this.name = name;
        }
        public string Get()
        {
            return this.name;
        }
    }
}
