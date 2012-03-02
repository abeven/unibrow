using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unibrow.Sources
{
    public class Process : StaticName
    {
        public Process() : base(System.Diagnostics.Process.GetCurrentProcess().ProcessName) { }
    }
}
