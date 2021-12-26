using System;
using System.Collections.Generic;
using System.Linq;

namespace _2021aoc17
{
    class Szonda
    {
        public static bool rajzolás = false;
        public bool eltalálta { get; private set; }
        private Vektor poz;
        private HashSet<Vektor> pálya;
        private Vektor v;
        public Vektor kezdősebesség { get; }

        public Szonda(Vektor vektor, Vektor kezdősebesség)
        {
            poz = vektor;
            v = kezdősebesség;
            this.kezdősebesség = kezdősebesség;
            pálya = new HashSet<Vektor> { poz };
        }

        internal static Szonda Indítása(Téglalap célterület, Vektor vektor)
        {
            Szonda szonda = new Szonda(vektor);
            {
                Console.WriteLine($"==== kezdősebesség: {vektor} ====");
                szonda.Kilő(ref célterület);
                if (rajzolás)
                    szonda.Diagnosztika(ref célterület);
                if (szonda.eltalálta)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Talált");
                }
                else
                { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nem talált");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"legmagasabb elért magasság: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(szonda.Legnagyobb_magasság());

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            return szonda;
        }

        public static List<Szonda> Ratatata(Téglalap célterület)
        {

            List<Szonda> találatok = new List<Szonda>();
            Vektor futó_v = new Vektor(1, -célterület.bay); // biztosan adható jobb alsó becslés is, de az input szélessége nem olyan vészesen nagy. A felső becslést az adja, hogy az ennél magasabb kezdősebességű indítások biztosan átugorják az árkot.

            while (futó_v != célterület.ja)
            {
                Szonda szonda = Szonda.Indítása(célterület, futó_v);
                if (szonda.eltalálta) 
                    találatok.Add(szonda);
                if (futó_v.x == célterület.jfx) // biztosan adható jobb vízszintes felső becslés is
                    futó_v.Soremelés(1);
                else futó_v.x_Növelése();
            }
            Szonda utolsó_szonda = Szonda.Indítása(célterület, futó_v);
            if (utolsó_szonda.eltalálta)
                találatok.Add(utolsó_szonda);
            return találatok;
        }

        public Szonda(Vektor kezdősebesség) : this(new Vektor(0, 0), kezdősebesség) { }
        
        public void Kilő(ref Téglalap célterület)
        {
            while (!(célterület.Tartalmazza(poz) || célterület.Túlment(poz)))
            {
                Lép();
                pálya.Add(poz);
            }

            eltalálta = célterület.Tartalmazza(poz);
        }

        public int Legnagyobb_magasság() => pálya.Max(v => v.y);

        public void Diagnosztika(ref Téglalap célterület)
        { 
            int bax = new List<int>{ célterület.bax, 0, pálya.Min(v=>v.x)}.Min();
            int bay = new List<int>{ célterület.bay, 0, pálya.Min(v=>v.y)}.Min();
            int jfx = new List<int>{ célterület.jfx, 0, pálya.Max(v=>v.x)}.Max();
            int jfy = new List<int>{ célterület.jfy, 0, pálya.Max(v=>v.y)}.Max();
            int bfx = bax;
            int bfy = jfy;
            int jax = jfx;
            int jay = bay;

            Vektor futó_pont = new Vektor(bfx, bfy);
            Vektor ja = new Vektor(jax, jay);
            Vektor origó = new Vektor(0, 0);

            while (futó_pont != ja)
            {
                Kiírás(ref futó_pont, ref origó, ref célterület);
                if (futó_pont.x == jfx)
                {
                    futó_pont.Soremelés(bax);
                    Console.WriteLine();
                }
                else futó_pont.x_Növelése();
            }
            Kiírás(ref futó_pont, ref origó, ref célterület);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

        }

        private void Kiírás(ref Vektor futó_pont, ref Vektor origó, ref Téglalap célterület) => Kiírás(futó_pont == origó ? "S" : (pálya.Contains(futó_pont) ? "#" : (célterület.Tartalmazza(futó_pont) ? "T" : ".")));
        private void Kiírás(string jel, ConsoleColor szín) { Console.ForegroundColor = szín; Console.Write(jel); }
        private void Kiírás(string jel) => Kiírás(jel, színszótár[jel]);
        private static Dictionary<string, ConsoleColor> színszótár = new Dictionary<string, ConsoleColor> { { "#", ConsoleColor.Red }, { ".", ConsoleColor.Blue }, { "T", ConsoleColor.Green }, { "S", ConsoleColor.White } };

        private void Lép()
        {
            poz.Hozzáad(v);
            v.x_Nullához_közelítése();
            v.y_Csökkentése();
        }

    }
}