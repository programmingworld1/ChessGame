using System.Drawing;


namespace opdracht5AA
{
    class Koningin : Schaakstuk
    {
        public Koningin(MainForm.SchaakstukKleur kleur) // Zet kleur van Schaakstuk
        {
            if (kleur == MainForm.SchaakstukKleur.Wit) // Als schaakstuk kleur wit heeft meegekregen
            {
                _SchaakstukkenFoto = Image.FromFile(@"..\..\..\opdracht5AA\koninginFotoWit.png");
                kleurSchaakstuk = "wit"; // Geef kleur wit aan schaakstuk om het te defineren.
            }
            else // Als schaakstuk kleur zwart heeft meegekregen
            {
                _SchaakstukkenFoto = Image.FromFile(@"..\..\..\opdracht5AA\koninginFotoZwart.png");
                kleurSchaakstuk = "zwart"; // Geef kleur zwart aan schaakstuk om het te defineren.
            }
        }

        public override void CheckBeweeg(veld eerstAangeklikteVeld, veld tweedeAangevinkteVeld) // Bij de tweede klik krijg instantie mee van de eerst aangeklikte veld.
        {
            for (int beweegRichting = 0; beweegRichting < 8; beweegRichting++) // Hiermee bepaal je welke richtingen Koning op kan gaan, namelijk alle richtingen.
            {
                veld huidigeVakje = eerstAangeklikteVeld; // sla de eerst geselecteerde vakje op. Doe dit telkens zodat je de oorspronkelijke waarde reset zodat, op het moment dat beweegRichting veranderd, het vanaf de juiste vakje begint te zoeken.
                for (int aantalStappen = 0; aantalStappen < 8; aantalStappen++) // Door deze loop wordt de onderstaande code 8 keer herhaald en wordt in de huidige vakje, de buur 8 keer opgeslagen.
                {
                    if (huidigeVakje.BuurVakje[beweegRichting] != null) // Als de buurvakje wel bestaat, telkens van een specifieke richting. Toren bijvoorbeeld, heeft bij het begin alleen maar 2 buren. Zo voorkom je de null error.
                    {
                        if (huidigeVakje.BuurVakje[beweegRichting]._Schaakstuk == null) // Als de buurvakje van een richting geen schaakstuk heeft.
                        {
                            huidigeVakje = huidigeVakje.BuurVakje[beweegRichting]; // Sla de buur op in huidigeVakje, en dit doe je telkens totdat het buur overeenkomt met de tweede aangeklikte veld.
                            if (huidigeVakje.Equals(tweedeAangevinkteVeld)) // Als de buurvakje, dus de loop die je doorgaat, all richtingen 8 x op, gelijk staat een de tweede klik.
                            {
                                beweegSchaakStuk(eerstAangeklikteVeld, tweedeAangevinkteVeld); // Roep beweegmethode op zodat schaakstuk kan bewegen.
                                aantalStappen = 8; // Forloop wordt afgerond.
                                beweegRichting = 8; // Forloop wordt afgerond.
                            }// stuur de buur en check of het overeenkomt met de tweede klik.
                        }
                        else // Als er wel een schaakstuk op de specifieke vakje staat waar die is met zoeken.
                        {
                            if (huidigeVakje.BuurVakje[beweegRichting]._Schaakstuk.kleurSchaakstuk != eerstAangeklikteVeld._Schaakstuk.kleurSchaakstuk) // Als de schaakstuk van de huidige vakje een specifieke kleur heeft, en de schaakstuk van de eerst aangeklikte veld is van een ander kleur.
                            {
                                huidigeVakje = huidigeVakje.BuurVakje[beweegRichting];
                                aantalStappen = 8; // Forloop wordt afgerond, anders blijft die checken en geeft die een error.
                                if (huidigeVakje.Equals(tweedeAangevinkteVeld)) // Als het vakje wel bestaat
                                {
                                    beweegSchaakStuk(eerstAangeklikteVeld, tweedeAangevinkteVeld); // Roep beweegmethode op zodat schaakstuk kan bewegen.
                                    beweegRichting = 8; // Forloop wordt afgerond.
                                }// stuur de buur en check of het overeenkomt met de tweede klik.
                            }
                        }
                    }
                }
            } // Check om te kunnen slaan
        }
    }
}
