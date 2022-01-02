using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LukStrela
{
    public partial class Form1 : Form
    {
        private int brojBalona;
        private int brzinaStrijele;
        private int brzinaCrtanjaBalona;
        int brojBalonaStart;
        bool goDown, goUp, goFire;
        Control luk, strijela;
        Control baloni = new Control();
        Random random = new Random();
        Color[] boje = new Color[] { Color.Black, Color.Blue, Color.Green, Color.Red, Color.Yellow };
        private int brPoena = 0;
        int br = 0;
        int brCrtanje = 0;
        public Form1(int brojBalona, int brzinaStrijele, int brzinaCrtanjaBalona)
        {
            InitializeComponent();

            this.brojBalona = brojBalona;
            this.brzinaStrijele = brzinaStrijele;
            this.brzinaCrtanjaBalona = brzinaCrtanjaBalona;
            brojBalonaStart = brojBalona;

            StartProperty();
            TimerIgra.Start();
        }
        private void StartProperty()
        {
            panIgra.Location = new Point(0, 0);
            lblBrojPoena.Text = brPoena.ToString();

            LukCrtanje();
            StrijelaCrtanje();
            //BalonCrtanje(brojBalona);
        }
        private void TimerIgra_Event(object sender, EventArgs e)
        {
            br++;
            if(br == 25 * brzinaCrtanjaBalona)
            {
                br = 0;
                if(brCrtanje != brojBalonaStart)
                {
                    BalonCrtanje();
                    brCrtanje++;
                }
            }
            if (goDown == true)
            {
                if(luk.Top < panIgra.Height - luk.Height)
                {
                    luk.Top += 5;
                    if (strijela.Location.X == luk.Location.X)
                    {
                        strijela.Top += 5;
                    }
                }
            }
            if (goUp == true)
            {
                if(luk.Top > 0)
                {
                    luk.Top -= 5;
                    if (strijela.Location.X == luk.Location.X)
                    {
                        strijela.Top -= 5;
                    }
                }
            }
            if (goFire == true)
            {
                strijela.Tag = "IspaljenaStrijela";
                goFire = false;
                StrijelaCrtanje();
            }          
            foreach (Control x in panIgra.Controls)
            { 
                if ((string)x.Tag == "Balon")
                {
                    x.Top -= 3;
                    if(x.Top <= 0)
                    {
                        panIgra.Controls.Remove(x);
                        --brojBalona;
                    }
                }
                if ((string)x.Tag == "IspaljenaStrijela")
                {
                    x.Left += brzinaStrijele;
                    if (x.Left >= panIgra.Width - 60)
                    {
                        panIgra.Controls.Remove(x);
                    }
                }
            }
            foreach (Control y in panIgra.Controls)
            {
                foreach (Control z in panIgra.Controls)
                {
                    if((string)y.Tag == "IspaljenaStrijela" && (string)z.Tag == "Balon" && y.Bounds.IntersectsWith(z.Bounds) && y.Visible == true && z.Visible == true)
                    {
                        panIgra.Controls.Remove(y);
                        panIgra.Controls.Remove(z);
                        lblBrojPoena.Text = (++brPoena).ToString();
                        --brojBalona;
                    }
                }
            }
            if(brojBalona == 0)
            {
                //double x = brPoena;
                double procenat = (double)brPoena / brojBalonaStart * 100;
                
                TimerIgra.Stop();
                MessageBox.Show("Broj Poena je: " + brPoena.ToString() + "" +
                                "\nProcentualni učinak je: " + Math.Round(procenat, 2).ToString() + "%");
                this.Close();
            }
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Down)
            { 
                goDown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                goFire = true;
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
        }
        private void LukCrtanje()
        {
            luk = new PictureBox
            {
                Name = "Luk",
                Tag = "Luk",
                BackColor = Color.DarkGoldenrod,
                Width = 50,
                Height = 50,
                Location = new Point(10, panIgra.Height / 2 - 25)
            };
            luk.Click += new EventHandler(Luk_Click);
            GraphicsPath gp = new GraphicsPath();
            PointF a = new PointF(0, 0);
            PointF b = new PointF(0, 50);
            PointF c = new PointF(50, 25);
            gp.AddLine(a, b);
            gp.AddLine(b, c);
            Region r = new Region(gp);
            luk.Region = r;

            panIgra.Controls.Add(luk);
        }
        private void Luk_Click(object sender, EventArgs e)
        {
            luk.BackColor = boje[random.Next(boje.Length)];
        }
        private void StrijelaCrtanje()
        {
            strijela = new PictureBox
            {
                Name = "Strijela",
                Tag = "Strijela",
                BackColor = Color.Black,
                Width = 60,
                Height = 2,
                Location = new Point(luk.Location.X, luk.Location.Y + luk.Height/2 - 1)
            };

            panIgra.Controls.Add(strijela);
            strijela.BringToFront();
        }
        private void BalonCrtanje()
        {
            //for(int i = 0; i < brojBalona; i++)
            //{
                baloni = new PictureBox
                {
                    Tag = "Balon",
                    BackColor = boje[random.Next(boje.Length)],
                    Width = 60,
                    Height = 60,
                    Location = new Point(random.Next(panIgra.Width / 2, panIgra.Width - 60), panIgra.Height)
                };

                GraphicsPath gpB = new GraphicsPath();
                gpB.AddEllipse(0, 0, baloni.Width, baloni.Height);
                Region rB = new Region(gpB);
                baloni.Region = rB;

                panIgra.Controls.Add(baloni);
                baloni.BringToFront();
            //}
        }
    }
}
