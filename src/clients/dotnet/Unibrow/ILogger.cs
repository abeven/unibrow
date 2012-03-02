using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow
{
    public interface ILogger
    {
        void Write(Entry entry);
    }
}
