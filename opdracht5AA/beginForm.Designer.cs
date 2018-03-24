namespace opdracht5AA
{
    partial class beginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxNaam1 = new System.Windows.Forms.TextBox();
            this.spelerEen = new System.Windows.Forms.Label();
            this.spelerTwee = new System.Windows.Forms.Label();
            this.textBoxNaam2 = new System.Windows.Forms.TextBox();
            this.startSpel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxNaam1
            // 
            this.textBoxNaam1.Location = new System.Drawing.Point(568, 166);
            this.textBoxNaam1.Name = "textBoxNaam1";
            this.textBoxNaam1.Size = new System.Drawing.Size(100, 20);
            this.textBoxNaam1.TabIndex = 0;
            this.textBoxNaam1.TextChanged += new System.EventHandler(this.textBoxSpeler1_TextChanged);
            // 
            // spelerEen
            // 
            this.spelerEen.AutoSize = true;
            this.spelerEen.BackColor = System.Drawing.Color.Transparent;
            this.spelerEen.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spelerEen.Location = new System.Drawing.Point(446, 160);
            this.spelerEen.Name = "spelerEen";
            this.spelerEen.Size = new System.Drawing.Size(105, 28);
            this.spelerEen.TabIndex = 1;
            this.spelerEen.Text = "Speler één";
            // 
            // spelerTwee
            // 
            this.spelerTwee.AutoSize = true;
            this.spelerTwee.BackColor = System.Drawing.Color.Transparent;
            this.spelerTwee.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spelerTwee.Location = new System.Drawing.Point(446, 205);
            this.spelerTwee.Name = "spelerTwee";
            this.spelerTwee.Size = new System.Drawing.Size(120, 28);
            this.spelerTwee.TabIndex = 2;
            this.spelerTwee.Text = "Speler twee";
            // 
            // textBoxNaam2
            // 
            this.textBoxNaam2.Location = new System.Drawing.Point(569, 211);
            this.textBoxNaam2.Name = "textBoxNaam2";
            this.textBoxNaam2.Size = new System.Drawing.Size(100, 20);
            this.textBoxNaam2.TabIndex = 3;
            this.textBoxNaam2.TextChanged += new System.EventHandler(this.textBoxSpeler2_TextChanged);
            // 
            // startSpel
            // 
            this.startSpel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startSpel.Location = new System.Drawing.Point(512, 271);
            this.startSpel.Name = "startSpel";
            this.startSpel.Size = new System.Drawing.Size(119, 35);
            this.startSpel.TabIndex = 4;
            this.startSpel.Text = "Start Spel";
            this.startSpel.UseVisualStyleBackColor = true;
            this.startSpel.Click += new System.EventHandler(this.startSpel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 57);
            this.label1.TabIndex = 5;
            this.label1.Text = "Voer je naam in";
            // 
            // beginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::opdracht5AA.Properties.Resources.chesswallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1096, 580);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startSpel);
            this.Controls.Add(this.textBoxNaam2);
            this.Controls.Add(this.spelerTwee);
            this.Controls.Add(this.spelerEen);
            this.Controls.Add(this.textBoxNaam1);
            this.Name = "beginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "beginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNaam1;
        private System.Windows.Forms.Label spelerEen;
        private System.Windows.Forms.Label spelerTwee;
        private System.Windows.Forms.TextBox textBoxNaam2;
        private System.Windows.Forms.Button startSpel;
        private System.Windows.Forms.Label label1;
    }
}