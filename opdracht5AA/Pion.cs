using System.Drawing;

namespace opdracht5AA
{
    class Pion : Schaakstuk
    {
        private bool tweeStappenPionCheck = true; // Pion mag maar een keer twee stappen zetten. Bij true twee stappen, bij false een stap.
        public Pion(MainForm.SchaakstukKleur kleur) // Zet kleur van Schaakstuk 
        {
            if (kleur == MainForm.SchaakstukKleur.Wit) // Als schaakstuk kleur wit heeft meegekregen
            {
                _SchaakstukkenFoto = Image.FromFile(@"..\..\..\opdracht5AA\pionFotoWit.png");
                kleurSchaakstuk = "wit"; // Geef kleur wit aan schaakstuk om het te defineren.
            }
            else // Als schaakstuk kleur zwart heeft meegekregen
            {
                _SchaakstukkenFoto = Image.FromFile(@"..\..\..\opdracht5AA\pionFotoZwart.png");
                kleurSchaakstuk = "zwart"; // Geef kleur zwart aan schaakstuk om het te defineren.
            }
        }
        public override void CheckBeweeg(veld eerstAangeklikteVeld, veld tweedeAangevinkteVeld) // Bij de tweede klik krijg instantie mee van de eerst aangeklikte veld.
        {
            veld huidigeVakje = eerstAangeklikteVeld; // Maak een tweede versie aan van eerstAangeklikte veld, zodat je de aantal stappen kan onthouden in deze specifieke classe variabel en zodat de  variabel eerstAangeklikteveld zijn oorsprinkelijke waarde blijft houden.
            int richting = 0;
            if (eerstAangeklikteVeld._Schaakstuk.kleurSchaakstuk == "zwart") // Als een zwarte Pion is gekozen.
            {
                richting = 2;       // Geef richting 2 om te bewegen (NIET om te slaan)
            }
            else // Als een witte Pion is gekozen.
            {
                richting = 0;     // Geef richting 0 om te bewegen (NIET om te slaan)       
            }

            for (int beweegRichting = 0; beweegRichting < 8; beweegRichting++) // Loop alle richtingen langs, maar pak uiteindelijk alleen de richtingen 0,2,4,5,6,7.
            {
                if (eerstAangeklikteVeld.BuurVakje[richting] != null) // Als het vakje van de richting waar een specifieke pion naar toe kan BEWEGEN bestaat.
                {
                    if (eerstAangeklikteVeld.BuurVakje[richting]._Schaakstuk == null) // Als de buur van een richting geen schaakstuk heeft.
                    {
                        if (beweegRichting == 0 || beweegRichting == 2) // Als de richting 0 of 2 is (Noord of Zuid, hangt af van schaakstuk kleur waar je op hebt geklikt)
                        {
                            if (tweeStappenPionCheck == true) // Hiermee kan een pion maximaal twee zetten doen, en voor maar 1 keer.
                            {
                                for (int aantalStappen = 0; aantalStappen < 1; aantalStappen++) // Deze loop zorgt ervoor dat je twee keer loopt in de onderstaande stukje. Dat heb je nodig om de vorige buur op te slaan, zodat bij de tweede keer in de loop de buur van de buur kan worden gepakt.
                                {
                                    huidigeVakje = huidigeVakje.BuurVakje[richting]; // Sla de buur op in huidigeVakje, en dit doe je telkens totdat het buur overeenkomt met de tweede aangeklikte veld.
                                    if (huidigeVakje.Equals(tweedeAangevinkteVeld)) // Als de buurvakje, richting 0 en 2 (Noord of Zuid), gelijk staat een de tweede klik.
                                    {
                                        beweegSchaakStuk(eerstAangeklikteVeld, tweedeAangevinkteVeld); // Beweeg Schaakstuk.
                                        tweeStappenPionCheck = false; // Zet op false, zodat 2 stappen zetten maar een keer mag.
                                        beweegRichting = 8; // Break de forloop, zodat die niet andere richtingen gaat checken nadat je de schaakstuk hebt verplaatst. Want anders krijg je een error.
                                        break; // Break ook eigen loop, omdat schaakstuk al gezet is. 
                                    }
                                }
                            }
                            else // Na de eerste zet, kan een Pion alleen maar een stap doen.
                            {
                                if (eerstAangeklikteVeld.BuurVakje[richting].Equals(tweedeAangevinkteVeld)) // Als de buurvakje, richting 0 en 2 (Noord of Zuid), gelijk staat een de tweede klik.
                                {
                                    beweegSchaakStuk(eerstAangeklikteVeld, tweedeAangevinkteVeld); // Beweeg Schaakstuk.
                                    break; // Break de forloop, zodat die niet andere richtingen gaat checken nadat je de schaakstuk hebt verplaatst. Want anders krijg je een error.
                                }
                            }
                        }
                    }
                }
                if (beweegRichting == richting + 4 || beweegRichting == richting + 5) // Aan de hand van de gekozen schaakstuk(kleur) tel je bijvoorbeeld 4 en 5 op bij richting (richting wit = 0, 4 is Noord-Oost, 5 is Noord-West)(richting zwart = 2, 6 is Zuid-Oost, 7 is Zuid-West)
                {
                    if (eerstAangeklikteVeld.BuurVakje[beweegRichting] != null && eerstAangeklikteVeld.BuurVakje[beweegRichting]._Schaakstuk != null) // Als het vakje van de richting waar een specifieke pion naar toe kan SLAAN en schaakstuk bestaat.
                    {
                        if (eerstAangeklikteVeld.BuurVakje[beweegRichting]._Schaakstuk.kleurSchaakstuk != eerstAangeklikteVeld._Schaakstuk.kleurSchaakstuk) // Als de schaakstuk van de huidige vakje een specifieke kleur heeft, en de schaakstuk van de eerst aangeklikte veld is van een ander kleur.
                        {
                            if (eerstAangeklikteVeld.BuurVakje[beweegRichting].Equals(tweedeAangevinkteVeld)) // Als de buurvakje, richting 4,5 en 6,7, gelijk staat een de tweede klik.
                            {
                                beweegSchaakStuk(eerstAangeklikteVeld, tweedeAangevinkteVeld); // Beweeg Schaakstuk.
                                break; // Break de forloop, zodat die niet andere richtingen gaat checken nadat je de schaakstuk hebt verplaatst. Want anders krijg je een error.                            
                            }
                        }
                    }
                }
            }           
        }
    }
} // Check om te kunnen bewegen




