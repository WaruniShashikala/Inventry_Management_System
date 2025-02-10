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
            BindData();
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

        void BindData()
        {
            SqlCommand cmd = new SqlCommand("select * from inventory", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into inventory values('" + int.Parse(productid.Text) + "','" + (productName.Text) + "','" + (productType.Text) + "','" + (productQuntity.Text) + "','" + (productColor.Text) + "','" + (date.Text) + "') ",con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Insert Success..");
            con.Close();
            BindData();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update inventory set productName= '" + productName.Text + "',productType= '" + productType.Text + "',productQuntity= '" + productQuntity.Text + "',productColor='" + productColor.Text + "',date= '" + date.Text + "'"+ "where productid ='" + int.Parse(productid.Text) + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Update Success..");
            con.Close();
            BindData();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if(productid.Text != "")
            {
                if(MessageBox.Show("Are You Sure To Delete This Data ?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Delete inventory where productid= '" + int.Parse(productid.Text) + "'",con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Delete Success");
                    BindData();
                }
            }
            else
            {
                MessageBox.Show("Please Put ID");
            }
        }
    }
}
