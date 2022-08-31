using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_MTP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Autentificare_Load(object sender, EventArgs e)
        {
            string[] utilizatori = File.ReadAllLines("utilizatori.txt");
            foreach (var line in utilizatori)
            {
                if(!line.Equals(""))
                    {
                    string[] inregistrare = line.Split(',');
                    comboBox1.Items.Add(inregistrare[0]);
                }
            }
        }
        private int incercari = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string[] utilizatori = File.ReadAllLines("utilizatori.txt");

            foreach (var line in utilizatori)
            {
                string[] inregistrare = line.Split(',');
                if ((comboBox1.Text).Equals(inregistrare[0]))
                {
                    if ((textBox1.Text.Trim()).Equals(inregistrare[1].Trim()))
                    {
                        Meniu f = new Meniu();
                        f.ShowDialog();
                    }
                    else
                    {
                        incercari++;
                        MessageBox.Show("Parola incorecta! Mai aveti " + (3 -
                        incercari).ToString() + " incercari.");
                    }
                }
                if (incercari == 3)
                    Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inregistrare f = new Inregistrare();
            f.ShowDialog();
        }
    }
    }

