using System.Drawing;

namespace opdracht5AA
{
    class Paard : Schaakstuk
    {
        public Paard(MainForm.SchaakstukKleur kleur) // Zet kleur van Schaakstuk
        {
            if (kleur == MainForm.SchaakstukKleur.Wit) // Als schaakstuk kleur wit heeft meegekregen
            {
                _SchaakstukkenFoto = Image.FromFile(@"..\..\..\opdracht5AA\paardFotoWit.png");
                kleurSchaakstuk = "wit"; // Geef kleur wit aan schaakstuk om het te defineren.
            }
            else // Als schaakstuk kleur zwart heeft meegekregen
            {
                _SchaakstukkenFoto = Image.FromFile(@"..\..\..\opdracht5AA\paardFotoZwart.png");
                kleurSchaakstuk = "zwart"; // Geef kleur zwart aan schaakstuk om het te defineren.
            }
        }

        public override void CheckBeweeg(veld eerstAangeklikteVeld, veld tweedeAangevinkteVeld) // Bij de tweede klik krijg instantie mee van de eerst aangeklikte veld.
        {
            for (int beweegRichting = 0; beweegRichting < 8; beweegRichting++) // Hiermee wordt er bepaald welke richtingen een koning op kan gaan, namelijk alle richtingen.
            {
                if (eerstAangeklikteVeld.PaardVakje[beweegRichting] != null && eerstAangeklikteVeld.PaardVakje[beweegRichting].Equals(tweedeAangevinkteVeld)) // Als het vakje wel bestaat, en de buur komt overeen met de tweede klik.
                {
                    if (eerstAangeklikteVeld.PaardVakje[beweegRichting]._Schaakstuk == null) // Als de buur van een richting geen schaakstuk heeft.
                    {
                        beweegSchaakStuk(eerstAangeklikteVeld, tweedeAangevinkteVeld); // Beweeg Schaakstuk.
                    }
                    else // Als er wel een schaakstuk op de buurvakje staat.
                    {
                        if (eerstAangeklikteVeld.PaardVakje[beweegRichting]._Schaakstuk.kleurSchaakstuk != kleurSchaakstuk) // Als de schaakstuk van de buurvakje niet het zelfde is als de kleur van deze instantie.
                        {
                            beweegSchaakStuk(eerstAangeklikteVeld, tweedeAangevinkteVeld); // Beweeg Schaakstuk.
                        }// stuur de buur en check of het overeenkomt met de tweede klik.
                    }
                    break; // Break de loop zodat die niet verder gaat zoeken, want dan kan die errors geven.                       
                }
            }
        } // Check om te kunnen bewegen
    }
}
