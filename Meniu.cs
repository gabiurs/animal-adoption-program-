using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_MTP
{
    public partial class Meniu : Form
    {
        public Meniu()
        {
            InitializeComponent();
        }

        private void Meniu_Load(object sender, EventArgs e)
        {
            //OferaAdoptie f = new OferaAdoptie();
            //f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)//ofera spre adoptie buton
        {

            OferaAdoptie f = new OferaAdoptie();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)// buton cancel 
        {
            Login l = new Login();
            l.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adoptie f = new Adoptie();
            f.ShowDialog();
        }
    }
}
