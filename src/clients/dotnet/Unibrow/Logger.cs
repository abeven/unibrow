using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
namespace Unibrow
{
    public class Logger : ILogger
    {
        Configuration config;
        public Logger(Configuration config)
        {
            this.config = config;
        }

        public void Write(Entry entry)
        {
            foreach (var recipient in config.Recipients)
                recipient.BeginReceive(entry);
        }

    }
}
