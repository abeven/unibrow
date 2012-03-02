using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow.Subjects
{
    public class StaticName : ISubject
    {
        string value;
        string key;
        public StaticName(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
        public KeyValuePair<string, string> Get()
        {
            return new KeyValuePair<string, string>(key, value);
        }
    }
}
