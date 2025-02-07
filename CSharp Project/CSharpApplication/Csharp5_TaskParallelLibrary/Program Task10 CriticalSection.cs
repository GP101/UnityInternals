using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static int counter = 0;
        private static object lockObject = new object();

        static void Main(string[] args)
        {
            var intList = new List<int> { 1, 3, 5, 7, 9, 2, 4, 6, 8, 10 };
            Parallel.For(0, 5, (i) => {
                //lock (lockObject)
                //{
                //    counter += 1; // critical section
                //}
                Monitor.Enter(lockObject);
                counter += 1; // critical section
                Monitor.Exit(lockObject);
                Console.WriteLine(i);
            });

            Console.WriteLine($"counter = {counter}");
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
    /*
        0
        3
        4
        1
        2
        counter = 5
        Press any key to quit    
    */
}