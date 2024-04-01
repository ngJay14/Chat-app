using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace chatApp
{
    public partial class logupForm : Form
    {
        public logupForm()
        {
            InitializeComponent();
        }

        string constring = "Data Source=HUUNGUYEN;Initial Catalog=chatApp;Integrated Security=True;Encrypt=False";

        // Get the last record's id of user table
        public int getLastId()
        {
            int lastId = 0;

            SqlConnection conn = new SqlConnection(constring);

            SqlCommand myCommand = new SqlCommand("select top 1 * from [user] order by id desc", conn);

            conn.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();

            myReader.Read();

            if(myReader.HasRows)
            {
                lastId = int.Parse(myReader["id"].ToString());
            }

            conn.Close();

            return lastId;
        }

        // Check valid phone number
        public static bool IsPhoneNumber(string number)
        {
            return Regex.IsMatch(number, @"^\(?([0-9]{10})$");
        }

        // Check valid email
        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            string[] parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false; // email must have exactly one @ symbol
            }

            string localPart = parts[0];
            string domainPart = parts[1];
            if (string.IsNullOrWhiteSpace(localPart) || string.IsNullOrWhiteSpace(domainPart))
            {
                return false; // local and domain parts cannot be empty
            }

            // check local part for valid characters
            foreach (char c in localPart)
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '-')
                {
                    return false; // local part contains invalid character
                }
            }

            // check domain part for valid format
            if (domainPart.Length < 2 || !domainPart.Contains(".") || domainPart.Split('.').Length != 2 || domainPart.EndsWith(".") || domainPart.StartsWith("."))
            {
                return false; // domain part is not a valid format
            }

            return true;
        }

        // Check valid username
        public bool checkUsername(string username)
        {
            SqlConnection conn = new SqlConnection(constring);

            SqlCommand myCommand = new SqlCommand("select * from [user] where username = '"+ username +"'", conn);

            conn.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();

            if (myReader.HasRows)
            {
                return false;
            }

            conn.Close();

            return true;
        }

        // Exit button
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Sign up button
        private void bntSignup_Click(object sender, EventArgs e)
        {
            // Check empty value of ava picture
            if (pcAva.Image == null)
            {
                MessageBox.Show("Please select photo !");
            }

            // Check empty value of firstname textbox
            if (string.IsNullOrEmpty(txtFirstname.Text.Trim()))
            {
                errorProvider1.SetError(txtFirstname, "First name is required !");
                return;
            }
            else
                errorProvider1.SetError(txtFirstname, string.Empty);

            // Check empty value of lastname textbox
            if (string.IsNullOrEmpty(txtLastname.Text.Trim()))
            {
                errorProvider1.SetError(txtLastname, "Last name is required !");
                return;
            }
            else
                errorProvider1.SetError(txtLastname, string.Empty);

            // Check empty value of username textbox
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                errorProvider1.SetError(txtUsername, "Last name is required !");
                return;
            }
            else if (!checkUsername(txtUsername.Text.Trim()))
            {
                errorProvider1.SetError(txtUsername, "Username has existed !");
                return;
            }
            else
                errorProvider1.SetError(txtUsername, string.Empty);

            // Check empty value of phone number textbox
            if (string.IsNullOrEmpty(txtPhonenum.Text.Trim()))
            {
                errorProvider1.SetError(txtPhonenum, "Phone number is required !");
                return;
            }
            else if(!IsPhoneNumber(txtPhonenum.Text.Trim()))
            {
                errorProvider1.SetError(txtPhonenum, "Invalid phone number !");
                return;
            }
            else
                errorProvider1.SetError(txtPhonenum, string.Empty);

            // Check empty value of email textbox
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                errorProvider1.SetError(txtEmail, "Email is required !");
                return;
            }
            else if (!ValidateEmail(txtEmail.Text.Trim()))
            {
                errorProvider1.SetError(txtEmail, "Invalid email !");
                return;
            }
            else
                errorProvider1.SetError(txtEmail, string.Empty);

            // Check empty value of password textbox
            if (string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                errorProvider1.SetError(txtPass, "Password is required !");
                return;
            }
            else
                errorProvider1.SetError(txtPass, string.Empty);

            // Create connection and query
            SqlConnection con = new SqlConnection(constring);
            string q = "insert into [user](id,firstname,lastname,username,email,phone,password,ava) " +
                "values(@id,@firstname,@lastname,@username,@email,@phone,@password,@ava)";

            SqlCommand cmd = new SqlCommand(q, con);
            MemoryStream meme = new MemoryStream();

            pcAva.Image.Save(meme, pcAva.Image.RawFormat);

            int lastId = getLastId(); 

            // Add para for query
            cmd.Parameters.AddWithValue("@id", lastId + 1);
            cmd.Parameters.AddWithValue("@firstname", txtFirstname.Text.Trim());
            cmd.Parameters.AddWithValue("@lastname", txtLastname.Text.Trim());
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@phone", txtPhonenum.Text.Trim());
            cmd.Parameters.AddWithValue("@password", txtPass.Text.Trim());
            cmd.Parameters.AddWithValue("@ava", meme.ToArray());

            // Execute query
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sign up successfully !");

            // Show main Form
            this.Hide();
            mainForm mainForm = new mainForm();
            mainForm.username = txtUsername.Text.Trim();
            mainForm.Show();

        }

        private void pcAva_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "select image(*.jpg; *.png; *.gif|*.jpg; *.png; *.gif)";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pcAva.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void butLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            loginForm login = new loginForm();
            //login.FormClosed += (s, args) => {
            //    this.Close();
            //};
            login.Show();
        }

        private void pcAva_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Avatar", pcAva);
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
