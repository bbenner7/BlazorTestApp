using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public interface IInstrumentation
    {
        public ActivitySource ActivitySource { get; }
    }
}
