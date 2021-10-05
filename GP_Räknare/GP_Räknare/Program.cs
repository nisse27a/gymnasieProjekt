using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GP_Räknare
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        static void SpeedCalculator(int distanceInterval = 6, int intervals = 3)
        {
            Stopwatch stopwatch = new Stopwatch();
            decimal[] times = new decimal[intervals], speeds = new decimal[intervals];
            for (int i = 0; i < intervals; i++)
            {
                stopwatch.Reset();
                Console.Write("Tap any key to enter interval> ");
                Console.ReadKey();
                Console.Clear();
                stopwatch.Start();
                Console.Write("Tap any key to enter interval> ");
                Console.ReadKey();
                stopwatch.Stop();
                times[i] = stopwatch.ElapsedMilliseconds;
            }
        }
    }
}
