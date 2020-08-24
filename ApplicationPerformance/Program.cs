using System;
using System.Diagnostics;
using System.Timers;

namespace ApplicationPerformance
{
    class Program
    {
        private static PerformanceCounter HeapCounter = null;
        private static PerformanceCounter ExceptionCounter = null;
        private static Timer DemoTimer;


        private static void OnTick(object source, ElapsedEventArgs args)
        {

        }

        static void Main(string[] args)
        {
            DemoTimer = new Timer(3000);
            DemoTimer.Elapsed += new ElapsedEventHandler(OnTick);
            DemoTimer.Enabled = true;
            HeapCounter = new PerformanceCounter(".NET CLR MEMORY", "# bytes in all Heaps")
            {
                InstanceName = "_Global_"
            };
            ExceptionCounter = new PerformanceCounter(".NET CLR Exceptions", "# of Exceps Thrown")
            {
                InstanceName = "_Global_"
            };

            Console.WriteLine("Press [Enter] to Quit Program");
            Console.ReadLine();
            Console.WriteLine("# of Bytes in all Heaps : " + HeapCounter.NextValue().ToString());
            Console.WriteLine("# of Framework Exceptions Thrown : " + ExceptionCounter.NextValue().ToString());






        }
    }
}
