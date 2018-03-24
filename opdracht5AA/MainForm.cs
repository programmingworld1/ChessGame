using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace opdracht5AA
{
    public partial class MainForm : Form
    {
        // private waardes
        private veld eersteAangevinkteVeld; // Sla de instantie op, van de eerste klik.
        private veld tweedeAangevinkteVeld; // Sla de instantie op, van de tweede klik.
        private veld[,] myArray; // Multidimentional array van type : veld, om vakjes veldtjes erin op te slaan.
        private Label Player1Label; // Type Label, om naam speler een aan te koppelen en weergeven.
        private Label Player2Label; // Type Label, om naam speler twee aan te koppelen en weergeven.
        private Bitmap bmp; // Bitmap om images op te tekenen
        private bool CheckVorigeKleur; // dit zorgt voor het opslaan van backgroundimages. dat moet om en om gebeuren en daarvoor dient deze bool.
        private bool EersteOfTweedeKlik; // Bijhouden of je een schaakstuk moet selecteren of verplaatsen.

        // public waardes / properties
        public Label _Player1Label // hier komt de naam van speler1
        {
            get { return Player1Label; }
            set { Player1Label = value; }
        }
        public Label _Player2Label // hier komt de naam van speler2
        {
            get { return Player2Label; }
            set { Player2Label = value; }
        }
        public enum SchaakstukKleur // enum van zwart en wit om schaakstukken te defineren.
        {
            Wit = 0,
            Zwart,
        };

        // Methodes
        public MainForm()
        {
            InitializeComponent();
            bmp = new Bitmap(1050, 1000);
            myArray = new veld[8, 8];            // hier maak je een array van veld, 8 bij 8.
            CheckVorigeKleur = true;
            EersteOfTweedeKlik = false;

            // Hier maak je een label aan voor player 1 en geef je settings mee.
            Player1Label = new Label();
            Player1Label.Location = new Point(375, 50);
            Player1Label.Size = new Size(500, 50);
            this.Controls.Add(Player1Label);

            // Hier maak je een label aan voor player 2 en geef je settings mee.
            Player2Label = new Label();
            Player2Label.Location = new Point(375, 910);
            Player2Label.Size = new Size(500, 100);
            this.Controls.Add(Player2Label);

            // Roep functies op
            MaakSchaakBord();
            PaardBuren();
            BurenOpslaan();
            MaakSchaakStuk();
            PictureBoxImageSetOpSchaakstukAfbeelding();
            WeergeefSchaakBord();
            pictureBox1.MouseDown += PictureBox1_MouseDown;
        }
        private void MaakSchaakBord() // hier wordt de schaakbord gemaakt met vakjes.
        {
            //Hier wordt er gewerkt met een dubbele forloop om de bord te maken.
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    CheckVorigeKleur = !CheckVorigeKleur; // Hier wissel je de boolean om, zodat het veld om en om een andere kleur als tile zet.
                    myArray[i, j] = new veld(CheckVorigeKleur); // Hier maak worden de vakjes aangemaakt, en met die check bepaal je in de constructor van veld welke afbeelding die pakt.
                   // this.Controls.Add(myArray[i, j]._VakjePictureBox); // Hiermee worden de vakjes ook echt op het form gezet.
                }
                CheckVorigeKleur = !CheckVorigeKleur; // Als een nieuwe regel wordt gestart dan begint het met een nieuwe vakje kleur.
            }
        } 
        private void BurenOpslaan() // Deze methode zorgt ervoor dat elk vakje 8 buren krijgt.
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i > 0) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].BuurVakje[0] = myArray[i - 1, j]; // Noord
                    }

                    if (j <= 6) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].BuurVakje[1] = myArray[i, j + 1]; // Oost
                    }

                    if (i <= 6) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].BuurVakje[2] = myArray[i + 1, j]; // Zuid
                    }

                    if (j > 0) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].BuurVakje[3] = myArray[i, j - 1]; // West
                    }

                    if (i > 0 && j <= 6) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].BuurVakje[4] = myArray[i - 1, j + 1]; // NoordOost
                    }

                    if (i > 0 && j > 0) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].BuurVakje[5] = myArray[i - 1, j - 1]; // NoordWest
                    }

                    if (i <= 6 && j <= 6) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].BuurVakje[6] = myArray[i + 1, j + 1]; // ZuidOost
                    }

                    if (i <= 6 && j > 0) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].BuurVakje[7] = myArray[i + 1, j - 1]; // ZuidWest
                    }
                }
            }
        } 
        private void PaardBuren() // Hier maak je buren aan voor paard.
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i > 1 && j > 0) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].PaardVakje[0] = myArray[i - 2, j - 1]; // TweeBovenLinks
                    }

                    if (i > 1 && j <= 6) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].PaardVakje[1] = myArray[i - 2, j + 1]; // TweeBovenRechts
                    }

                    if (i > 0 && j <= 5) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].PaardVakje[2] = myArray[i - 1, j + 2]; // EenBovenTweeRechts
                    }

                    if (i <= 6 && j <= 5) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].PaardVakje[3] = myArray[i + 1, j + 2]; // EenBenedenTweeRechts
                    }

                    if (i <= 5 && j > 0) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].PaardVakje[4] = myArray[i + 2, j - 1]; // TweeBenedenLinks
                    }

                    if (i <= 5 && j <= 6) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].PaardVakje[5] = myArray[i + 2, j + 1]; // TweeBenedenRechts
                    }

                    if (i <= 6 && j >= 2) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].PaardVakje[6] = myArray[i + 1, j - 2]; // TweeLinksEenBeneden
                    }

                    if (i >= 1 && j >= 2) // Check of die niet buiten de matrix grenzen gaat.
                    {
                        myArray[i, j].PaardVakje[7] = myArray[i - 1, j - 2]; // TweeLinksEenBoven
                        //myArray[i, j].ZuidWest = myArray[i + 1, j - 1];
                    }
                }
            }
        }
        private void MaakSchaakStuk() // hier maak je alle schaakstukken aan.
        {
            // Zwarte Schaakstukken opslaan in object van specifieke veld
            // Kleur zwart meegeven om te bepalen welke afbeelding die op het scherm laat zien.

            Schaakstuk tower = new Toren(SchaakstukKleur.Zwart);
            myArray[0, 0]._Schaakstuk = tower;

            Schaakstuk loper = new Loper(SchaakstukKleur.Zwart);
            myArray[0, 2]._Schaakstuk = loper;

            Schaakstuk paard = new Paard(SchaakstukKleur.Zwart);
            myArray[0, 1]._Schaakstuk = paard;

            Schaakstuk koning = new Koning(SchaakstukKleur.Zwart);
            myArray[0, 3]._Schaakstuk = koning;

            Schaakstuk koningin = new Koningin(SchaakstukKleur.Zwart);
            myArray[0, 4]._Schaakstuk = koningin;

            Schaakstuk paard2 = new Paard(SchaakstukKleur.Zwart);
            myArray[0, 6]._Schaakstuk = paard2;

            Schaakstuk loper2 = new Loper(SchaakstukKleur.Zwart);
            myArray[0, 5]._Schaakstuk = loper2;

            Schaakstuk toren2 = new Toren(SchaakstukKleur.Zwart);
            myArray[0, 7]._Schaakstuk = toren2;


            for (int j = 0; j < 8; j++) // forloop zodat  niet 8 pionnen hardcoded erop hoeven.
            {
                Schaakstuk pion = new Pion(SchaakstukKleur.Zwart);
                myArray[1, j]._Schaakstuk = pion;
            }

            //Witte Schaakstukken opslaan in object van specifieke veld
            // Kleur wit meegeven om te bepalen welke afbeelding die op het scherm laat zien.
            Schaakstuk towerWit1 = new Toren(SchaakstukKleur.Wit);
            myArray[7, 0]._Schaakstuk = towerWit1;

            Schaakstuk loperWit1 = new Loper(SchaakstukKleur.Wit);
            myArray[7, 2]._Schaakstuk = loperWit1;

            Schaakstuk paardWit1 = new Paard(SchaakstukKleur.Wit);
            myArray[7, 1]._Schaakstuk = paardWit1;

            Schaakstuk koningWit1 = new Koning(SchaakstukKleur.Wit);
            myArray[7, 3]._Schaakstuk = koningWit1;

            Schaakstuk koningWinit1 = new Koningin(SchaakstukKleur.Wit);
            myArray[7, 4]._Schaakstuk = koningWinit1;

            Schaakstuk paardWit2 = new Paard(SchaakstukKleur.Wit);
            myArray[7, 6]._Schaakstuk = paardWit2;

            Schaakstuk loperWit2 = new Loper(SchaakstukKleur.Wit);
            myArray[7, 5]._Schaakstuk = loperWit2;

            Schaakstuk towerWit2 = new Toren(SchaakstukKleur.Wit);
            myArray[7, 7]._Schaakstuk = towerWit2;

            for (int j = 0; j < 8; j++) // forloop zodat  niet 8 pionnen hardcoded erop hoeven.
            {
                Schaakstuk pion2 = new Pion(SchaakstukKleur.Wit);
                myArray[6, j]._Schaakstuk = pion2;
            }
        }  
        public void PictureBoxImageSetOpSchaakstukAfbeelding() // Zet de Image van Picturebox foto
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (myArray[i, j]._Schaakstuk != null)
                    {
                        myArray[i, j]._VakjePictureBox.Image = myArray[i, j]._Schaakstuk._SchaakstukkenFoto; // zet schaakstukken foto op de picturebox van vakjes.
                    }
                }
            }
        }
        private void WeergeefSchaakBord() // Met die weergeef je de schaakbord een keer.
        {
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    using (Graphics graphics = Graphics.FromImage(bmp))
                    {
                        graphics.DrawImage(myArray[i, j]._VakjePictureBox.BackgroundImage, j * 100, i * 100, 100, 100);
                        if (myArray[i, j]._VakjePictureBox.Image != null)
                        {
                            graphics.DrawImage(myArray[i, j]._VakjePictureBox.Image, j * 100, i * 100, 100, 100);
                        }
                    }
                }
            }
            pictureBox1.Image = bmp;

        }

        // Events
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e) // Selecteer vakjes.
        {
            veld aangeklikteVeld;
            if (e.Button == MouseButtons.Left) // Als je op de linkermuis knop hebt geklikt.
            {
                int x = e.X; // locatie van muis op de picturebox waar alles naartoe wordt getekend.
                int y = e.Y; // locatie van muis op de picturebox waar alles naartoe wordt getekend.
                int i = y / 100; // BV : 250 / 100 = 2.5 - afgerond is 2. 2 is in de array derde rij.
                int j = x / 100; // BV : 250 / 100 = 2.5 - afgerond is 2. 2 is in de array derde kolom.
                aangeklikteVeld = myArray[i, j]; // dus drie vakjes naar beneden en drie naar rechts.

                if (aangeklikteVeld._Schaakstuk != null && EersteOfTweedeKlik == false) // alleen als er een object is en check op false staat kan het volgende worden uitgevoerd
                {
                    eersteAangevinkteVeld = aangeklikteVeld; // het vakje waar je op clickt pakt die, dus heel de instantie.
                    EersteOfTweedeKlik = true; // zet het dan op true zodat de volgende x dat je clickt wat anders wordt uitgevoerd.
                }
                else if (eersteAangevinkteVeld == aangeklikteVeld) // als je klikt op de instantie van de if hierboven.
                {
                    EersteOfTweedeKlik = false; // zet op false, zo deselecteer je een schaakstuk.
                }
                else if (EersteOfTweedeKlik == true && eersteAangevinkteVeld._Schaakstuk.kleurSchaakstuk == "zwart" && Speler._SpelerBeurt == true)
                {
                    if (eersteAangevinkteVeld._Schaakstuk != null)
                    {
                        tweedeAangevinkteVeld = aangeklikteVeld; // het vakje waar je op clickt pakt die, dus heel de instantie.
                        eersteAangevinkteVeld._Schaakstuk.CheckBeweeg(eersteAangevinkteVeld, tweedeAangevinkteVeld); // this is instantie van deze class. Want je hebt hier op gelickt. Die stuurt die naar beweeg methode.
                        Speler._SpelerBeurt = false;
                        EersteOfTweedeKlik = false; // zet het dan op true zodat de volgende x dat je clickt wat anders wordt uitgevoerd.
                    }
                }
                else if (EersteOfTweedeKlik == true && eersteAangevinkteVeld._Schaakstuk.kleurSchaakstuk == "wit" && Speler._SpelerBeurt == false)
                {
                    if (eersteAangevinkteVeld._Schaakstuk != null)
                    {
                        tweedeAangevinkteVeld = aangeklikteVeld; // het vakje waar je op clickt pakt die, dus heel de instantie.
                        eersteAangevinkteVeld._Schaakstuk.CheckBeweeg(eersteAangevinkteVeld, tweedeAangevinkteVeld); // this is instantie van deze class. Want je hebt hier op gelickt. Die stuurt die naar beweeg methode.                                                                    //if schaakstuk is PrintControllerWithStatusDialog and player 1 == true
                        Speler._SpelerBeurt = true;
                        EersteOfTweedeKlik = false; // zet het dan op true zodat de volgende x dat je clickt wat anders wordt uitgevoerd.
                    }
                }
                PictureBoxImageSetOpSchaakstukAfbeelding(); // Schaakstuk staat al op een nieuwe positie, en foto is verwijderd. Met deze methode zet je de image van de picturebox op die van de schaakstuk.
                WeergeefSchaakBord(); // Schaakstuk wordt op een nieuwe positie in de array gezet, en moet daarna opnieuw weergeven worden.
            }
        }
        private void sluitSpel_Click(object sender, EventArgs e) // Met deze event kan je de spel sluiten.
        {
            Application.Exit(); // Sluit het spel.
        }
        public void herstartSpel_Click(object sender, EventArgs e) // Hiermee is het spel restartbaar. 
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    myArray[i, j]._VakjePictureBox.Image = myArray[i,j]._VakjePictureBox.Image = null; // verwijder alle schaakstukken fotos.
                    myArray[i, j]._Schaakstuk = null;  // verwijder schaakstukken.                  
                }
            }

            MaakSchaakStuk(); // maak het schaakbord aan.
            PictureBoxImageSetOpSchaakstukAfbeelding();
            WeergeefSchaakBord(); // weergeef schaakbord.
            Speler._SpelerBeurt = false; // zet beurt van de speler weer op false.
            EersteOfTweedeKlik = false; // zet de klik check weer op false.
        }

    }
}


