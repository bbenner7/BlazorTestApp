using System.Diagnostics;

namespace Logging
{
    public class Instrumentation : IInstrumentation, IDisposable
    {
        internal const string SourceName = "BlazorTestApp";
        internal const string SourceVersion = "0.1.0";

        public Instrumentation()
        {
            ActivitySource = new ActivitySource(SourceName, SourceVersion);

        }

        public ActivitySource ActivitySource { get; }

        public void Dispose()
        {
            ActivitySource.Dispose();
        }
    }
}
