using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using OfficeOpenXml;
using System.IO;

namespace GP_ExcelRäknare
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            FileInfo file = new FileInfo(fileName: @"dataTest.xlsx");
            List<int> things = new List<int>() { 3, 5, 7, 3, 2, 95, 4, 8, 53 };
            things.Add(9);
            await SaveExcelFile(file, things);
            SpeedCalculator();
        }

        private static async Task SaveExcelFile(FileInfo file, List<int> things)
        {
            DeleteIfExists(file);

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(Name: "dataCollection");

                ExcelRangeBase range = worksheet.Cells[Address: "A1"].LoadFromCollection(things, true);
                range.AutoFitColumns();

                await package.SaveAsync();
            }
        }

        private static void DeleteIfExists(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
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
                //Console.WriteLine(times[i]);
            }
            foreach (decimal time in times)
            {
                Console.WriteLine(time + "\n");
            }
            Console.Read();
        }

    }
}
