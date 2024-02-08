using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSluokkaharjoitus
    // Super/Base/Parent class definition
{
    class Hooman
    {
        // Define properties of Hooman ie. fields
        public string name = "Essi Esimerkki";
        public int age = 30;
        public string gender = "Emäntä";

        // Constructor with zero arguments (default constructor w/o args)
        // No needed to define, will be created automatically
        public Hooman()
        {

        }

        // A method to say something
        public void SayOpinion()
        {
            Console.WriteLine("Perkeleen humppi");

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
    }
    class Pet
    {
        public virtual void Eats()
        {
            Console.WriteLine("Syö ruokaa");
        }
    }
    class Hare : Pet
    {
        public override void Eats()
        {
            Console.WriteLine("syö porkkanoita");
        }
    }

    // Sub/Devired/Child class inherits Hooman class
    class CatOwner : Hooman
    {
        public new void SayOpinion()
        {
            Console.WriteLine("Kissat ovat itsenäisiä ja V-päitä");
        }
    }

    class DogOwner : Hooman

    {
        public new void SayOpinion()
        {
            Console.WriteLine("Koira on uskollinen ja luotettava kumppani, ihmisen paras ystävä");
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

            String who = owner.name;

            Console.WriteLine("Totesi " + who);

            // Create a new catowner object
            CatOwner catOwner = new CatOwner();

            // Use catowners SayOpinion method
            catOwner.SayOpinion();

            // Create a new dog owner and call SayOpinion method
            DogOwner dogOwner = new DogOwner();
            dogOwner.SayOpinion();

            // create new pet and call Eats method
            Pet pet = new Pet();
            pet.Eats();

            Hare hare = new Hare();
            hare.Eats();

            // keep the window open until Enter pressed
            Console.ReadLine();

        }
    }
}
