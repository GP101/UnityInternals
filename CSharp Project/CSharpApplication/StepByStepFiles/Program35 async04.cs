using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CsharpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            var worker = new Worker();
            worker.DoWork();
            while (!worker.isComplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
    public class Worker
    {
        public bool isComplete { get; private set; }
        public async void DoWork()
        {
            isComplete = false;
            Console.WriteLine("Begin Work");
            Task t = LongOperation();
            await t;
            Console.WriteLine("End Work");
            isComplete = true;
        }

        private Task LongOperation()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Working");
                Thread.Sleep(2000);
            });
        }
    }
    /** output:
        Starting
        Begin Work
        Working
        ..................End Work
        Done
    */
}
