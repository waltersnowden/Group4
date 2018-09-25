using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Group_4_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoginTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "Select * from logindetails where username = '" + txtUsername.Text.Trim() + "'and password = '" + txtPassword.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtdb = new DataTable();
            sda.Fill(dtdb);
            if (dtdb.Rows.Count == 1)
            {
                MessageBox.Show("Success");
                btnRegister.Visible = false;
                btnLogin.Visible = false;
                txtPassword.Visible = false;
                txtUsername.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
         

                Width = 577;
                Height = 376;
            }
            else
            {
                MessageBox.Show("Incorrect");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string constring = (@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoginTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "insert into logindetails (username, password) values('" + this.txtUsername.Text + "','" + this.txtPassword.Text + "') ";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDataBase = new SqlCommand(query, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("User has been added");
                while (myReader.Read())
                {

                }
            }
            catch
            {
                MessageBox.Show("error, wrong con string maybe?");
            }
        }
    }
}
