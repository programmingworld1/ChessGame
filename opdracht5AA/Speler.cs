using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht5AA
{
    class Speler
    {
        private static bool SpelerBeurt = false; // hiermee wordt de spelerbeurt bepaald. Wit begint altijd.
        public static bool _SpelerBeurt
        {
            get { return SpelerBeurt; }
            set { SpelerBeurt = value; }
        }

        private string naam; // Hier sla je de namen van beide spelers in op.
        public string _naam
        {
            get { return naam; }
            set { naam = value; }
        }
    }
}
