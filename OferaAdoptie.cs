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
    public partial class OferaAdoptie : Form
    {
        public OferaAdoptie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string connect = @"Data Source=GABI\WINCC;Initial Catalog=Animale;Integrated Security=True";
            //SqlConnection cnn = new SqlConnection(connect);
            //cnn.Open();

            string specie = textBox1.Text;
            if (specie == "mamifer")
            {
                string connect = @"Data Source=GABI\WINCC;Initial Catalog=Animale;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connect);
                cnn.Open();
                string stmt = "insert into Mamifere values (@spe, @n, @vr, @cul)";


                SqlCommand sc = new SqlCommand(stmt, cnn);
                sc.Parameters.AddWithValue("@spe", textBox1.Text);
                sc.Parameters.AddWithValue("@n", textBox2.Text);
                sc.Parameters.AddWithValue("@vr", textBox3.Text);
                sc.Parameters.AddWithValue("@cul", textBox4.Text);
                sc.ExecuteNonQuery();
                cnn.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if (specie == "pasari")
                {
                    string stmt = "insert into pasari values (@spe, @n, @vr, @cul)";

                    string connect = @"Data Source=GABI\WINCC;Initial Catalog=Animale;Integrated Security=True";
                    SqlConnection cnn = new SqlConnection(connect);
                    cnn.Open();
                    SqlCommand sc = new SqlCommand(stmt, cnn);
                    sc.Parameters.AddWithValue("@spe", textBox1.Text);
                    sc.Parameters.AddWithValue("@n", textBox2.Text);
                    sc.Parameters.AddWithValue("@vr", textBox3.Text);
                    sc.Parameters.AddWithValue("@cul", textBox4.Text);
                    sc.ExecuteNonQuery();
                    cnn.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (specie == "pesti")
                    {
                        string connect = @"Data Source=GABI\WINCC;Initial Catalog=Animale;Integrated Security=True";
                        SqlConnection cnn = new SqlConnection(connect);
                        cnn.Open();
                        string stmt = "insert into pesti values (@spe, @n, @vr, @cul)";
                        SqlCommand sc = new SqlCommand(stmt, cnn);
                        sc.Parameters.AddWithValue("@spe", textBox1.Text);
                        sc.Parameters.AddWithValue("@n", textBox2.Text);
                        sc.Parameters.AddWithValue("@vr", textBox3.Text);
                        sc.Parameters.AddWithValue("@cul", textBox4.Text);
                        sc.ExecuteNonQuery();
                        cnn.Close();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                        MessageBox.Show("aceasta specie nu este inregistrata!");
                }
            }

        }
    }
}
