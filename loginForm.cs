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

namespace chatApp
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        string constring = "Data Source=HUUNGUYEN;Initial Catalog=chatApp;Integrated Security=True;Encrypt=False";

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            logupForm logup = new logupForm();
            logup.ShowDialog();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Email is required !");
                return;
            }
            else
                errorProvider1.SetError(txtUsername, string.Empty);

            if(string.IsNullOrEmpty(txtPassword.Text))
            { 
                errorProvider1.SetError(txtPassword, "Password is required !");
                return;
            }
            else
                errorProvider1.SetError(txtPassword, string.Empty);

            // Create connection and query
            SqlConnection con = new SqlConnection(constring);
            string q = "select * from [user] where username = @username and password = @password";


            // Create cmd and add para
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.HasRows)
            {
                con.Close();
                this.Hide();

                mainForm mainForm = new mainForm();
                mainForm.username = txtUsername.Text.Trim();

                mainForm.Show();
            }
            else
                MessageBox.Show("Invalid user. Please check email and password !");

            con.Close();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }
    }
}
