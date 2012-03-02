using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections.Specialized;

namespace Unibrow.Recipients
{
    public class Server : IRecepient
    {
        JavaScriptSerializer json;
        WebClient web;
        Uri uri;
        public string Name { get; private set; }
        public Server(Uri baseUri, string name)
        {
            this.web = new WebClient();
            this.json = new JavaScriptSerializer();
            this.uri = new Uri(baseUri, "/log");
            this.Name = name;
            
        }

        private static double ToJSTimeStamp(DateTime d2)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            d2 = d2.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);

            return ts.TotalMilliseconds;
        }

        public void BeginReceive(Entry entry)
        {
            var msg = new
            {
                ts = ToJSTimeStamp(entry.TimeStamp),
                message = entry.Message,
                subject = new Dictionary<string,string>(),
                source = entry.Source
            };

            foreach(var sub in entry.Subject)
                msg.subject.Add(sub.Key, sub.Value);

            var payload = new NameValueCollection();
            payload.Add("entry", json.Serialize(msg));
            this.web.UploadValuesAsync(this.uri, "POST", payload);
            
        }
    }
}
