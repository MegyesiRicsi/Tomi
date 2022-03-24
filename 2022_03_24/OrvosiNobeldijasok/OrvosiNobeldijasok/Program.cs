using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OrvosiNobeldijasok
{
    class Elethossz
    {
        private int Tol { get; set; }
        private int Ig { get; set; }
        public int ElethosszEvekben => Tol == -1 || Ig == -1 ? -1 : Ig - Tol;

        public bool IsmertAzElethossz => ElethosszEvekben != -1;

        public Elethossz(string SzuletesHalalozas)
        {
            string[] m = SzuletesHalalozas.Split('-');
            try
            {
                Tol = int.Parse(m[0]);
            }
            catch (Exception)
            {
                Tol = -1;
            }
            try
            {
                Ig = int.Parse(m[1]);
            }
            catch (Exception)
            {
                Ig = -1;
            }
        }
    }
            class Valami
            {
                public int dij, szh;
                public string nev, kod;
                //Év;Név;SzületésHalálozás;Országkód
                public Valami(string sor)
                {
                    var s = sor.Split(';');
                    dij = Convert.ToInt32(s[0]);
                    nev = s[1];
                    szh = new Elethossz(s[2]).ElethosszEvekben;
                    kod = s[3];
                }
            }
    
    class Program
    {

        static void Main(string[] args)
        {

            StreamReader sr = new StreamReader("orvosi_nobeldijak.txt");
            List<Valami> lista = new List<Valami>();
            string elso = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                lista.Add(new Valami(sr.ReadLine()));
            }
            sr.Close();
            Console.WriteLine($"{lista.Count()} díjazott volt.");
            int rak = (from sor in lista orderby sor.dij select sor.dij).Last();
            Console.WriteLine(rak);
            int rak2 = 0;
            foreach (var item in lista)
            {
                if (rak2 < item.dij)
                {
                    rak2 = item.dij;
                }
            }
            for (int i = 0; i < lista.Count; i++)
            {
                if (rak2 < lista[i].dij)
                {
                    rak2 = lista[i].dij;
                }
            }
            Console.Write("be kod");
            string bek = Console.ReadLine();
            var els = (from sor in lista where sor.kod == bek select sor);//5. feladat
            var lista2 = new List<Valami>();
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].kod==bek)
                {
                    lista2.Add(lista[i]);
                }
            }

            if (els.Count()==1)
            {
                Console.WriteLine(els.First().dij);
                Console.WriteLine(els.First().nev);//teljes adat
            }
            else if (els.Count()>1)
            {
                Console.WriteLine(els.Count());//mennyi darab van benne
            }
            else
            {
                Console.WriteLine("nem volt benne");
            }
            /* string[] adatok = File.ReadAllLines("orvosi_nobeldijak.txt");
             Valami[] adatok_uj = new Valami[adatok.Length];
             int i, rak = 0;
             for ( i = 1; i < adatok.Length-1; i++)
             {
                string[] sor = adatok[i].Split(';');
                adatok_uj[i].Dij = Convert.ToInt32(sor[0]);
                adatok_uj[i].Nev = sor[1];
                adatok_uj[i].Szülhal = Convert.ToInt32(sor[2]);
                adatok_uj[i].Kod =sor[3];

                if (rak< adatok_uj[i].Dij)
                 {
                     rak = adatok_uj[i].Dij;
                 }
             }
           
            Console.WriteLine($"{adatok.Length} díjazott volt.");
            Console.WriteLine($"{rak}");
            */




            Console.ReadLine();
        }
    }
}