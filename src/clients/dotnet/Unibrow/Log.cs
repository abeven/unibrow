using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow
{
    using Syntax;
    public class Log
    {
        internal static Logger Instance { get; private set; }
        internal static Configuration Configuration { get; private set; }

        public static void Initialize(Configuration config)
        {
            Instance = new Logger(config);
            Configuration = config;
        }
        public static ILogWriter From(object sender)
        {
            return NewLogWriter();
        }
        public static ILogWriter From(ISource source)
        {
            return new LogWriter(Instance, source, Configuration.Subject);
        }
        public static ILogWriter Regarding(object subject)
        {
            return NewLogWriter();
        }
        public static ILogWriter Regarding(ISubject subject)
        {
            return new LogWriter(Instance, Configuration.Source, subject);
        }

        private static ILogWriter NewLogWriter()
        {
            return new LogWriter(Instance, Configuration.Source, Configuration.Subject);
        }
        public static void Trace(string msg, params object[] args) 
        {
            NewLogWriter().Trace(msg, args);
        }
        public static void Warn(string msg, params object[] args) 
        {
            NewLogWriter().Warn(msg, args);
        }
        public static void Fail(string msg, params object[] args)
        {
            NewLogWriter().Fail(msg, args);
            
        }
        
    }
}
