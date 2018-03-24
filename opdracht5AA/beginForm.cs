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
    public partial class beginForm : Form
    {
        // maak twee spelers aan met type speler.
        private Speler Speler1;
        private Speler Speler2;

        public beginForm()
        {
            InitializeComponent();

            // Maak twee nieuwe spelers aan.
            Speler1 = new Speler();
            Speler2 = new Speler();
        }

        private void textBoxSpeler1_TextChanged(object sender, EventArgs e)
        {
            // zet speler1 zijn naam die je invuld in de textbox.
            Speler1._naam = textBoxNaam1.Text;
        }

        private void textBoxSpeler2_TextChanged(object sender, EventArgs e)
        {
            // zet speler2 zijn naam die je invuld in de textbox.
            Speler2._naam = textBoxNaam2.Text;
        }

        private void startSpel_Click(object sender, EventArgs e)
        {
            //Roep mainform aan omdat je die 1x nodig hebt om bij te komen.
            MainForm MainForm = new MainForm();

            // geef een andere letter grootte
            MainForm._Player1Label.Font = new Font("Arial", 24, FontStyle.Bold);
            MainForm._Player2Label.Font = new Font("Arial", 24, FontStyle.Bold);
            
            // Zet de twee labels in de mainform de speler zijn naam
            MainForm._Player1Label.Text = "Speler 1 : " + Speler1._naam;
            MainForm._Player2Label.Text = "Speler 2 : " + Speler2._naam;
            MainForm.ShowDialog();
            this.Dispose();
        }

    }
}
