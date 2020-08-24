using System;
using System.Diagnostics;
using System.Management;

namespace Management_Event_Log
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteToEventLog();
            Console.ReadLine();
        }

        public static void WriteToEventLog()
        {
            WqlEventQuery demoQuery = new WqlEventQuery("__InstanceCreationEvent", new TimeSpan(0, 0, 1));
            ManagementEventWatcher demoWatcher = new ManagementEventWatcher();
            demoWatcher.Query = demoQuery;
            demoWatcher.Options.Timeout = new TimeSpan(0, 0, 30);
            Console.WriteLine("Open an aplication to trigger an event");
            ManagementBaseObject e = demoWatcher.WaitForNextEvent();
            EventLog demoLog = new EventLog("Chap10demo");
            demoLog.Source = "Demo";
            String eventName = ((ManagementBaseObject)e["TargetInstance"])["Name"].ToString();
            demoLog.WriteEntry(eventName, EventLogEntryType.Information);
            demoWatcher.Stop();
        }
    }
}
