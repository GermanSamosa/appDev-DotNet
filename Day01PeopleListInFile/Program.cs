using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
//include a toString method to display person info
/**
 * static void AddPersonInfo()
static void ListAllPersonsInfo()
static void FindPersonByName()
static void FindPersonYoungerThan()
 * **/
namespace Day01PeopleListInFile
{
    public class Person
    {
        public string Name; // Name 2-100 characters long, not containing semicolons
        public int Age; // Age 0-150
        public string City; // City 2-100 characters long, not containing semicolons

        //constructor
        public Person(string name, int age, string city)
        {
            Name = name;
            Age = age;
            City = city;
        }
        public string NameGS 
            { get; set; }
        public int AgeGS
            { get; set; }

        public string CityGS
            { get; set; }

        //the next part will formart in case values are problematic
        public override string ToString()
        {
            return ToString("G");
        }
        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format))
                format = "C";

            switch (format.ToUpperInvariant())
            {
                case "C":
                    return string.Format("{0}{1}", );
            }
        }



    }
    internal class Program
    {
        static List<Person> people = new List<Person>();

        static void Main(string[] args)
        {
            
            //start of program, read data from file
            //==> bring data into people list using following method
            //static void ReadAllPeopleFromFile()

            //display a menu to user 
            /**
             *
             *  1. Add person info
                2. List persons info
                3. Find a person by name
                4. Find all persons younger than age
                0. Exit
             * **/

            //end of program, dave data from people list onto the same file using following methid
            //static void SaveAllPeopleToFile()
            //data must be like;this;lol
            //dont be shy with creating methods
        }
    }
}
