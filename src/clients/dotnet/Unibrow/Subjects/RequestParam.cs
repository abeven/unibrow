using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow.Subjects
{
    public class RequestParam : ISubject
    {
        private string key;
        private string name;
        private string defaultValue;

        public RequestParam(string key)
            : this(key,key) { }
        public RequestParam(string key, string name)
            : this(name, key, "<undefined>") { }
        public RequestParam(string key, string name, string defaultValue)
        {
            this.key = key;
            this.name = name;
            this.defaultValue = defaultValue;
        }
        public KeyValuePair<string,string> Get()
        {
            var value = System.Web.HttpContext.Current.Request[name] ?? defaultValue;
            return new KeyValuePair<string, string>(this.key, value);
        }
    }
}
