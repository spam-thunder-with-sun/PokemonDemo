using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonDemo
{
    public partial class OverWorld : Form
    {
        int movimento;
        SoundPlayer sound = new SoundPlayer(@"..\..\music.wav");
        SoundPlayer soundFine = new SoundPlayer(@"..\..\musicFine.wav");
        bool allenatore1 = false;
        bool allenatore2 = false;

        public OverWorld()
        {
            InitializeComponent();

            //Form per Spiegare al giocatore il gioco :)
            SalutoIniziale tmp = new SalutoIniziale();
            tmp.ShowDialog();
            
            //Setto il numero di px per spostare la padina-utente 
            movimento = 8; // Ci sono circa 50 caselle
        }

        //************************GRAFICA**********************************

        private void OverWorld_Load(object sender, EventArgs e) { KeyDown += TastoPremuto; }

        public void TastoPremuto(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)//Tasto premuto
            {
                case Keys.Up:
                    pbxPersonaggio.Top -= movimento;//Muovo il personaggio
                    pbxPersonaggio.Image = Properties.Resources.P_Retro;//Cambio la grafica

                    if (pbxPersonaggio.Location.Y <= 0)//Controllo la fine
                        MessageBox.Show("Complimenti hai finito la demo!!");

                    //Faccio partire la lotta

                    if (pbxAllenatore1.Top >= pbxPersonaggio.Top - movimento / 2 && pbxAllenatore1.Top <= pbxPersonaggio.Top + movimento / 2 && !allenatore1)
                    { allenatore1 = true; StartCombattimento(1); }//Se ho già combattuto contro questo allenatore non posso lottare di nuovo con lo stesso
                    if (pbxAllenatore2.Top >= pbxPersonaggio.Top - movimento / 2 && pbxAllenatore2.Top <= pbxPersonaggio.Top + movimento / 2 && !allenatore2)
                    { allenatore2 = true; StartCombattimento(2); }
                    break;

                case Keys.Right:
                    pbxPersonaggio.Left += movimento;//Muovo il personaggio
                    pbxPersonaggio.Image = Properties.Resources.P_LatoD;//Cambio la grafica
                    break;

                case Keys.Left:
                    pbxPersonaggio.Left -= movimento;
                    pbxPersonaggio.Image = Properties.Resources.P_LatoS;
                    break;

                case Keys.Down:
                    pbxPersonaggio.Top += movimento;
                    pbxPersonaggio.Image = Properties.Resources.P_Fronte;
                    break;
            }

            
            //Controllo che il personaggio non esca dai limiti
            if((pbxPersonaggio.Location.Y <= 420 && pbxPersonaggio.Location.Y >= 300) && (pbxPersonaggio.Location.X >= 400 || pbxPersonaggio.Location.X <= 120))
                ErrorePediana();
            if (pbxPersonaggio.Location.X <= 472 && pbxPersonaggio.Location.Y >= 460)
                ErrorePediana();
            if (pbxPersonaggio.Location.X <= 140 && (pbxPersonaggio.Location.Y <= 357 && pbxPersonaggio.Location.Y >= 300))
                ErrorePediana();
            if (pbxPersonaggio.Location.X >= 65 && pbxPersonaggio.Location.Y <= 160)
                ErrorePediana();
            if (pbxPersonaggio.Location.X >= 200 && pbxPersonaggio.Location.Y <= 340)
                ErrorePediana();

            if (pbxPersonaggio.Location.X <= 40 && pbxPersonaggio.Location.Y <= 40)
            {
                soundFine.PlayLooping();
                System.Threading.Thread.Sleep(3000);
                MessageBox.Show("Complimenmti hai finito PokemonDemo !");
                this.Close();
            }
            //28; 38
        }

        void ErrorePediana()
        {
            MessageBox.Show("Ash non può passare qui!\nRimani nel percorso!", "Attento!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            pbxPersonaggio.Left = 550; 
            pbxPersonaggio.Top = 469;
            return;
        }

        //***********************LOTTA***************************

        public void StartCombattimento(int n)
        {
            sound.PlayLooping();//Faccio partire la canzone

            ButtonsMioPkmn();//Inizializzo i pulsanti per il mio personaggio
            Application.DoEvents();

            SwitchPannello();//Cambio lo scenario a quello di lotta

            EffettoLotta();//Effetto speciale di transizione

            switch(n)//Scelgo l'allenatore con cui lottare
            {
                case 1:
                    Allenatore1(); //Allenatore 1;
                    break;
                case 2:
                    Allenatore2();
                    break;
            }

            Application.DoEvents();//Aggiorno la grafica
        }

        public void SwitchPannello()
        {
            //Cambio lo scenario a seconda di quello attuale

            if (pbxPercorso.Visible == true)
            {
                pbxAllenatore1.Visible = false;
                pbxAllenatore2.Visible = false;
                pbxPercorso.Visible = false;
                pbxPersonaggio.Visible = false;
            }
            else
            {
                pbxAllenatore1.Visible = true;
                pbxAllenatore2.Visible = true;
                pbxPercorso.Visible = true;
                pbxPersonaggio.Visible = true;
            }

            Application.DoEvents();//Aggiorno la grafica
            return;
        }

        void EffettoLotta()
        {
            //Creo un nuovo pannello 
            //Lo coloro di bianco e nero ripetitivamente
            //Questo crea un effetto speciale di animazione

            Panel eff = new Panel();
            eff.Visible = true;
            eff.Width = ClientSize.Width;
            eff.Height = ClientSize.Height;
            eff.Top = eff.Left = 0;
            this.Controls.Add(eff);

            for (int i = 0; i < 5; i++)
            {
                eff.BackColor = Color.Black;
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
                eff.BackColor = Color.White;
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }

            this.Controls.Remove(eff);
        }

        PokemonBase mio, suo;
        public void Allenatore1()
        {
            mio = Charizard;
            suo = Pikachu;
            //Scelgo il pkmn

            //Qui compongo effettivamente la finesta di lotta
            PanneloLottaSuperiore(Pikachu); //Gestisce la parte superiore
            PanneloLottaInferiore(Charizard); //Gestisce la parte inferiore
            FinestraLotta();

            //Utilizzo un po di delay per degli effetti grfici 
            pnl_Scritte.Text = "Parte la lotta conto Gino Avventuriero!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(2000);
            pnl_Scritte.Text = "Gino manda in campo Pikachu!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(2000);
            pnl_Scritte.Text = "Vai Charizard!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(2000);
            pnl_Scritte.Text = "";
            //*******

            PosizionaButtons();//Visualizzo la scelta delle mosse

            Application.DoEvents();
            return;
        }

        public void Allenatore2()
        {
            Random g = new Random(DateTime.Now.Millisecond);

            mio = Charizard;
            //Scelgo il pkmn

            switch (g.Next(10))
            {
                case 1:
                    PanneloLottaSuperiore(Onix);
                    suo = Onix;
                    break;
                case 2:
                    PanneloLottaSuperiore(Hitmonchan);
                    suo = Hitmonchan;
                    break;
                case 3:
                    PanneloLottaSuperiore(Hitmonlee);
                    suo = Hitmonlee;
                    break;
                case 4:
                    PanneloLottaSuperiore(Victreebel);
                    suo = Victreebel;
                    break;
                case 5:
                    PanneloLottaSuperiore(Fearow);
                    suo = Fearow;
                    break;
                case 6:
                    PanneloLottaSuperiore(Electabuzz);
                    suo = Electabuzz;
                    break;
                case 7:
                    PanneloLottaSuperiore(Pidgeot);
                    suo = Pidgeot;
                    break;
                case 8:
                    PanneloLottaSuperiore(Raticate);
                    suo = Raticate;
                    break;
                case 9:
                    PanneloLottaSuperiore(Gyarados);
                    suo = Gyarados;
                    break;
            }
            PanneloLottaInferiore(Charizard);
            FinestraLotta();
            //Seclgo random il pkmn avversario e compongo i pannelli

            pnl_Scritte.Text = "Parte la lotta conto Galileo Scienziato!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(2000);
            pnl_Scritte.Text = "Galileo manda in campo el Masceto!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(2000);
            pnl_Scritte.Text = "Vai Charizard!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(2000);
            pnl_Scritte.Text = "";

            PosizionaButtons();//Visualizzo la scelta delle mosse

            Application.DoEvents();

            return;
        }
        public void FinestraLotta()
        {
            //Qui creo i pannelli base per la scena di lotta

            //Creo il pannello per comunicare scritte all'utente
            pnl_Scritte = new Label();
            pnl_Scritte.Font = new Font("Lucida Console", 35, FontStyle.Regular);
            pnl_Scritte.Visible = true;
            pnl_Scritte.Width = ClientSize.Width - 20;
            pnl_Scritte.Height = 110;
            pnl_Scritte.Top = ClientSize.Height - pnl_Scritte.Height - 10;
            pnl_Scritte.Left = 10;
            pnl_Scritte.BackColor = Color.Gray;
            pnl_Scritte.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pnl_Scritte);

            //Creo il pannello base della lotta
            pnl_FinestraLotta = new Panel();
            pnl_FinestraLotta.Visible = true;
            pnl_FinestraLotta.Width = ClientSize.Width;
            pnl_FinestraLotta.Height = ClientSize.Height;
            pnl_FinestraLotta.Top = 0;
            pnl_FinestraLotta.Left = 0;
            pnl_FinestraLotta.BackColor = Color.White;
            Controls.Add(pnl_FinestraLotta);
        }

        Label nomePkmn1, nomePkmn2, livPkmn1, livPkmn2;
        Panel imgPkmn1, imgPkmn2, barraSalute1, barraSalute2;
        public void PanneloLottaSuperiore(PokemonBase pkmn)
        {
            //Creo l'immagine del pkmn in campo
            imgPkmn1 = new Panel();
            imgPkmn1.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(pkmn.ImgDavanti);
            imgPkmn1.BackgroundImageLayout = ImageLayout.Stretch;
            imgPkmn1.BackColor = Color.WhiteSmoke;
            imgPkmn1.Visible = true;
            imgPkmn1.Width = imgPkmn1.Height = 150;
            imgPkmn1.Top = 10;
            imgPkmn1.Left = ClientSize.Width - imgPkmn1.Width - 10;
            Controls.Add(imgPkmn1);

            //Creo la barra che tiene i punti salute del pkmn
            barraSalute1 = new Panel();
            barraSalute1.BackColor = Color.Green;
            barraSalute1.Width = 400;
            barraSalute1.Height = 20;
            barraSalute1.Top = 100;
            barraSalute1.Left = 20;
            Controls.Add(barraSalute1);

            //Inserisco il nome del pkmn in campo
            nomePkmn1 = new Label();
            nomePkmn1.Font = new Font("Lucida Console", 25, FontStyle.Regular);
            nomePkmn1.Height = 40;
            nomePkmn1.Width = 200;
            nomePkmn1.Text = Convert.ToString(pkmn.Nome);
            nomePkmn1.Top = barraSalute1.Top - nomePkmn1.Height - 10;
            nomePkmn1.Left = barraSalute1.Left;
            Controls.Add(nomePkmn1);

            //Inserisco dati sul pkmn in campo
            livPkmn1 = new Label();
            livPkmn1.Font = new Font("Lucida Console", 25, FontStyle.Regular);
            livPkmn1.Height = 40;
            livPkmn1.Width = 200;
            livPkmn1.Text = "Liv.  " + Convert.ToString(50);
            livPkmn1.Top = nomePkmn1.Top;
            livPkmn1.Left = nomePkmn1.Left + nomePkmn1.Width;
            Controls.Add(livPkmn1);

            return;
        }

        public void PanneloLottaInferiore(PokemonBase pkmn)
        {
            //Creo l'immagine del pkmn in campo
            imgPkmn2 = new Panel();
            imgPkmn2.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(pkmn.ImgDietro);
            imgPkmn2.BackgroundImageLayout = ImageLayout.Stretch;
            imgPkmn2.BackColor = Color.WhiteSmoke;
            imgPkmn2.Visible = true;
            imgPkmn2.Width = imgPkmn2.Height = 150;
            imgPkmn2.Top = ClientSize.Height - imgPkmn2.Height - 150;
            imgPkmn2.Left = 10;
            Controls.Add(imgPkmn2);

            //Creo la barra che tiene i punti salute del pkmn
            barraSalute2 = new Panel();
            barraSalute2.BackColor = Color.Green;
            barraSalute2.Width = 400;
            barraSalute2.Height = 20;
            barraSalute2.Top = imgPkmn2.Top + 100;
            barraSalute2.Left = ClientSize.Width - 20 - barraSalute2.Width;
            Controls.Add(barraSalute2);

            //Inserisco il nome del pkmn in campo
            nomePkmn2 = new Label();
            nomePkmn2.Font = new Font("Lucida Console", 25, FontStyle.Regular);
            nomePkmn2.Height = 40;
            nomePkmn2.Width = 200;
            nomePkmn2.Text = Convert.ToString(pkmn.Nome);
            //nomePkmn2.Top = imgPkmn2.Top - nomePkmn1.Height - 10;
            nomePkmn2.Top = barraSalute2.Top - nomePkmn2.Height - 10;
            nomePkmn2.Left = barraSalute2.Left;
            Controls.Add(nomePkmn2);

            //Inserisco dati sul pkmn in campo
            livPkmn2 = new Label();
            livPkmn2.Font = new Font("Lucida Console", 25, FontStyle.Regular);
            livPkmn2.Height = 40;
            livPkmn2.Width = 200;
            livPkmn2.Text = "Liv.  " + Convert.ToString(50);
            livPkmn2.Top = nomePkmn2.Top;
            livPkmn2.Left = nomePkmn2.Left + nomePkmn2.Width;
            Controls.Add(livPkmn2);

            return;
        }

        void PosizionaButtons()
        {
            //Qui posiziono i bottoni per la scelta delle mosse

            bMossa1.Width = bMossa2.Width = bMossa3.Width = bMossa4.Width = 100;
            bMossa1.Height = bMossa2.Height = bMossa3.Height = bMossa4.Height = 50;
            bMossa1.Left = pnl_Scritte.Left + 10;
            bMossa2.Left = bMossa1.Left + 20 + bMossa1.Width;
            bMossa3.Left = bMossa2.Left + 20 + bMossa1.Width;
            bMossa4.Left = bMossa3.Left + 20 + bMossa1.Width;
            bMossa1.Top = bMossa2.Top = bMossa3.Top = bMossa4.Top = (pnl_Scritte.Top + pnl_Scritte.Top + pnl_Scritte.Height) / 2 - bMossa1.Height;
            bMossa1.Visible = bMossa2.Visible = bMossa3.Visible = bMossa4.Visible = true;
        }

        Button bMossa1, bMossa2, bMossa3, bMossa4;
        public void ButtonsMioPkmn()
        {
            //Qui inizializzo i bottoni della lotta per il mio personaggio
            //Non utilizzo un'altra Form per non avere due finestre aperte

            bMossa1 = new Button();
            bMossa2 = new Button();
            bMossa3 = new Button();
            bMossa4 = new Button();

            bMossa1.Text = "Lanciafiamme";
            bMossa2.Text = "Azione";
            bMossa3.Text = "AttAla";
            bMossa4.Text = "Breccia";

            bMossa1.Top = bMossa2.Top = bMossa3.Top = bMossa4.Top = 0;
            bMossa1.Left = bMossa2.Left = bMossa3.Left = bMossa4.Left = 0;
            bMossa1.Visible = bMossa2.Visible = bMossa3.Visible = bMossa4.Visible = false;
            bMossa1.BackColor = bMossa2.BackColor = bMossa3.BackColor = bMossa4.BackColor = Color.Orange;

            bMossa1.Click += B1_Click;
            bMossa2.Click += B2_Click;
            bMossa3.Click += B3_Click;
            bMossa4.Click += B4_Click;

            this.Controls.Add(bMossa1);
            this.Controls.Add(bMossa2);
            this.Controls.Add(bMossa3);
            this.Controls.Add(bMossa4);
            return;
        }

        Mossa pow; //Utilizzo per determinare di quanto i punti salute sono stati ridotti

        private void B1_Click(object sender, EventArgs e)
        {
            pnl_Scritte.Text = "Usa Lanciafiamme!";//Visualizzo a video la mossa che utilizzo
            pow = Lanciafiamme;//Setto la potenza della mossa
            Lotta(Lanciafiamme);//Attacco e tolgo ps
        }
        private void B2_Click(object sender, EventArgs e)
        {
            pnl_Scritte.Text = "Usa Azione!";
            pow = Azione;
            Lotta(Azione);
        }
        private void B3_Click(object sender, EventArgs e)
        {
            pnl_Scritte.Text = "Usa Attacco d'ala!";
            pow = AttAla;
            Lotta(AttAla);
        }
        private void B4_Click(object sender, EventArgs e)
        {
            pnl_Scritte.Text = "Usa Breccia!"; 
            pow = Breccia;
            Lotta(Breccia);
        }

        public void Lotta(Mossa m)
        {
            //Qui visualizzo effettivamente la scena di lotta

            bMossa1.Visible = bMossa2.Visible = bMossa3.Visible = bMossa4.Visible = false;
            //Nascondo il bottoni per la scelta della mossa
            Application.DoEvents();

            System.Threading.Thread.Sleep(1000);//Attendo 1 secondo
            
            //Sposto piano piano l'immagine del pkmn
            //Questo crea un effetto speciale
            for(int i = 0; i < 50; i++)
            {
                imgPkmn2.Top -= 1;
                imgPkmn2.Left += 1;
                System.Threading.Thread.Sleep(10);
            }

            //Riporto l'immagine al suo posto iniziale
            imgPkmn2.Top += 50;
            imgPkmn2.Left -= 50;

            //*******************
            //Qui riduco la barra salute
            int danno = Danno(m);
            barraSalute1.Width = barraSalute1.Width - danno;//Riduco i ps

            if (barraSalute1.Width <= 0) //Se la barra ps dell'avversario scende sotto 0, Ho vinto la sfida
            {
                //Ho vinto la sfida
                pnl_Scritte.Text = "Hai vinto la sfida!";
                CambiaScenaDaLotta();//Ripristino la schermata del percorso
                return;//Il mio avversario non attacca più
            }

            //Qui attacca il mio avv

            //Setto la grafica
            pnl_Scritte.Text = "";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            pnl_Scritte.Text = "Il pkmn avversario attacca!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);

            //Effetto grafico di attacco
            for (int i = 0; i < 50; i++)
            {
                imgPkmn1.Top += 1;
                imgPkmn1.Left -= 1;
                System.Threading.Thread.Sleep(10);
            }

            //Rimetto l'immagine al suo posto
            imgPkmn1.Top -= 50;
            imgPkmn1.Left += 50;

            danno = Danno(null); //Calcolo il danno random
            barraSalute2.Width = barraSalute2.Width - danno;//Riduco i ps

            if (barraSalute2.Width <= 0)//Se i miei ps scendono a 0, ho perso la sfida
            {
                pnl_Scritte.Text = "Hai perso la sfida!";
                CambiaScenaDaLotta();//Ripristino la schermata del percorso
                return;
            }

            //***********************************
            //Qui rendo visibili i bottoni per la scelta della mossa nuovamente

            pnl_Scritte.Text = "";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
            bMossa1.Visible = bMossa2.Visible = bMossa3.Visible = bMossa4.Visible = true;
            Application.DoEvents();
            return;
        }

        public int Danno(Mossa m)
        {
            //Qui calolo il danno inferto da una precisa mossa
            //Se non viene passata nessuna mossa restituisco un valore random

            Random g = new Random(DateTime.Now.Millisecond);
            //int LV = 50;
            double Stab = 1.0;
            int pow;
            double tmp;

            if (m != null)//Se viene passata una mossa
            {
                //Utilizzo una precisa formula per il calcolo del danno...
                pow = (int)m.Potenza;
                if (m.Tipo == mio.Tipo1 || m.Tipo == mio.Tipo2)
                    Stab = 1.5;
                tmp = (110 * (int)mio.Attacco * pow);
                tmp /= (250 * (int)suo.Difesa);
            }   
            else
            {
                //Altrimenti restituisco un valore random
                tmp = (110 * (int)suo.Attacco * g.Next(80, 120));
                tmp /= (250 * (int)mio.Difesa);
            }
            
            //Potenzio determinate mosse
            tmp += 2;
            tmp = Math.Round(Stab * tmp);

            //Controllo che il valore non sia troppo basso
            int n = (int)Math.Truncate(tmp);
            n *=3;
            if (n == 0)
                n = 10; //Altimenti lo alzo

            return n;
        }

        public void CambiaScenaDaLotta()
        {
            //Qui elimino tutti i componenti usati per la scena di lotta

            //Nascondo ed elimino i pulsanti delle mosse
            bMossa1.Visible = bMossa2.Visible = bMossa3.Visible = bMossa4.Visible = false;
            bMossa1.Enabled = bMossa2.Enabled = bMossa3.Enabled = bMossa4.Enabled = false;
            this.Controls.Remove(bMossa1);
            this.Controls.Remove(bMossa2);
            this.Controls.Remove(bMossa3);
            this.Controls.Remove(bMossa4);
            Application.DoEvents();

            System.Threading.Thread.Sleep(2000);

            //Rimuovo tutti gli atri componenti
            this.Controls.Remove(pnl_Scritte);
            this.Controls.Remove(pnl_FinestraLotta);
            this.Controls.Remove(nomePkmn1);
            this.Controls.Remove(nomePkmn2);
            this.Controls.Remove(livPkmn1);
            this.Controls.Remove(livPkmn2);
            this.Controls.Remove(imgPkmn1);
            this.Controls.Remove(imgPkmn2);
            this.Controls.Remove(barraSalute1);
            this.Controls.Remove(barraSalute2);

            sound.Stop();//Smetto di riprodurre la musica

            SwitchPannello();//Carico il pannello del percorso

            Application.DoEvents();         
        }

        //Un po' di cose utili
        Mossa Lanciafiamme = new Mossa(TipoPokemon.fuoco, 90, 100, false);
        Mossa Azione = new Mossa(TipoPokemon.normale, 40, 100, true);
        Mossa Breccia = new Mossa(TipoPokemon.lotta, 75, 100, true);
        Mossa AttAla = new Mossa(TipoPokemon.volante, 60, 100, true);
        Mossa FendiFoglia = new Mossa(TipoPokemon.erba, 90, 100, true);
        Mossa Surf = new Mossa(TipoPokemon.acqua, 95, 95, false);
        Mossa Acido = new Mossa(TipoPokemon.normale, 50, 100, false);
        Mossa CorpoScontro = new Mossa(TipoPokemon.normale, 130, 50, true);
        PokemonBase Charizard = new PokemonBase(NomePokemon.Charizard, TipoPokemon.fuoco, TipoPokemon.volante, 84, 109, 78, 85, 100, 78, "CharizardDavanti", "CharizardDietro");
        PokemonBase Venusaur = new PokemonBase(NomePokemon.Venusaur, TipoPokemon.erba, TipoPokemon.vuoto, 82, 100, 83, 100, 80, 80, "VenusaurDavanti", "VenusaurDietro");
        PokemonBase Blastoise = new PokemonBase(NomePokemon.Blastoise, TipoPokemon.acqua, TipoPokemon.vuoto, 83, 85, 100, 105, 78, 79, "BlastoiseDavanti", "BlastoiseDietro");
        PokemonBase Pikachu = new PokemonBase(NomePokemon.Pikachu, TipoPokemon.elettro, TipoPokemon.vuoto, 55, 50, 40, 50, 90, 35, "PikachuDavanti", "PikachuDietro");
        PokemonBase Victreebel = new PokemonBase(NomePokemon.Victreebel, TipoPokemon.erba, TipoPokemon.vuoto, 105, 100, 65, 70, 70, 80, "VictreebelDavanti", "VictreebelDietro");
        PokemonBase Pidgeot = new PokemonBase(NomePokemon.Pidgeot, TipoPokemon.normale, TipoPokemon.volante, 80, 70, 75, 70, 101, 83, "PidgeotDavanti", "PidgeotDietro");
        PokemonBase Raticate = new PokemonBase(NomePokemon.Raticate, TipoPokemon.normale, TipoPokemon.vuoto, 81, 50, 60, 70, 97, 55, "RaticateDavanti", "RaticateDietro");
        PokemonBase Fearow = new PokemonBase(NomePokemon.Fearow, TipoPokemon.normale, TipoPokemon.volante, 90, 61, 65, 61, 100, 65, "FearowDavanti", "FearowDietro");
        PokemonBase Gyarados = new PokemonBase(NomePokemon.Gyarados, TipoPokemon.acqua, TipoPokemon.volante, 125, 60, 79, 100, 81, 95, "GyaradosDavanti", "GyaradosDietro");
        PokemonBase Onix = new PokemonBase(NomePokemon.Onix, TipoPokemon.lotta, TipoPokemon.vuoto, 45, 30, 160, 45, 70, 35, "OnixDavanti", "OnixDietro");
        PokemonBase Electabuzz = new PokemonBase(NomePokemon.Electabuzz, TipoPokemon.elettro, TipoPokemon.vuoto, 83, 95, 57, 85, 105, 65, "ElectabuzzDavanti", "ElectabuzzDietro");
        PokemonBase Hitmonlee = new PokemonBase(NomePokemon.Hitmonlee, TipoPokemon.lotta, TipoPokemon.vuoto, 120, 35, 53, 110, 87, 50, "HitmonleeDavanti", "HitmonleeDietro");
        PokemonBase Hitmonchan = new PokemonBase(NomePokemon.Hitmonchan, TipoPokemon.lotta, TipoPokemon.vuoto, 105, 35, 79, 110, 76, 50, "HitmonchanDavanti", "HitmonchanDietro");
        Label pnl_Scritte;
        Panel pnl_FinestraLotta;
    }
}
