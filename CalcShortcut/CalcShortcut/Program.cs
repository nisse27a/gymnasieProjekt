using System;
using System.Diagnostics;

namespace CalcShortcut
{
    class Program
    {
        static void Main(string[] args)
        {
            int frameFactor = 4; //slowmotion or fps depending on function
            Func<int, bool> timeCalc;
            while(true)
            {
                Console.Clear();
                Console.WriteLine("1> Speed Calculator\n" +
    "2> Air Time\n" +
    "3> Frame Measure");
                switch (Input(3))
                {
                    case 1:
                        timeCalc = SpeedCalculator;
                        break;
                    case 2:
                        timeCalc = AirTime;
                        break;
                    case 3:
                        timeCalc = FrameMeasure;
                        Console.WriteLine("1> 30fps\n" +
                            "2> 60fps");
                        switch(Input(2))
                        {
                            case 1:
                                frameFactor = 30;
                                break;
                            case 2:
                                frameFactor = 60;
                                break;
                        }
                        break;
                    default:
                        timeCalc = AirTime;
                        break;
                }
                Console.Clear();
                bool repeat = true;
                while (repeat)
                {
                    repeat = timeCalc(frameFactor);
                }
            }
        }
        static int Input(int max)
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || !(input >= 1 & input <= max))
            {
                Console.WriteLine($"Only 1 to {max} allowed");
            }
            return input;
        }

        static bool SpeedCalculator(int slowmotionFactor)
        {
            ConsoleKey ck;
            Console.WriteLine("---Speed---");
            ck = Console.ReadKey().Key;
            if (ck == ConsoleKey.D0)
            {
                return false;
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Started Timer");
            ck = Console.ReadKey().Key;
            if (ck == ConsoleKey.D0)
            {
                return false;
            }
            stopwatch.Stop();
            Console.WriteLine("Ended timer");
            Console.WriteLine($"{Math.Round((3.6+0.64)/(stopwatch.ElapsedMilliseconds/(1000f*slowmotionFactor)),2)} m/s");
            Console.WriteLine($"{Math.Round(stopwatch.ElapsedMilliseconds/(1000f*slowmotionFactor),2)}s");
            return true;
        }
        static bool AirTime(int slowmotionFactor)
        {
            ConsoleKey ck;
            Console.WriteLine("---Air---");
            Stopwatch stopwatch = new Stopwatch();
            ck = Console.ReadKey().Key;
            if (ck == ConsoleKey.D0)
            {
                return false;
            }
            stopwatch.Start();
            Console.WriteLine("Started Timer");
            ck = Console.ReadKey().Key;
            if (ck == ConsoleKey.D0)
            {
                return false;
            }
            stopwatch.Stop();
            Console.WriteLine("Ended Timer");
            Console.WriteLine($"{Math.Round(stopwatch.ElapsedMilliseconds / (1000f * slowmotionFactor), 2)}s");
            return true;
        }
        static bool FrameMeasure(int framerate = 30)
        {
            Console.WriteLine("---Frame---");
            int tick = 0;
            ConsoleKey ck;
            do
            {
                ck = Console.ReadKey().Key;
                if(ck==ConsoleKey.OemMinus)
                {
                    tick++;
                    Console.WriteLine($"<{tick}");
                } 
                else if (ck==ConsoleKey.D0)
                {
                    return false;
                }
            }
            while (ck == ConsoleKey.OemMinus);
            double time = (double)tick / framerate;
            double speed = (3.6 + 0.64) / ((float)tick / framerate);
            Console.WriteLine($"Time> {Math.Round(time,2)}\n" +
                $"Speed> {Math.Round(speed,2)} m/s");
            return true;
        }
    }
}
