using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSluokkaharjoitus
{
    class Hooman
    {
        // Define properties of Hooman ie. fields
        string name ="essi esimerkki";
        int age = 30;
        string gender = "Emäntä";

        // Constructor with zero arguments
        Hooman()
        {

        }

        // Constructor with one argument
        Hooman(string name)
        {
            this.name = name;
        }

        // Constructor with two arguments
        Hooman(string name, int age)
        {
            this.name=name;
            this.age = age;
        }

        // Constructor with three arguments
        Hooman(string name, int age, string gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
