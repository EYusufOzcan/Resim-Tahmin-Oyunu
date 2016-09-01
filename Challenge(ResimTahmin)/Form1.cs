using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Challenge_ResimTahmin_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }

        int i = 0, sayac = 1;
        Random random = new Random();
        Bitmap[] array = { Properties.Resources.Desert, Properties.Resources.Hydrangeas, Properties.Resources.Koala, Properties.Resources.Lighthouse };
        ArrayList arraylist = new ArrayList();

        private void btnDegis_Click(object sender, EventArgs e)
        {
            PictureBox[] picture = { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            RadioButton[] radio = { radioButton1, radioButton2, radioButton3, radioButton4 };
            int[] location = { 98, 274, 434, 588 };

            for (int z = 0; z < radio.Length; z++)
            {
                if (z == 0)
                {
                    btnChecked(radio[z], 98);
                }
                if (z == 1)
                {
                    btnChecked(radio[z], 274);
                }
                if (z == 2)
                {
                    btnChecked(radio[z], 434);
                }
                if (z == 3)
                {
                    btnChecked(radio[z], 588);
                }

            }

            if (i == 0)
            {
                MessageBox.Show("Bir tahminde bulunmalısınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int j = random.Next(0, 4);
            pbasil.Image = array[j];
            if (i == location[j])
            {
                DialogResult result = MessageBox.Show("Tebrikler. " + sayac + ". denemenizde bildiniz." + "\nBir daha oynamak ister misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    sayac = 1;
                    i = 0;
                    pbasil.Image = null;
                    btnClear();
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                sayac++;
            }

            for (int k = 0; k < 4;)
            {
                int p = random.Next(0, 4);
                if (!arraylist.Contains(array[p]))
                {
                    arraylist.Add(array[p]);
                    picture[k].Image = array[p];
                    radio[p].Location = new Point(location[k], 533);
                    k++;
                }
            }
            arraylist.Clear();
            btnClear();

        }

        private void btnChecked(RadioButton rdtn, int sayi)
        {
            if (rdtn.Checked)
            {
                i = sayi;
            }
        }

        private void btnClear()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            i = 0;
        }

    }
}
