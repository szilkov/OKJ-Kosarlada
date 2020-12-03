using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosarlabda
{
    class Merkozes
    {
        string hazai;
        string idegen;
        int hazai_pont;
        int idegen_pont;
        string helyszin;
        DateTime idopont;

        public string Hazai { get => hazai; set => hazai = value; }
        public string Idegen { get => idegen; set => idegen = value; }
        public int Hazai_pont { get => hazai_pont; set => hazai_pont = value; }
        public int Idegen_pont { get => idegen_pont; set => idegen_pont = value; }
        public string Helyszin { get => helyszin; set => helyszin = value; }
        public DateTime Idopont { get => idopont; set => idopont = value; }

        public Merkozes(string sor)
        {
            List<string> adatok = new List<string>();
            adatok = (sor.Split(';').ToList());
            Hazai = adatok[0];
            Idegen = adatok[1];
            Hazai_pont = int.Parse(adatok[2]);
            Idegen_pont = int.Parse(adatok[3]);
            Helyszin = adatok[4];
            Idopont = DateTime.Parse(adatok[5]);
        }

        public string MerkozesAdatai()
        {
            return $"{this.Hazai}-{this.Idegen} ({this.Hazai_pont}:{this.Idegen_pont})";


        }
    }
}
