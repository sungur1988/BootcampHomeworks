using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MessageLogger messageLogger = new MessageLogger();
            messageLogger.Log("message");
            Console.WriteLine("Hello World!");
        }
    }
}
