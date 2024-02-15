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
    // =========================================================================
    class Device
    {
        //Fields
        //----------------------------------------------------------------------
        string identity = "uusi laite";
        string dateBought = "1.1.2000";
        double price = 0.00d;
        int warranty = 12;


        //Properties
        //----------------------------------------------------------------------
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
        int ram = 0;
        public int Ram
        {
            get { return ram; }
            set { ram = value; }
        }
        int storage = 0;
        public int Storage
        {
            get { return storage; }
            set { storage = value; }
        }
        string processorType;
        public string ProcessorType
        {
            get { return processorType; }
            set { processorType = value; }
        }

        // Defaul Constructor
        //----------------------------------------------------------------------------
        public Device()
        {
          
        }

        //Constructor with one argument
        //-----------------------------------------------------------------------------
        public Device(string identity)
        {
            this.identity = identity;
        }
        //Constructor with all arguments
        // ----------------------------------------------------------------------------
        public Device(string identity,string dateBought, double price, int warranty)
        {
            this.identity=identity;
            this.dateBought=dateBought; 
            this.price = price;
            this.warranty=warranty;
        }

        // yliluokan metodit
        // ----------------------------------------------------------------------------
        public void ShowDetailsInfo()
        {
            // luetaan laiteen ostotiedot sen kentistä, HUOM! (this)
            Console.WriteLine("Laitteen nimi: " + this.identity);
            Console.WriteLine("Ostopäivä: " + this.dateBought);
            Console.WriteLine("Takuu aika: " + this.warranty + " kk");
            Console.WriteLine("Osto hinta: " + this.price);
        }
        // Luetaan laitteen yleiset tekniset tiedot
        // ----------------------------------------------------------------------------
        public void ShowInfo()
        {
            Console.WriteLine("koneen nimi: " + Identity);
            Console.WriteLine("Prosessori: " + processorType);
            Console.WriteLine("Keskusmuistin määrä: " + ram);
            Console.WriteLine("Levy tila: " + storage);

        }
    }
    // tietokone luokka
    // ===============================================================================
    class Computer : Device
    {
        // fields & properties
      
        // constructor
        // ---------------------------------------------------------------------------
        public Computer() : base() 
        {}

        public Computer(string identity) : base(identity) 
        {}

        // Other methods
       
    }

    class Tablet : Device
    {
        // fields & properties
        // ---------------------------------------------------------------------------
        string operatingSystem;
        public string OperatingSystem
        {
            get { return operatingSystem; }
            set { operatingSystem = value; }
        }

        bool stylusEnabled = false;
        public bool StylusEnabled
        {
            get { return stylusEnabled; }
            set { stylusEnabled = value; }
        }

        // constructor
        //---------------------------------------------------------------------------
        public Tablet() : base()
        { }
        public Tablet(string Identity) : base(Identity)
        { }

        // other methods
        // ---------------------------------------------------------------------------
        public void TabletInfo()
        {
            Console.WriteLine("Käyttöjärjestelmä: " + OperatingSystem);
            Console.WriteLine("Kynätuki: " + stylusEnabled);
        }
    
    }

    class Smartphone : Device
    {
        // fields & properties
        string operatingSystem;
        public string OperatingSystem
        {
            get { return operatingSystem; }
            set { operatingSystem = value; }
        }
        // constructor
        public Smartphone() : base()
        { }
        public Smartphone(string identity) : base(identity)
        { }
        // other methods

    }




    class Program
    {
        static void Main(string[] args)
        {
            // let's create computer witch inherits device class properties & methods
            //=======================================================================
        Computer computer1 = new Computer();

            // let´s set processor properties
            // ----------------------------------------------------------------------
            computer1.ProcessorType = "intel I7 ";
            computer1.Ram = 16;
            computer1.DateBought = "13.2.2024";
            computer1.Price = 1999.00d;
            computer1.Warranty = 24;

            Console.WriteLine("Tietokone 1:n hankintatiedot");
            Console.WriteLine("----------------------------");
            computer1.ShowDetailsInfo();


            // luodaan uusi tietokone toisella konstruktorilla
            Computer computer2 = new Computer("Niko läppäri");
            computer2.ProcessorType = "Ryzen 7 5000series";
            computer2.Ram = 32;
            Console.WriteLine("Tietokone 2:n hankintatiedot");
            Console.WriteLine("----------------------------");
            computer2.ShowDetailsInfo();

            // luodaan uusi tabletti
            Tablet tablet1 = new Tablet("Nikon iPad");
            tablet1.DateBought = "10.10.2022";
            tablet1.OperatingSystem = "IOS 17.2";
            tablet1.StylusEnabled = true;

            // näytetään tietoja metodien avulla
            Console.WriteLine("tabletti 1:n tekniset tiedot");
            Console.WriteLine("----------------------------");
            tablet1.ShowDetailsInfo();
            tablet1.TabletInfo();
            





            Console.ReadLine();
        }
    }
}