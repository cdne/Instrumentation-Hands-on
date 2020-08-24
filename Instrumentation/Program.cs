using System;
using System.Diagnostics;

namespace Instrumentation
{
    class Program
    {
        static void Main(string[] args)
        {
            if(EventLog.SourceExists("Demo", "DESKTOP-AOV7G7T"))
            {
                EventLog.CreateEventSource("Demo", "Application", "DESKTOP-AOV7G7T");
            }
            EventLog logDemo = new EventLog("Application", "DESKTOP-AOV7G7T", "Demo");
            logDemo.WriteEntry("Event written to application log", EventLogEntryType.Information, 234, Convert.ToInt16(3));
        }
    }
}
