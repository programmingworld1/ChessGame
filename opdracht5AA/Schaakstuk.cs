using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opdracht5AA
{
     public abstract class Schaakstuk 
     {
        // private waardes
        private Image SchaakstukkenFoto; // alle schaakstukken fotos hierin opslaan als image.
        private string _kleurSchaakstuk; // schaakstuk kleur opslaan als string.

        // public waardes / properties
        public string kleurSchaakstuk
        {
            get { return _kleurSchaakstuk; }
            set { _kleurSchaakstuk = value; }
        } // schaakstuk kleur opslaan als string.
        public Image _SchaakstukkenFoto
        {
            get { return SchaakstukkenFoto; }
            set { SchaakstukkenFoto = value; }
        }     // Schaakstuk afbeeldingen hierin opslaan als image.

        // Methodes
        public void beweegSchaakStuk(veld eersteAangevinkteVeld, veld tweedeAangevinkteVeld) // Sla schaakstuk
        {
            KoningGeslagenWinnaar(tweedeAangevinkteVeld); // Als koning geslagen wordt, laat dan een popup zien en sluit het spel.
            tweedeAangevinkteVeld._Schaakstuk = eersteAangevinkteVeld._Schaakstuk; // vervang de schaakstuk met de eerst aangeklikte schaakstuk.
            eersteAangevinkteVeld._Schaakstuk = null; //  verwijder de schaakstuk waar je als eerst op hebt geklikt.
            eersteAangevinkteVeld._VakjePictureBox.Image = null; //  verwijder de schaakstuk afbeelding waar je als eerst op hebt geklikt van het veld.
        }
        private void KoningGeslagenWinnaar(veld tweedeAangevinkteVeld) // Hiermee sluti die de programma als je hebt gewonnen.
        {
            if (tweedeAangevinkteVeld._Schaakstuk != null)
            {
                if (tweedeAangevinkteVeld._Schaakstuk is Koning) // als je op een leegvakje klikt, kan je geen get type doen want die schaakstuk bestaat niet.
                {
                    System.Windows.Forms.MessageBox.Show("Er is een winnaar !!!"); // Weergeef een popup
                    Application.Exit(); // Sluit spel
                }
            }
        }
        public abstract void CheckBeweeg(veld eerstAangeklikteVeldBuren, veld tweedeAangevinkteVeld); // afbstract zodat omdat alle schaakstukken op eigen manier bewegen. Hiermee kan je ook voorkomen dat je telkens moet zeggen eersteaangeklikt.Toren etc.. je zegt gewoon . schaakstuk, dan pakt die dat specifieke schaakstuk.
    }
}
