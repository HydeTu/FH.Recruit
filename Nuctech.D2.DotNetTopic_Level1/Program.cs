using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuctech.D2.DotNetTopic
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Single Topic Program Start.".PadRight(40, '*'));

            Console.WriteLine("Run FizzBuzz App.");
            ITopicItem item = new FizzBuzzTopic();
            item.Run();

            Console.WriteLine();

            Console.WriteLine("Run SumMaxNumber App.");
            item = new SumMaxNumberTopic();
            item.Run();

            Console.WriteLine();

            Console.WriteLine("Single Topic Program End.".PadRight(40, '*'));

            Console.ReadLine();
        }
    }
}