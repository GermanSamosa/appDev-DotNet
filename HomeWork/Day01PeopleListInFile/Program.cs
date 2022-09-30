using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        public string _name; // Name 2-100 characters long, not containing semicolons
        public int _age; // Age 0-150
        public string _city; // City 2-100 characters long, not containing semicolons

        //constructor
        public Person(string name, int age, string city)
        {
            _name = name;
            _age = age;
            _city = city;
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name.Length < 2 || _name.Length > 100)
                    throw new ArgumentException(" Name must be 2-100 characters long, not containing semicolons");
                _name = value;
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                if (value < 0 || value > 150)
                    throw new ArgumentException("whoaa that's either too young or waay too old!");
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                if (_city.Length < 2 || _city.Length > 100)
                    throw new ArgumentException("City must be 2-100 characters long, not containing semicolons");
            }
        }
        //the next part will formart
        public override string ToString()
        {
                return String.Format("This is {0}, they are {1} years old and they are situated in {2}.", _name, _age, _city);
           
        }
    }
    internal class Program
    {
        static List<Person> people = new List<Person>();

        static void AddPersonInfo()
        {
            //
        }
        static void ListAllPersonsInfo()
        {
            //
        }
        static void FindPersonByName()
        {
            //
        }
        static void FindPersonYoungerThan()
        {
            //
        }
        static void ReadAllPeopleFromFile()
        {
            //first priority, load up info into people list
        }
        static void SaveAllPeopleToFile()
        {
            //end the program with this, save info back onto file
        }
        static void DisplayMenu()
        {
            //display a menu to user 
            /**
             *
             *  1. Add person info
                2. List persons info
                3. Find a person by name
                4. Find all persons younger than age
                0. Exit
             * **/
        }

        static void Main(string[] args)
        {

            //start of program, read data from file
            //==> bring data into people list using following method
            //static void ReadAllPeopleFromFile()

            //test person
            Person person = new Person("1", 151, "mtl");
            //Console.Write(person.ToString()); proper validation
            Console.ReadKey();


            //end of program, dave data from people list onto the same file using following methid
            //static void SaveAllPeopleToFile()
            //data must be like;this;lol
            //dont be shy with creating methods
        }
    }
}
