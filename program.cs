using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Muuttujat mielialan- ja kunnon tallentamiseen
            string vireysStr;
            int vireys;
            string uniStr;
            int uni;
            string nalkaStr;
            int nalka;
            int moodIndex;

            // Kysytään käyttäjältä miltä hänestä tuntuu ja tallennetaan vastaukset
            Console.WriteLine("Hyvää huomenta, miltä sinusta tuntuu tänään?");
            Console.WriteLine();
            Console.WriteLine("Arvioi vireyttäsi asteikolla 1-5 1:unelias 5:täynnä virtaa");
            vireysStr = Console.ReadLine();
            Console.WriteLine("Miten hyvin nukuit asteikolla 1-5 1:huonosti, 5:kuin tukki");
            uniStr = Console.ReadLine();
            Console.WriteLine("Miten nälkäinen olet asteikolla 1-5 1: kuolen nälkään 5: Aivan täynnä");
            nalkaStr = Console.ReadLine();

            // Muutetaan vastaukset numeromuotoon
            vireys = int.Parse(vireysStr);
            uni = int.Parse(uniStr);
            nalka = int.Parse(nalkaStr);

            // Lasketaan mielialaindeksi
            moodIndex = vireys + uni + nalka;

            // Tulostetaan käyttäjän antamat vastaukset
            Console.WriteLine("vireyspisteet: " + vireysStr + ", unipisteet: " + uniStr + " , nälkäpisteet: " + nalkaStr);

            Console.WriteLine();
            Console.WriteLine("Mielialaindeksisi on: " + moodIndex);
    
            // Pidetään konsoli-ikkuna auki, kunnes painetaan <Enter>
            Console.ReadLine();
        }
    }
}
