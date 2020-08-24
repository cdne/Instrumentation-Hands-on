using System;
using System.Diagnostics;

namespace Application_Event_Log
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog myLog = new EventLog("X", "localhost", "Demo");
            Trace.AutoFlush = true;
            using (EventLogTraceListener myListener = new EventLogTraceListener(myLog))
            {
            }
            Trace.WriteLine("This is a test");
        }
    }
}
