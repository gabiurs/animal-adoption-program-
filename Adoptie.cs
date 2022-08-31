using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_MTP
{
    public partial class Adoptie : Form
    {
        public Adoptie()
        {
            InitializeComponent();
        }

        private void Adoptie_Load(object sender, EventArgs e)
        {
            string connect = @"Data Source=GABI\WINCC;Initial Catalog=Animale;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connect);
            cnn.Open();
            string tabel_date = "select * from Mamifere";
            string tabel_date1 = "select * from pasari";
           string tabel_date2 = "select * from pesti";

            SqlDataAdapter da = new SqlDataAdapter(tabel_date, connect);
            SqlDataAdapter da1 = new SqlDataAdapter(tabel_date1, connect);
            SqlDataAdapter da2 = new SqlDataAdapter(tabel_date2, connect);

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            da.Fill(ds, "Mamifere");
            da1.Fill(ds1, "pasari");
            da2.Fill(ds2, "pesti");

            dataGridView1.DataSource = ds.Tables["Mamifere"].DefaultView;
            dataGridView2.DataSource = ds1.Tables["pasari"].DefaultView; 
            dataGridView3.DataSource = ds2.Tables["pesti"].DefaultView;
            cnn.Close();

        }

       
        private void button2_Click(object sender, EventArgs e)//cancel
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)//back la forma de meniu
        {
            Meniu f = new Meniu();
            f.ShowDialog();
            this.Hide();
           
        }
    }
}
