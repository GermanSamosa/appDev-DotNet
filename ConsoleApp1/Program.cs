using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SocietyDbContext ctx = new SocietyDbContext();
                Random random = new Random();
                //INSERT: equivalent of insert
                Person p1 = new Person { Name = "Jerry" + random.Next(100), Age = random.Next(100)};
                ctx.People.Add(p1);
                ctx.SaveChanges();
                Console.WriteLine("record added");
            }
            catch (System.Exception)
            {
                Console.WriteLine("error");
            }
            finally
            {
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }
    }
}
