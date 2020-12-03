using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kosarlabda
{
    class Program
    {
        Merkozes merkozes;
        
        internal Merkozes Merkozes { get => merkozes; set => merkozes = value; }


        static void Main(string[] args)
        {
            List<Merkozes> merkozesek = new List<Merkozes>();

            List<string> sorok = File.ReadAllLines("eredmenyek.csv", Encoding.UTF8).ToList();
            foreach (string item in sorok)
            {
                if (!item.Contains("pont"))
                {
                    merkozesek.Add(new Merkozes(item));

                }
            }

            List<Merkozes> otthon = merkozesek.FindAll(x => x.Hazai == "Real Madrid");

            List<Merkozes> vendeg = merkozesek.FindAll(x => x.Idegen == "Real Madrid");
            
            Console.WriteLine($"3.feladat: Real Madrid: Hazai: {otthon.Count()} Idegen: {vendeg.Count()}");

            

            var hazai = from item in merkozesek
                        where item.Hazai == "Real Madrid"
                        select item;

            var idegen = from item in merkozesek
                         where item.Idegen == "Real Madrid"
                         select item;

            Console.WriteLine($"3.feladat: hazai: {hazai.Count()}, idegen: {idegen.Count()}");


            Console.WriteLine();

            bool dontetlenVanE = merkozesek.Exists(x => x.Hazai_pont == x.Idegen_pont);

            Console.WriteLine("4.feladat: Volt dontetlen? "+ (dontetlenVanE ?  "igen" : "nem"));



            var dontetlen = from item in merkozesek
                            where item.Hazai_pont == item.Idegen_pont
                            select item;
            Console.WriteLine($"4.feladat: Volt döntetlen? { (dontetlen.Count() > 0 ? "igen" : "nem")}" );
            Console.WriteLine();

            Merkozes barcelona = merkozesek.Find(x => x.Hazai.Contains("Barcelona"));
            Console.WriteLine("5. feladat: A barcelonai csapat neve: " + barcelona.Hazai);
            Console.WriteLine("5. feladat: A barcelonai csapat neve: " + merkozesek.Find(x => x.Hazai.Contains("Barcelona")).Hazai);


            var barcelonaiCsapat = from item in merkozesek
                                   where item.Hazai.Contains("Barcelona")
                                   select item.Hazai;

            Console.WriteLine("5. feladat: barcelonai csapat neve : " + barcelonaiCsapat.ToList()[0]);

            Console.WriteLine();

            List<Merkozes> meccsek = merkozesek.FindAll(x => x.Idopont == DateTime.Parse("2004.11.21"));
            Console.WriteLine("6. feladat:");
            foreach (Merkozes item in meccsek)
            {
                Console.WriteLine($"\t{item.Hazai}-{item.Idegen} : ({item.Hazai_pont}:{item.Idegen_pont})");
            }

            var merkozesek1121 = from item in merkozesek
                                 where item.Idopont == DateTime.Parse("2004.11.21")
                                 select item;

            Console.WriteLine("6.feladat:");
            
            foreach (Merkozes item in merkozesek1121.ToList())
            {
                Console.WriteLine($"\t{item.MerkozesAdatai()}");
            }

            Console.WriteLine();

            var stadionok = merkozesek.GroupBy(x => x.Helyszin);
            Console.WriteLine("7. feladat: ");
            foreach (var item in stadionok)
            {
                if(item.Count()>20)
                {
                    Console.WriteLine($"\t{item.Key}: {item.Count()}");

                }
            }

            Dictionary<string, int> helyszinek = new Dictionary<string, int>();
            foreach (Merkozes item in merkozesek)
            {
                if (!helyszinek.ContainsKey(item.Helyszin))
                {
                    helyszinek.Add(item.Helyszin, 1);
                }
                else
                {
                    helyszinek[item.Helyszin] += 1;
                }
            }
            Console.WriteLine("7. feladat:");
            foreach (KeyValuePair<string, int> item in helyszinek)
            {
                if (item.Value > 20)
                {
                    Console.WriteLine($"\t{item.Key}:{item.Value}");
                }
            }

            Console.WriteLine("Linq-val:");
            var csoportQuery =
                from m in merkozesek
                group m by m.Helyszin;

            foreach (var item in csoportQuery)
            {
                if(item.Count()>20)
                {
                    Console.WriteLine($"\t{item.Key}: {item.Count()}");
                }
                
               
            }


            Console.ReadKey();

        }
    }
}
