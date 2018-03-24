namespace opdracht5AA
{
    partial class menuForm
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
            this.herstartSpel = new System.Windows.Forms.Button();
            this.stopSpel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // herstartSpel
            // 
            this.herstartSpel.Location = new System.Drawing.Point(90, 52);
            this.herstartSpel.Name = "herstartSpel";
            this.herstartSpel.Size = new System.Drawing.Size(75, 23);
            this.herstartSpel.TabIndex = 0;
            this.herstartSpel.Text = "Herstart Spel";
            this.herstartSpel.UseVisualStyleBackColor = true;
            this.herstartSpel.Click += new System.EventHandler(this.button1_Click);
            // 
            // stopSpel
            // 
            this.stopSpel.Location = new System.Drawing.Point(90, 97);
            this.stopSpel.Name = "stopSpel";
            this.stopSpel.Size = new System.Drawing.Size(75, 23);
            this.stopSpel.TabIndex = 1;
            this.stopSpel.Text = "Stop Spel";
            this.stopSpel.UseVisualStyleBackColor = true;
            this.stopSpel.Click += new System.EventHandler(this.button2_Click);
            // 
            // menuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.stopSpel);
            this.Controls.Add(this.herstartSpel);
            this.Name = "menuForm";
            this.Text = "menuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button herstartSpel;
        private System.Windows.Forms.Button stopSpel;
    }
}