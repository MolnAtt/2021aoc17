using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021aoc17
{
    class Program
    {
        static void Main(string[] args)
        {
            /** /
            Téglalap célterület = new Téglalap(20,-10,30,-5);
            Szonda.rajzolás = true;
            Szonda.Indítása(célterület, new Vektor(7,2));
            Szonda.Indítása(célterület, new Vektor(6,3));
            Szonda.Indítása(célterület, new Vektor(9,0));
            Szonda.Indítása(célterület, new Vektor(17,-4));
            Szonda.Indítása(célterület, new Vektor(6,9));
            Szonda.Indítása(célterület, new Vektor(6,10));
            Szonda.Indítása(célterület, new Vektor(30,-10));
            
            List<Szonda> találatok = Szonda.Ratatata(célterület);
            Console.WriteLine($"talált szondaindítások száma: {találatok.Count()} \nA legmagasabbra jutó szondaindítás: {találatok.Max(sz=>sz.Legnagyobb_magasság())}");
            for (int i = 0; i < találatok.Count; i++)
                //Console.WriteLine($"{i+1}. {találatok[i].kezdősebesség}");
                Console.WriteLine($"{i+1}. {találatok[i].kezdősebesség}");
            
            /*/
            Téglalap célterület = new Téglalap(29,-248,73,-194);
            Szonda.rajzolás = true;
            Szonda.Indítása(célterület, new Vektor(10, 0));
            /*
            List<Szonda> találatok = Szonda.Ratatata(célterület);
            Console.WriteLine($"talált szondaindítások száma: {találatok.Count()} \nA legmagasabbra jutó szondaindítás: {találatok.Max(sz=>sz.Legnagyobb_magasság())}");
            */
            /**/
            Console.ReadLine();



        }
    }
}
