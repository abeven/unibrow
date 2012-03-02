using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow.Syntax
{
    public interface ILogWriter
    {
        ILogWriter From(ISource source);
        ILogWriter Regarding(ISubject subject);
        ILogWriter From(object source);
        ILogWriter Regarding(object subject);
        //ILogWriter If(bool condition);
        void Trace(string msg, params object[] args);
        void Warn(string msg, params object[] args);
        void Fail(string msg, params object[] args);
    }
}
