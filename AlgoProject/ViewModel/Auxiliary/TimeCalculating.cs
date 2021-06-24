using System;
using System.Diagnostics;

namespace AlgoProject.ViewModel
{
    public class TimeCalculating
    {
        /// <summary>Calculating the speed of the array.</summary>
        /// <param name="Sort">Tested sort type.</param>
        /// <param name="array">Array with random digits.</param>
        /// <returns> String in the format 00:00:00:00.</returns>
        public string Calculate(Action<int[]> Sort, int[] array)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            Sort(array);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            return $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:00}";
        }
    }
}
