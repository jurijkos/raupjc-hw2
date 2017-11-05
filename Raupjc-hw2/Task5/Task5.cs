using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task5
{
    public class Klasa
    {
        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            Console.WriteLine("{0} Finished . Executing Thread : {1}", taskName, Thread.CurrentThread.ManagedThreadId);

        }
        public static void Part1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            LongOperation("A");
            LongOperation("B");
            LongOperation("C");
            LongOperation("D");
            LongOperation("E");
            stopwatch.Stop();
            Console.WriteLine("Synchronous long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);
        }

        public static void Part2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.Invoke(() => LongOperation("A"), 
                            () => LongOperation("B"), 
                            () => LongOperation("C"), 
                            () => LongOperation("D"), 
                            () => LongOperation("E"));
            stopwatch.Stop();
            Console.WriteLine("Parallel long operation calls finished {0} sec.", stopwatch.Elapsed.TotalSeconds);
        }
        public static void Part3()
        {
            int counter = 0;
            Parallel.For(0, 100000, (i) => 
            {
                Thread.Sleep(1);
                counter += 1;
            });
            Console.WriteLine("Counter should be 100000. Counter is {0}", counter);
        }
        public static void Part4()
        {
            int counter = 0;
            object objectUsedForLock = new object();

            Parallel.For(0, 100000, (i) =>
            {
                Thread.Sleep(1);
                lock (objectUsedForLock)
                {
                    counter += 1;
                }
            });
            Console.WriteLine("Counter should be 100000. Counter is {0}", counter);
        }
        public static void Part5()
        {
            List<int> results = new List<int>();
            Parallel.For(0, 100000, (i) => 
            {
                Thread.Sleep(1);
                results.Add(i * i);
            });
            Console.WriteLine("Bag length should be 100000. Length is {0}", results.Count);
        }
        public static void Part6()
        {
            ConcurrentBag<int> iterations = new ConcurrentBag<int>();
            Parallel.For(0, 100000, (i) => 
            {
                Thread.Sleep(1); iterations.Add(i);
            });
            Console.WriteLine("Bag length should be 100000. Length is {0}", iterations.Count);
        }
    }
}
