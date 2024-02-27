using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine("Laitteiston osto tiedot");
            Console.WriteLine("--------------------");
            Console.WriteLine("Laitteen nimi: " + this.identity);
            Console.WriteLine("Ostopäivä: " + this.dateBought);
            Console.WriteLine("Takuu aika: " + this.warranty + " kk");
            Console.WriteLine("Osto hinta: " + this.price);
        }
        // Luetaan laitteen yleiset tekniset tiedot
        // ----------------------------------------------------------------------------
        public void ShowInfo()
        {
            Console.WriteLine("Laitteiston tekniset tiedot");
            Console.WriteLine("--------------------");
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
        public void PhoneInfo()
        {
            Console.WriteLine("Käyttöjärjestelmä: " + OperatingSystem);
            Console.WriteLine();
        }

    }




    class Program
    {
        static void Main(string[] args)
        {
            // Ikuinen silmukka pääohjelman käynnissä pitämiseen
            while (true)
            {
                Console.WriteLine("Minkä laitteen tiedot tallentaan?");
                Console.Write("1 tietokone, 2 tabletti, 3 puhelin ");
                string type = Console.ReadLine();

                // Luodaan Switch-case-rakenne vaihtoehdoille
                switch (type)
                {
                    case "1":

                        // kysytään käyttäjältä tietoja laitteistoita ja luodaan uusi tietokone olio
                        Console.WriteLine("Nimi: ");
                        string computerName = Console.ReadLine();
                        Computer computer = new Computer(computerName);
                        Console.Write("Ostopäivä: ");
                        computer.DateBought = Console.ReadLine();
                        Console.Write("Hankinta hinta: ");
                        string price = Console.ReadLine();

                        try
                        {
                            computer.Price = double.Parse(price);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Virheellinen hintatieto" + ex.Message);
                        }

                        Console.Write("Takuuaika kuukausina: ");
                        computer.Warranty = int.Parse(Console.ReadLine());
                        Console.Write("Prosessori tyyppi: ");
                        computer.ProcessorType = Console.ReadLine();
                        Console.Write("Muistin määrä (GB): ");
                        computer.Ram = int.Parse(Console.ReadLine());
                        Console.Write("Tallennus kapasiteetti (GB): ");
                        computer.Storage = int.Parse(Console.ReadLine());

                        // näytetään olion tiedot metodien avulla
                        computer.ShowDetailsInfo();
                        computer.ShowInfo();
                        break;

                    case "2":
                        Console.WriteLine("Nimi: ");
                        string tabletName = Console.ReadLine();
                        Tablet tablet = new Tablet(tabletName);
                        Console.Write("Käyttöjärjestelmä: ");
                        tablet.OperatingSystem = Console.ReadLine();
                        Console.Write("Kynätuki: ");
                        tablet.StylusEnabled = bool.Parse(Console.ReadLine());

                        break;

                    case "3":
                        Console.WriteLine("Nimi: ");
                        string smartphoneName = Console.ReadLine();
                        Smartphone smartphone = new Smartphone(smartphoneName);
                        Console.Write("Käyttöjärjestelmä: ");
                        smartphone.OperatingSystem = Console.ReadLine();

                        break;

                    default:
                        Console.WriteLine("Virheellinen valinta, anna pelkkä numero");
                        break;
                }

                // Ohjelman sulkeminen: poistutaan ikuisesta silmukasta
                Console.WriteLine("Haluatko jatkaa K/e");
                string continueAnswer = Console.ReadLine();
                continueAnswer = continueAnswer.Trim();
                continueAnswer = continueAnswer.ToLower();

                if (continueAnswer == "e")
                {
                    break;
                }
            }




            // pidetään ikkuna auki
            Console.ReadLine();
        }
    }
}