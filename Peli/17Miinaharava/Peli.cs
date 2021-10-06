using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;

namespace _17Miinaharava
{
    public partial class Peli : Form
    {
        private bool lippuActivated = false;

        private int kokoHOR;
        private int kokoVER;
        private int miinojenMaara;
        private int miinojaArvattuOikein = 0; //Arvattujen miinojen tarkistamiseen
        private int ruudunKoko;
        private int ruutuX = 20;


        private Random rnd = new Random();
        private Font ruutujenFontti;


        ResourceSet Resources = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
        List<Image> kuvat = new List<Image>();

        private int klikattujenMaara;
        private int ymparoivienMaara;

        private int kulunutaika = 0;

        private List<List<Button>> ruudukkoListat = new List<List<Button>>();

        public Peli(string vaikeustaso) //konstruktori
        {
            InitializeComponent();

            foreach (DictionaryEntry entry in Resources) //hakee kuvat listaan
            {
                String kuvanNimi = entry.Key.ToString();
                Image resurssi = entry.Value as Image;

                //lisää kuvan listaan
                kuvat.Add(resurssi);

            }

            if (vaikeustaso == "Helppo")
            {
                kokoVER = 9;
                kokoHOR = 9;
                ruudunKoko = 50;
                ruutujenFontti = new Font("Arial", 26, FontStyle.Bold);
                miinojenMaara = 10;

            }
            else if (vaikeustaso == "Keskitaso")
            {
                kokoVER = 16;
                kokoHOR = 16;
                ruudunKoko = 30;
                ruutujenFontti = new Font("Arial", 16, FontStyle.Bold);
                miinojenMaara = 40;
            }
            else if (vaikeustaso == "Vaikea")
            {
                kokoVER = 16;
                kokoHOR = 30;
                ruudunKoko = 24;
                ruutujenFontti = new Font("Arial", 10, FontStyle.Bold);
                miinojenMaara = 99;
            }

            miinatLabel.Text = miinojenMaara.ToString();

            LisaaRuudukko(); //lisää ruudukon ja luo napit

            ArvoMiinat(); //arpoo satunnaisiin ruutuihin miinoja vaikeustason perusteella

            AsetaYmparoivienmaarat(); // jos ruutu ei ole miina, asettaa sen tagiin ruudun ympärillä olevien miinojen määrän
        }

        private void AsetaYmparoivienmaarat()
        {
            for (int i = 0; i < kokoVER; i++)
            {

                for (int x = 0; x < kokoHOR; x++)
                {
                    ymparoivienMaara = 0;
                    if (ruudukkoListat[i][x].Tag != "-1")
                    {
                        // tarkistetaan ympäröivät ruudut
                        //horisontaaliset
                        try
                        {
                            if (ruudukkoListat[i][x - 1].Tag == "-1")
                            {
                                ymparoivienMaara += 1;
                            }
                        }
                        catch { }
                        try
                        {
                            if (ruudukkoListat[i][x + 1].Tag == "-1")
                            {
                                ymparoivienMaara += 1;
                            }
                        }
                        catch { }


                        //vertikaaliset
                        for (int y = -1; y < 2; y++)
                        {
                            try
                            {
                                if (ruudukkoListat[i - 1][x + y].Tag == "-1")
                                {
                                    ymparoivienMaara += 1;
                                }
                            }
                            catch { }

                            try
                            {
                                if (ruudukkoListat[i + 1][x + y].Tag == "-1")
                                {
                                    ymparoivienMaara += 1;
                                }
                            }
                            catch { }

                        }

                        ruudukkoListat[i][x].Tag = ymparoivienMaara.ToString();
                    }
                }

            }
        }

        private void ArvoMiinat()
        {
            while (miinojenMaara > 0) // lisää miinat
            {
                int r1 = rnd.Next(0, kokoVER);
                int r2 = rnd.Next(0, kokoHOR);
                while (ruudukkoListat[r1][r2].Tag == "-1")
                {
                     r1 = rnd.Next(0, kokoVER);
                     r2 = rnd.Next(0, kokoHOR);
                }
                ruudukkoListat[r1][r2].Tag = "-1";

                miinojenMaara -= 1;
            }
        }

        private void LisaaRuudukko()
        {
            for (int i = 0; i < kokoVER; i++) // luo ruudukon
            {
                ruudukkoListat.Add(new List<Button>());
                for (int x = 0; x < kokoHOR; x++)
                {
                    int ruudunKorkeus = i * ruudunKoko + 50;

                    ruudukkoListat[i].Add(new Button());

                    //asettaa ruudun ominaisuudet
                    ruudukkoListat[i][x].Location = new System.Drawing.Point(ruutuX, ruudunKorkeus);
                    ruudukkoListat[i][x].Size = new System.Drawing.Size(ruudunKoko, ruudunKoko);
                    ruudukkoListat[i][x].FlatStyle = FlatStyle.Popup;
                    ruudukkoListat[i][x].Name = i.ToString() + "_" + x.ToString();
                    ruudukkoListat[i][x].BackgroundImageLayout = ImageLayout.Stretch;
                    ruudukkoListat[i][x].Font = ruutujenFontti;
                    ruudukkoListat[i][x].MouseDown += new MouseEventHandler(ClickRuutu);
                    ruudukkoListat[i][x].BackColor = Color.LightGray;

                    ruutuX += ruudunKoko;
                    Controls.Add(ruudukkoListat[i][x]);

                }
                ruutuX = 20;

            }
        }

        private void ClickRuutu(object sender, MouseEventArgs e)
        {
            Button PainettuNappi = sender as Button;

            string[] indeksit = PainettuNappi.Name.ToString().Split("_".ToCharArray());

            int tokaIndex = int.Parse(indeksit[1]);
            int ekaIndex = int.Parse(indeksit[0]);

            if (lippuActivated || e.Button == MouseButtons.Right) //laittaa lipun
            {
                if (PainettuNappi.BackgroundImage == null && PainettuNappi.Text == "")
                {
                    PainettuNappi.BackgroundImage = kuvat[0];
                    PainettuNappi.ForeColor = Color.Black;
                    miinatLabel.Text = (int.Parse(miinatLabel.Text.ToString())-1).ToString();

                    if (PainettuNappi.Tag == "-1")
                    {
                        miinojaArvattuOikein += 1;
                    }
                }
                else if (PainettuNappi.BackgroundImage == kuvat[0])
                {
                    PainettuNappi.BackgroundImage = null;

                    miinatLabel.Text = (int.Parse(miinatLabel.Text.ToString()) + 1).ToString();

                    if (PainettuNappi.Tag == "-1")
                    {
                        miinojaArvattuOikein -= 1;
                    }
                }
            }
            else if (PainettuNappi.Text == "" && PainettuNappi.BackgroundImage == null)
            {
                if (PainettuNappi.Tag.ToString() == "0")
                {
                    PoistaNollat(ekaIndex, tokaIndex);
                }
                else if (PainettuNappi.Tag.ToString() != "-1") //jos ei ole miina
                {
                    PainettuNappi.Text = PainettuNappi.Tag.ToString();
                    AsetaVari(ekaIndex, tokaIndex);
                }
                else if (PainettuNappi.Tag.ToString() == "-1") //jos on miina
                {
                    PainettuNappi.BackgroundImage = kuvat[1];
                    PaljastaMiinat();
                    ajastinTimer.Enabled = false;
                    MessageBox.Show("Hävisit");

                    this.Close();
                }
            }

            if (KuinkaMontaKaannetty() == (kokoVER * kokoHOR - miinojaArvattuOikein))  //tarkastaa onko kaikki käännetty ja onko miinat merkitty
            {
                ajastinTimer.Enabled = false;
                MessageBox.Show("Voitit! " + "Sinulla meni aikaa " + (kulunutaika/60).ToString() + " minuutia ja " + (kulunutaika%60).ToString() + " sekuntia.");
                this.Close();
            }
        }


        private void PoistaNollat(int y, int x)
        {
            if (ruudukkoListat[y][x].BackgroundImage != null)
            {
                ruudukkoListat[y][x].BackgroundImage = null;
            }

            ruudukkoListat[y][x].Text = ruudukkoListat[y][x].Tag.ToString();
            AsetaVari(y,x);

            PoistaHorisontaaliset(x, y);
            PoistaVertikaaliset(x, y);
            PoistaKulmat(x, y);


        }

        private void PoistaHorisontaaliset(int x, int y) //poistaa kaikki nollat vasemmalta ja oikealta puolelta niin pitkälle kun on nollia
        {
            bool ymparillaNolla = true;
            int originalx = x;

            while (ymparillaNolla)
            {
                try // try catchit on siltä varalta jos meinaa mennä yli reunan
                {

                    if (ruudukkoListat[y][x].Tag.ToString() == "0" && ruudukkoListat[y][x + 1].Text.ToString() != "0") //oikean puolen x
                    {
                        x += 1;
                        PoistaNollat(y, x);

                    }
                    else
                    {
                        ymparillaNolla = false;
                    }
                }
                catch { }
                try
                {
                    if (ruudukkoListat[y][originalx].Tag.ToString() == "0" && ruudukkoListat[y][originalx - 1].Text.ToString() != "0")// vasemman puolen x
                    {
                        originalx -= 1;
                        PoistaNollat(y, originalx);

                    }
                    else
                    {
                        ymparillaNolla = false;
                    }
                }
                catch { }
            }

        }
        private void PoistaVertikaaliset(int x, int y) //poistaa kaikki nollat vertikaalisesti niin pitkälle kun on nollia
        {
            bool ymparillanolla = true;
            int alkuperänenY = y;


            while (ymparillanolla) //sama logiikka kun horisontaalisissa mutta vaan ylös ja alas
            {
                try
                {
                    if (ruudukkoListat[y][x].Tag.ToString() == "0" && ruudukkoListat[y + 1][x].Text.ToString() != "0")
                    {
                        y += 1;
                        PoistaNollat(y, x);
                    }
                    else
                    {
                        ymparillanolla = false;
                    }
                }
                catch { }

                try
                {
                    if (ruudukkoListat[alkuperänenY][x].Tag.ToString() == "0" && ruudukkoListat[alkuperänenY - 1][x].Text.ToString() != "0")
                    {
                        alkuperänenY -= 1;
                        PoistaNollat(alkuperänenY, x);

                    }
                    else
                    {
                        ymparillanolla = false;
                    }
                }
                catch { }

            }

        }
        private void PoistaKulmat(int x, int y) //tarkistaa kulmat jotka normaalisti jäisi pelkästään tarkastamalla suoraan horisontaalisesti ja vertikaalisesti tarkastamatta
        {
            for (int i = -1; i < 2; i+=2)
            {
                try
                {
                    if (ruudukkoListat[y][x].Text.ToString() == "0" && ruudukkoListat[y - 1][x + i].Text == "")
                    {
                        PoistaNollat(y - 1, x + i);
                    }
                }
                catch { }

                try
                {
                    if (ruudukkoListat[y][x].Text.ToString() == "0" && ruudukkoListat[y + 1][x + i].Text == "")
                    {
                        PoistaNollat(y + 1, x + i);
                    }
                }
                catch { }

            }
        }
        private void AsetaVari(int y, int x) // asettaa värin tagin perusteella
        {
            ruudukkoListat[y][x].BackColor = Color.White;
            if (ruudukkoListat[y][x].Tag.ToString() == "1")
            {
                ruudukkoListat[y][x].ForeColor = Color.Blue;
            }
            else if (ruudukkoListat[y][x].Tag.ToString() == "2")
            {
                ruudukkoListat[y][x].ForeColor = Color.Green;
            }
            else if (ruudukkoListat[y][x].Tag.ToString() == "3")
            {
                ruudukkoListat[y][x].ForeColor = Color.Orange;
            }
            else if (ruudukkoListat[y][x].Tag.ToString() == "4")
            {
                ruudukkoListat[y][x].ForeColor = Color.DarkRed;
            }
            else if (ruudukkoListat[y][x].Tag.ToString() == "0")
            {
                ruudukkoListat[y][x].ForeColor = Color.White;
            }
            else
            {
                ruudukkoListat[y][x].ForeColor = Color.Brown;
            }
        }

        private int KuinkaMontaKaannetty()
        {
            klikattujenMaara = 0;
            for (int y = 0; y < kokoVER; y++)
            {

                for (int x = 0; x < kokoHOR; x++)
                {
                    if (ruudukkoListat[y][x].Text != "")
                    {
                        if (ruudukkoListat[y][x].BackgroundImage == null)
                        {
                            klikattujenMaara += 1;
                        }
                    }
                }
            }
            return klikattujenMaara;
        }
        private void PaljastaMiinat()
        {
            for (int y = 0; y < kokoVER; y++)
            {

                for (int x = 0; x < kokoHOR; x++)
                {
                    if (ruudukkoListat[y][x].Tag == "-1")
                    {
                        ruudukkoListat[y][x].BackgroundImage = kuvat[1];
                    }
                }
            }
        }
        private void ajastinTimer_Tick(object sender, EventArgs e)
        {
            kulunutaika += 1;

            ajastinLabel.Text = (kulunutaika / 60).ToString() + ":" + (kulunutaika % 60).ToString();
        }

        private void flagButton_Click(object sender, EventArgs e)
        {
            lippuActivated = !lippuActivated;
            if (lippuActivated == false)
            {
                flagbutton.BackgroundImage = kuvat[1];
            }
            else
            {
                flagbutton.BackgroundImage = kuvat[0];
            }
        }
        
    }
}
