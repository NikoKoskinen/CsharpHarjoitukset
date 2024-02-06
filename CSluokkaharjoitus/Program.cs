using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSluokkaharjoitus
{
    class Hooman
    {
        // Define properties of Hooman ie. fields
        string name ="Essi Esimerkki";
        int age = 30;
        string gender = "Emäntä";

        // Constructor with zero arguments (default constructor w/o args)
        // No needed to define, will be created automatically
        public Hooman()
        {

        }

        // Constructor with one argument
        public Hooman(string name)
        {
            this.name = name;
        }

        // Constructor with two arguments
         public Hooman(string name, int age)
        {
            this.name=name;
            this.age = age;
        }

        // Constructor with three arguments
        public Hooman(string name, int age, string gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        // A method to say something
        public void SayOpinion()
        {
            Console.WriteLine("Perkeleen humppi");

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create (instantiate) a hooman object from Hooman class 
            Hooman owner = new Hooman("Ossi Omistaja", 35, "isäntä");
            
            // call the SayOpinion method
            owner.SayOpinion();

            // keep the window open until Enter pressed
            Console.ReadLine();
        }
    }
}
