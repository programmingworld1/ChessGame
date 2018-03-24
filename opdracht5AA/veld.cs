using System.Drawing;
using System.Windows.Forms;

namespace opdracht5AA
{
    public class veld
    {
        // private waardes
        private PictureBox VakjePictureBox; // Pictureboxe maak je aan, en daar koppel je een backgroundimage en image aan. Deze wordt getekend naar een bitmap en vervolgens weergeven.
        public veld[] BuurVakje; // 8 buren per vakje bijhouden.
        public veld[] PaardVakje; // 8 buren per vakje bijhouden, specifiek voor paard gemaakt.
        private int WidthVakjePictureBox = 100; // Hoogte van de pictureBox hier bepalen.
        private int HeightVakjePictureBox = 100; // Breedte van de pictureBox hier bepalen.
        private Schaakstuk Schaakstuk; // // Schaakstukken die je aanmaakt in de mainform hierin zetten.

        // public waardes
        public PictureBox _VakjePictureBox
        {
            get { return VakjePictureBox; }
            set { }
        } // Public van de private
        public Schaakstuk _Schaakstuk
        {
            get { return Schaakstuk; }
            set { Schaakstuk = value; }
        } // Public van de private
        public int _HeightVakjePictureBox
        {
            get { return HeightVakjePictureBox; }
            set { }
        } // Public van de private
        public int _WidthVakjePictureBox
        {
            get { return WidthVakjePictureBox; }
            set { }
        } // Public van de private

        // methodes
        public veld(bool CheckVorigeKleur)
        {
            BuurVakje = new veld[8]; // maak array om 8 buren erin op te slaan.
            PaardVakje = new veld[8]; // maak array om 8 buren erin op te slaan.
            VakjePictureBox = new PictureBox(); // maak picturebox om daat images intedoen en een veld te vormen.
            if (CheckVorigeKleur == true) // wissel van images.
            {
                VakjePictureBox.BackgroundImage = Image.FromFile(@"..\..\..\opdracht5AA\wit.jpg");
            }
            else
            {
                VakjePictureBox.BackgroundImage = Image.FromFile(@"..\..\..\opdracht5AA\zwart.jpg");
            }
            Size size = new Size(_HeightVakjePictureBox, _WidthVakjePictureBox); // Stel een bepaalde grootte in.
            VakjePictureBox.Size = size; // de picturebox wordt 100 bij 100 groot.
            VakjePictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Stretch de fotos binnen de picturebox.
        }
    }
}
