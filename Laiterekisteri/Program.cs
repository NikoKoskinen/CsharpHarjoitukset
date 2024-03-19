using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

// Tiedostonkäsittelyyn ja serialisointiin tarvittavat kirjastot
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laiterekisteri
{
    // Base class for all devices
    // =========================================================================
    // Muista määrittää serialisoitavaksi
    [Serializable]
    class Device
    {
        // Purchase Fields
        // ----------------------------------------------------------------------
        string identity = "uusi laite";
        string dateBought = "1.1.2000";
        double price = 0.00d;
        int warranty = 12;

        // Tech fields
        // ---------------------------------------------------------------------
        int ram = 0;
        int storage = 0;
        string processorType = "N/A";

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

        public int Ram
        {
            get { return ram; }
            set { ram = value; }
        }

        public int Storage
        {
            get { return storage; }
            set { storage = value; }
        }

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
        public Device(string identity, string dateBought, double price, int warranty)
        {
            this.identity = identity;
            this.dateBought = dateBought;
            this.price = price;
            this.warranty = warranty;
        }

        // yliluokan metodit
        // ----------------------------------------------------------------------------
        public void ShowBoughtInfo()
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
        public void ShowTechInfo()
        {
            Console.WriteLine("Laitteiston tekniset tiedot");
            Console.WriteLine("--------------------");
            Console.WriteLine("koneen nimi: " + Identity);
            Console.WriteLine("Prosessori: " + processorType);
            Console.WriteLine("Keskusmuistin määrä: " + ram);
            Console.WriteLine("Levy tila: " + storage);

        }

        // Lasketaan takuun päättymispäivä, huomaa ISO-standardin mukaiset päivämäärät: vuosi-kuukausi-päivä
        public void CalculateWarrantyEndingDate()
        {
            // Muutetaan päivämäärä merkkijono päivämäärä-kellonaika-muotoon
            DateTime startDate = DateTime.ParseExact(this.dateBought, "yyyy-MM-dd", CultureInfo.InvariantCulture);


            // Lisätään takuun kesto
            DateTime endDate = startDate.AddMonths(this.Warranty);


            // Muunnetaan päivämäärä ISO-standardin mukaiseen muotoon
            endDate = endDate.Date;
            string isoDate = endDate.ToString("yyyy-MM-dd");
            Console.WriteLine("Takuu päättyy: " + isoDate);
        }
    }

    // tietokone luokka
    // ===============================================================================

    [Serializable]
    class Computer : Device
    {
        // fields & properties

        // constructor
        // ---------------------------------------------------------------------------
        public Computer() : base()
        { }

        public Computer(string identity) : base(identity)
        { }

        // Other methods

    }
    [Serializable]
    class Tablet : Device
    {
        // fields & properties
        // ---------------------------------------------------------------------------
        string operatingSystem;
        bool stylusEnabled = false;

        public string OperatingSystem
        {
            get { return operatingSystem; }
            set { operatingSystem = value; }
        }

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
            Console.WriteLine();
            Console.WriteLine("Tabletin erityitiedot");
            Console.WriteLine("---------------------");
            Console.WriteLine("Käyttöjärjestelmä: " + OperatingSystem);
            Console.WriteLine("Kynätuki: " + StylusEnabled);
        }

    }
    [Serializable]
    class Smartphone : Device
    {
        // fields & properties
        // ---------------------------------------------------------------------------
        string operatingSystem;
        int ram = 0;
        int storage = 0;
        string processorType = "N/A";
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
            Console.WriteLine();
            Console.WriteLine("Puhelimen erityistiedot");
            Console.WriteLine("---------------------");
            Console.WriteLine("Käyttöjärjestelmä: " + OperatingSystem);
            Console.WriteLine("Muistin määrä(GB): " + ram);
            Console.WriteLine("Prosessori: " + processorType);
            Console.WriteLine("Levytila: " + storage);
        }

    }
    // Pääohjelman luokka, josta tulee Program.exe
    // ===========================================
    class Program
    {
        // Ohjelman käynnistävä metodi
        // ---------------------------
        static void Main(string[] args)
        {
            // Määritellään binääridatan muodostaja serialisointia varte
            IFormatter formatter = new BinaryFormatter();

            // määritellään toinen file stream tietokoneiden tietojen pinotallennusta varten
            Stream stackWriteStream = new FileStream("ComputerStack.dat", FileMode.Create, FileAccess.Write);

            // Luodaan pinot laitteille, ei tarvetta tietää määrää etukäteen
            Stack<Computer> computerStack = new Stack<Computer>();

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
                        Console.Write("Ostopäivä muodossa vvvv-kk-pp: ");
                        computer.DateBought = Console.ReadLine();
                        Console.Write("Hankinta hinta: ");
                        string price = Console.ReadLine();

                        // Tehdään tietotyyppimuunnokset virheenkäsittelyrakenteessa
                        try
                        {
                            computer.Price = double.Parse(price);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Virheellinen hintatieto käytä desimaalipilkkua (,)" + ex.Message);
                            break;
                        }

                        Console.Write("Takuuaika kuukausina: ");
                        string warranty = Console.ReadLine();

                        try
                        {
                            computer.Warranty = int.Parse(warranty);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Virheellinen takuutieto, vain kuukausien määrä kokonaislukuna " + ex.Message);
                            break;
                        }

                        Console.Write("Prosessori tyyppi: ");
                        computer.ProcessorType = Console.ReadLine();
                        Console.Write("Muistin määrä (GB): ");
                        string ram = Console.ReadLine();

                        try
                        {
                            computer.Ram = int.Parse(ram);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Virheellinen muistin määrä, vain kokonaisluvut sallittu " + ex.Message);
                            break;
                        }

                        Console.Write("Tallennus kapasiteetti (GB): ");
                        string storage = Console.ReadLine();

                        try
                        {
                            computer.Storage = int.Parse(storage);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Virheellinen tallennustilan koko, vain kokonaisluvut sallittu " + ex.Message);
                            break;
                        }

                        // näytetään olion tiedot metodien avulla
                        computer.ShowBoughtInfo();
                        computer.ShowTechInfo();

                        try
                        {
                            computer.CalculateWarrantyEndingDate();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ostopäivä virheellinen " + ex.Message);
                            break;
                        }

                        // Lisätään tietokone pinoon
                        computerStack.Push(computer);

                        break;

                    case "2":
                        Console.WriteLine("Nimi: ");
                        string tabletName = Console.ReadLine();
                        Tablet tablet = new Tablet(tabletName);
                        Console.Write("Käyttöjärjestelmä: ");
                        tablet.OperatingSystem = Console.ReadLine();
                        Console.Write("Kynätuki: ");
                        string stylysEnabled = Console.ReadLine();

                        try
                        {
                            tablet.StylusEnabled = bool.Parse(stylysEnabled);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("" + ex.Message);
                        }

                        break;

                    case "3":
                        Console.WriteLine("Nimi: ");
                        string smartphoneName = Console.ReadLine();
                        Smartphone smartphone = new Smartphone(smartphoneName);
                        Console.Write("Käyttöjärjestelmä: ");
                        smartphone.OperatingSystem = Console.ReadLine();
                        Console.Write("Prosessori tyyppi: ");
                        smartphone.ProcessorType = Console.ReadLine();
                        Console.Write("Muistin määrä (GB): ");

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
                    // Kerrotaan pinossa olevien olioiden määrä
                    Console.WriteLine("Pinossa on nyt " + computerStack.Count + " tietokonetta");

                    // Tallennetaan koneiden tiedot pinomuodossa tiedostoon
                    formatter.Serialize(stackWriteStream, computerStack);
                    stackWriteStream.Close();

                    // Luodaan file stream tiedoston lukua varten
                    Stream readStackStream = new FileStream("ComputerStack.dat", FileMode.Open, FileAccess.Read);

                    // Määritellään uusi pino luettuja tietoja varten
                    Stack<Computer> savedStack;

                    // Deserialisoidaan tiedosto pinoon ja suljetaan tiedosto
                    savedStack = (Stack<Computer>)formatter.Deserialize(readStackStream);
                    readStackStream.Close();

                    // Pinoon tallennetaan vain todellisuudessa syötetyt koneet, voidaan lukea koko pino silmukassa
                    foreach (var item in savedStack)
                    {
                        Console.WriteLine("Koneen " + item.Identity + " takuu päättyy");
                        item.CalculateWarrantyEndingDate();
                    }

                    // Poistutaan ikuisesta silmukasta ja päätetään ohjelma
                    break;

                }
            }

            // Pidetään ikkuna auki, kunnes käyttäjä painaa <enter>
            Console.ReadLine();
        }
    }
}