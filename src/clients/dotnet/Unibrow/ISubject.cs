using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow
{
    public interface ISubject
    {
        KeyValuePair<string,string> Get();
    }
}
