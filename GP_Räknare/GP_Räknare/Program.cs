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
            SpeedCalculator();
        }
        static void SpeedCalculator(int distanceInterval = 6, int intervals = 3)
        {
            Stopwatch stopwatch = new Stopwatch();
            decimal[] times = new decimal[intervals], speeds = new decimal[intervals];
            Console.Write("Tap any key to enter interval> ");
            Console.ReadKey();
            for (int i = 0; i < intervals; i++)
            {
                stopwatch.Reset();
                Console.Clear();
                stopwatch.Start();
                Console.Write("Tap any key to enter interval> ");
                Console.ReadKey();
                stopwatch.Stop();
                times[i] = stopwatch.ElapsedMilliseconds;
            }
            foreach(decimal time in times)
            {
                Console.WriteLine(time + "\n");
            }
            Console.Read();
        }
    }
}
