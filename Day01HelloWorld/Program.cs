using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("What is your nAME?");
                string name = Console.ReadLine();
                Console.WriteLine("What is your age?");
                string ageStr = Console.ReadLine();
                if (!int.TryParse(ageStr, out int age))

                {
                    Console.WriteLine("invalid numerical input");
                    return;
                }
                Console.WriteLine($"Hello {name}! You are {age} y/o!");
            }
            finally
            {
            Console.ReadKey();
            }
           
        }
    }
}
