namespace PokemonDemo
{
    partial class OverWorld
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverWorld));
            this.pbxAllenatore2 = new System.Windows.Forms.PictureBox();
            this.pbxAllenatore1 = new System.Windows.Forms.PictureBox();
            this.pbxPersonaggio = new System.Windows.Forms.PictureBox();
            this.pbxPercorso = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAllenatore2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAllenatore1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPersonaggio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPercorso)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxAllenatore2
            // 
            this.pbxAllenatore2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbxAllenatore2.Image = global::PokemonDemo.Properties.Resources.Allenatore2_LatoDx;
            this.pbxAllenatore2.Location = new System.Drawing.Point(152, 385);
            this.pbxAllenatore2.Name = "pbxAllenatore2";
            this.pbxAllenatore2.Size = new System.Drawing.Size(18, 22);
            this.pbxAllenatore2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAllenatore2.TabIndex = 3;
            this.pbxAllenatore2.TabStop = false;
            // 
            // pbxAllenatore1
            // 
            this.pbxAllenatore1.Image = global::PokemonDemo.Properties.Resources.Allenatore1_LatoSx;
            this.pbxAllenatore1.Location = new System.Drawing.Point(106, 187);
            this.pbxAllenatore1.Name = "pbxAllenatore1";
            this.pbxAllenatore1.Size = new System.Drawing.Size(17, 22);
            this.pbxAllenatore1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAllenatore1.TabIndex = 2;
            this.pbxAllenatore1.TabStop = false;
            // 
            // pbxPersonaggio
            // 
            this.pbxPersonaggio.BackColor = System.Drawing.Color.Transparent;
            this.pbxPersonaggio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxPersonaggio.Image = global::PokemonDemo.Properties.Resources.P_Fronte;
            this.pbxPersonaggio.Location = new System.Drawing.Point(549, 469);
            this.pbxPersonaggio.Name = "pbxPersonaggio";
            this.pbxPersonaggio.Size = new System.Drawing.Size(17, 22);
            this.pbxPersonaggio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPersonaggio.TabIndex = 1;
            this.pbxPersonaggio.TabStop = false;
            // 
            // pbxPercorso
            // 
            this.pbxPercorso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxPercorso.Image = ((System.Drawing.Image)(resources.GetObject("pbxPercorso.Image")));
            this.pbxPercorso.Location = new System.Drawing.Point(0, 0);
            this.pbxPercorso.Name = "pbxPercorso";
            this.pbxPercorso.Size = new System.Drawing.Size(590, 512);
            this.pbxPercorso.TabIndex = 0;
            this.pbxPercorso.TabStop = false;
            // 
            // OverWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 513);
            this.Controls.Add(this.pbxAllenatore2);
            this.Controls.Add(this.pbxAllenatore1);
            this.Controls.Add(this.pbxPersonaggio);
            this.Controls.Add(this.pbxPercorso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OverWorld";
            this.Text = "Pokemon Fantastic Time";
            this.Load += new System.EventHandler(this.OverWorld_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAllenatore2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAllenatore1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPersonaggio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPercorso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxPercorso;
        private System.Windows.Forms.PictureBox pbxPersonaggio;
        private System.Windows.Forms.PictureBox pbxAllenatore1;
        private System.Windows.Forms.PictureBox pbxAllenatore2;
    }
}

