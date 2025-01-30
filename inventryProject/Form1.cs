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

namespace inventryProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9L1GMLB;Initial Catalog=inventory;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into inventory values('" + int.Parse(productid.Text) + "','" + (productName.Text) + "','" + (productType.Text) + "','" + (productQuntity.Text) + "','" + (productColor.Text) + "','" + (date.Text) + "') ",con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Insert Success..");
            con.Close();
        }
    }
}
