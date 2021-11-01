using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Xunit.ConsoleClient
{
    public class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            // This code must not contain any references to code in any external assembly (or any code that references any code in any
            // other assembly) until AFTER the creation of the AssemblyHelper.
            var consoleLock = new object();
            var internalDiagnosticsMessageSink = DiagnosticMessageSink.ForInternalDiagnostics(consoleLock, args.Contains("-internaldiagnostics"), args.Contains("-nocolor"));

            using (AssemblyHelper.SubscribeResolveForAssembly(typeof(Program), internalDiagnosticsMessageSink))
	    return CallEntryPoint(consoleLock, args);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int CallEntryPoint(object consoleLock, string[] args)
        {
            return new ConsoleRunner(consoleLock).EntryPoint(args);
        }
    }
}
