using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtYarisi
{
    public partial class frmAtYarisi : Form
    {
        public frmAtYarisi()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            int[] hiz = new int[5];
            int[] x = new int[5];

            x[0] = pictureBox1.Location.X;
            x[1] = pictureBox2.Location.X;
            x[2] = pictureBox3.Location.X;
            x[3] = pictureBox4.Location.X;
            x[4] = pictureBox5.Location.X;

            for (int i = 0; i < hiz.Length; i++) hiz[i] = rnd.Next(5, 16);

            pictureBox1.Location = new Point(x[0] + hiz[0], 22);
            pictureBox2.Location = new Point(x[1] + hiz[1], 137);
            pictureBox3.Location = new Point(x[2] + hiz[2], 252);
            pictureBox4.Location = new Point(x[3] + hiz[3], 369);
            pictureBox5.Location = new Point(x[4] + hiz[4], 482);

            int enOnde = x[0], yedek = 0;
            for (int i = 1; i < x.Length; i++)
            {
                if (enOnde < x[i])
                {
                    enOnde = x[i];
                    yedek = i;
                }               
            }
            lblDurum.Text = (yedek + 1) + " Numaralı At Önde";

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] >= label8.Location.X - 116)
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    lblDurum.Text = (i + 1) + " Numaralı At Yarışı Kazandı!";
                }
            }
        }

        int zaman = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            btnZaman.Text = zaman.ToString();
            zaman++;
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
        }

        private void btnTekrar_Click(object sender, EventArgs e)
        {
            zaman = 0;
            btnZaman.Text = zaman.ToString();
            lblDurum.Text = "";
            pictureBox1.Location = new Point(5, 22);
            pictureBox2.Location = new Point(5, 137);
            pictureBox3.Location = new Point(5, 252);
            pictureBox4.Location = new Point(5, 369);
            pictureBox5.Location = new Point(5, 482);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
