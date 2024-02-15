using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
        // fields & properties
        string processorType;
        public string ProcessorType 
        {   
            get { return processorType; } 
            set {  processorType = value; } 
        }
        int ram;
        public int Ram 
        {   
            get { return ram; } 
            set {  ram = value; }
        }
        int storage;
        public int Storage 
        { 
            get { return storage; } 
            set {  storage = value; }
        }
        // constructor
        public Computer() : base() 
        {}

        public Computer(string identity) : base(identity) 
        {}

        // Other methods
        
    }

    class Smartphone : Device
    {
        // fields & properties

        // constructor

        // other methods

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
           
            // let's create computer witch inherits device class properties & methods
        Computer computer1 = new Computer();

            // let´s set processor properties
            computer1.ProcessorType = "intel I7 ";
            computer1.Ram = 16;

            Console.WriteLine("New computer name is " + computer1.Identity + " and there is " + computer1.ProcessorType + 
                " Prosessori ja " + computer1.Ram + " Gb keskusmuistia");
            // luodaan uusi tietokone toisella konstruktorilla
            Computer computer2 = new Computer("Niko läppäri");
            computer2.ProcessorType = "Ryzen 7 5000series";
            computer2.Ram = 32;


            Console.ReadLine();
        }
    }
}