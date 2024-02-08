using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laiterekisteri
{
    // Base class for all devices
    class Device
    {
        //Fields
        //---------------
        string identity = "uusi laite";
        string dateBought = "1.1.2000";
        double price = 0.00d;
        int warranty = 12;

        //Properties
        //--------------
        public string Identity
        {
            get { return identity; }
            set { identity = value; }
        }

        public string DateBought
        {
            get { return dateBought; }
            set { dateBought = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Warranty
        {
            get { return warranty; }
            set { warranty = value; }
        }

        // Defaul Constructor
        public Device()
        {

        }

        //Constructor with one argument
        //--------------------------------
        public Device(string identity)
        {
            this.identity = identity;
        }
        //Constructor with all arguments
        public Device(string identity,string dateBought, double price, int warranty)
        {
            this.identity=identity;
            this.dateBought=dateBought; 
            this.price = price;
            this.warranty=warranty;
        }

        //Other methods
    }
    class Computer : Device
    {
        
    }

    class Smartphone : Device
    {
        
    }

    class Tablet : Device
    {
        
    }


    class Program
    {
        static void Main(string[] args)
        {
        // Let's create an test object from the device class with default constructor (0 parameters)
        Device device1 = new Device();
            Console.WriteLine(device1.Identity);

        // Let's create another device with identity parameter
        Device device2 = new Device("toinen laite");
            Console.WriteLine(device2.Identity);

            // Let's create one more device with all parameters
        Device device3 = new Device("Kolmas kone","8.2.2000",750.00d, 24);
            Console.WriteLine(device3.Identity);
            Console.WriteLine(device3.Price);
           



            Console.ReadLine();
        }
    }
}