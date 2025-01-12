﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

class Program1
{
    delegate void HelloDelegate();

    static void Main( string[] args )
    {
        HelloDelegate hello1 = new HelloDelegate(SayHello);
        HelloDelegate hello2 = SayHello;
        hello1.Invoke();
        hello2.Invoke();
        hello1();
        Test(hello1);

        hello1 += SayHello;

        Sample sam = new Sample();
        HelloDelegate hello3 = sam.SayHello;
        sam();
    }
    static void SayHello()
    {
        Console.WriteLine("Hello World");
    }
    static void Test(HelloDelegate del)
    {
        del();
    }
    class Sample
    {
        public void SayHello()
        {
            Console.WriteLine("Sample Hello World");
        }
    }
}
