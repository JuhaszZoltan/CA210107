using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210107
{
    struct Allat
    {
        public string Nev { get; set; }
        public string Faj { get; set; }
    }
    class Ember
    {
        public string Nev { get; set; }
        public string Foglalkozas { get; set; }
    }

    class Program
    {
        static Random rnd = new Random();

        static void Main()
        {

            int[] t = new int[10];
            Feltolt(t, 10, 20);
            Kiir(t);

            //"átmenő paraméter": érték típusok is úgy működnek PARAMÉTERKÉNT,
            //mintha referencia típusok lennének:

            TimeSpan ts = new TimeSpan();
            ErteketAd(ref ts);
            Kiir(ts);

            //"kimenő paraméter": a függvény ignorálja a bemeneti paraméter értékét
            //(az sem baj, ha nincs), fiszont a függvény törzsén belül mindenképpen újra kell azt inicializálni
            //SZINTÉN referencia-ként kezeli az értéktípusokat

            DateTime dt;
            ErtekedAd(out dt);
            Kiir(dt);

            ErtekedAd(out DateTime masikDatum);
            Console.WriteLine(masikDatum);

            Console.Write("szám: ");
            int.TryParse(Console.ReadLine(), out int x);
            Console.WriteLine(x * 2);

            Console.Write("szám: ");
            int y;
            try
            {
                y = int.Parse(Console.ReadLine());
            }
            catch(Exception)
            {
                y = 0;
            }
            Console.WriteLine(y * 2);

            int[] tomb = { 54, 10, 4, 60, 31 };

            Array.Sort(tomb);

            Array.Resize(ref tomb, 3);

            Kiir(tomb);


            Console.ReadKey();
        }

        private static void Kiir(DateTime dt)
        {
            Console.WriteLine(dt.ToString("yyyy-MM-dd"));
        }

        private static void ErtekedAd(out DateTime dt)
        {
            dt = new DateTime(rnd.Next(1990, DateTime.Now.Year), rnd.Next(12) + 1, rnd.Next(28) + 1);
        }

        private static void Kiir(TimeSpan ts)
        {
            Console.WriteLine(ts);
        }

        private static void ErteketAd(ref TimeSpan ts)
        {

            ts = new TimeSpan(rnd.Next(24), rnd.Next(60), rnd.Next(60));
        }

        static void Feltolt(int[] t, int tol, int ig)
        {
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = rnd.Next(tol, ig + 1);
            }
        }

        static void Kiir(int[] t)
        {
            foreach (var e in t)
                Console.Write($"{e} ");
            Console.Write("\n");
        }






        static void Bev()
        {
            var kutya = new Allat() { Nev = "Bodri", Faj = "kutya" };
            var zoli = new Ember() { Nev = "Zoli", Foglalkozas = "programozó" };

            var k2 = kutya;
            var e2 = zoli;

            k2.Nev = "Csibész";
            e2.Nev = "Béla";

            Console.WriteLine(kutya.Nev);
            Console.WriteLine(zoli.Nev);
        }
    }
}
