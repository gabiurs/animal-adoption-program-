using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_MTP
{
    public partial class Inregistrare : Form
    {
        public static bool verificCNP(string cnp)
        {
            
            int s, a1, a2, l1, l2, z1, z2, j1, j2, n1, n2, n3, cifc, u;
            if (cnp.Trim().Length != 13)
                return false;
            else
            {
                s = Convert.ToInt16(cnp.Substring(0, 1));
                a1 = Convert.ToInt16(cnp.Substring(1, 1));
                a2 = Convert.ToInt16(cnp.Substring(2, 1));
                l1 = Convert.ToInt16(cnp.Substring(3, 1));
                l2 = Convert.ToInt16(cnp.Substring(4, 1));
                z1 = Convert.ToInt16(cnp.Substring(5, 1));
                z2 = Convert.ToInt16(cnp.Substring(6, 1));
                j1 = Convert.ToInt16(cnp.Substring(7, 1));
                j2 = Convert.ToInt16(cnp.Substring(8, 1));
                n1 = Convert.ToInt16(cnp.Substring(9, 1));
                n2 = Convert.ToInt16(cnp.Substring(10, 1));
                n3 = Convert.ToInt16(cnp.Substring(11, 1));
                cifc = Convert.ToInt16(((s * 2 + a1 * 7 + a2 * 9 + l1 * 1 + l2 * 4 + z1
               * 6 + z2 * 3 + j1 * 5 + j2 * 8 + n1 * 2 + n2 * 7 + n3 * 9) % 11));
                if (cifc == 10)
                {
                    cifc = 1;
                }
                u = Convert.ToInt16(cnp.Substring(12, 1));
                if (cifc == u)
                    return true;
                else
                    return false;
            }
        }

            public Inregistrare()
        {
            InitializeComponent();
        }
        

        private void Inregistrared(object sender, EventArgs e)
        {
            label1.Text = System.DateTime.Today.ToLongDateString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            
            timer1.Start();
            File.AppendAllText("utilizatori.txt", "\n"+textBox1.Text + textBox2.Text + ",pass");
            string varsta = textBox5.Text;
            string cnp = textBox3.Text;
            string adresa = textBox4.Text;
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
                MessageBox.Show("Completati toate campurile!");
            else
            {
                //alta metoda de verificare camp - sa contina doar litere
                if (!Regex.Match(textBox1.Text, "^[A-Z][a-zA-Z]*$").Success)
                {
                    // numele este incorect
                    MessageBox.Show("Nume invalid", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }
            }
           

            string gen;//preluam genul 
            if (radioButton1.Checked == true)
            gen = radioButton1.Text;
                 else
            gen = radioButton2.Text;
         }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, @"^[0-9]*$"))
            {
                MessageBox.Show("Scrieti o varsta valida");
                textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1);
            }
        }
       
           private  void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (verificCNP(textBox2.Text) == true)
                MessageBox.Show("CNP corect!");
            else
                MessageBox.Show("CNP incorect!");

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 10;
            progressBar1.Value -= 1;
            progressBar1.Value += 1;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                MessageBox.Show("Inregistrare reusita!");
                Application.Restart();
            }
        }
    }
}