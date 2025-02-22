﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Result<int> intResult = new Result<int>{Success = true, Data = 9};
            Result<string> stringResult = new Result<string> { Success = false, Data = "error" };
            Console.WriteLine("Success = {0}, Data = {1}", intResult.Success, intResult.Data);
            Console.WriteLine("Success = {0}, Data = {1}", stringResult.Success, stringResult.Data);

            Print(intResult);
        }
        static void Print<T>(Result<T> result)
        {
            Console.WriteLine("Success = {0}, Data = {1}", result.Success, result.Data);
        }
    }
    public class Result<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }
}
