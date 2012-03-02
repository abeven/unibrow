using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow
{
    public class Entry
    {
        public DateTime TimeStamp { get; set; }
        public string Source { get; set; }
        public IEnumerable<KeyValuePair<string,string>> Subject { get; set; }
        public string Message { get; set; }
    }
}
