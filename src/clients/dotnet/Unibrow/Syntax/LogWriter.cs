using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow.Syntax
{
    public class LogWriter : ILogWriter
    {
        Logger logger;
        ISource source;
        ISubject subject;

        public LogWriter(Logger logger, ISource source, ISubject subject)
        {
            this.logger = logger;
            this.source = source;
            this.subject = subject;
        }


        private void Write(string msg, params object[] args )
        {
            var entry = new Entry { TimeStamp = DateTime.Now, Message = msg, Source = source.Get() };
            entry.Subject = new KeyValuePair<string, string>[] { subject.Get() };
            logger.Write(entry);
        }

        public void Trace(string msg, params object[] args)
        {
            Write(msg, args);
        }

        public void Warn(string msg, params object[] args)
        {
            Write(msg, args);
        }

        public void Fail(string msg, params object[] args)
        {
            Write(msg, args);
        }

        public ILogWriter From(ISource source)
        {
            this.source = source;
            return this;
        }

        public ILogWriter Regarding(ISubject subject)
        {
            this.subject = subject;
            return this;
        }


        public ILogWriter From(object source)
        {
            return this;
        }

        public ILogWriter Regarding(object subject)
        {
            return this;
        }
    }
}
