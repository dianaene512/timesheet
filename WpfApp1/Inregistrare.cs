using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Inregistrare
    {
        public string user { get; set; }
        public string data { get; set; }
        public string firma { get; set; }
        public float nrOre { get; set; }

        public Inregistrare(string user, string data, string firma, float nrOre)
        {
            this.user = user;
            this.data = data;
            this.firma = firma;
            this.nrOre = nrOre;
        }

        public override string ToString()
        {
            return this.user + ": " + this.data + " - " + this.firma + " - " + this.nrOre + "h.";
        }
    }
}
