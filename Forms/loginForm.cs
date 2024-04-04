using chatApp.Classes;
using chatApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
        dynamic mode;
        dynamic language;

        // Check setting from database
        private void setMode()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from [setting]", constring);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        // Check mode
                        if (row["uimode"].ToString() == "light1")
                        {
                            mode = new lightmode1();
                            pcBanner.Image = Resources.banner_login_light1;
                        }
                        else
                        {
                            mode = new lightmode2();
                            pcBanner.Image = Resources.banner_login_light2;
                        }

                        // Chek language
                        if (row["language"].ToString() == "Vietnamese")
                        {
                            language = new vietnamese();
                            lbLogin.Location = new System.Drawing.Point(80, 10);
                            lbQues.Location = new System.Drawing.Point(70, 261);
                            lnkLbForgetPass.Location = new System.Drawing.Point(90, 298);
                            lnkLbLogup.Location = new System.Drawing.Point(190, 261);
                        }
                        else
                        {
                            language = new english();
                        }
                    }
                }
            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, language.logupMess4);
                return;
            }
            else
                errorProvider1.SetError(txtUsername, string.Empty);

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, language.logupMess10);
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
                MessageBox.Show(language.loginMess1);

            con.Close();
        }

        private void lnkLbLogup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();

            logupForm logup = new logupForm();
            logup.ShowDialog();
        }

        private void lnkLbForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            pnForgetPass.Visible = true;
            pnLogin.Visible = false;
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            setMode();

            // Set enter event for controls
            txtUsername.KeyDown += new KeyEventHandler(_enterPress1);
            txtPassword.KeyDown += new KeyEventHandler(_enterPress1);
            txtEmail.KeyDown += new KeyEventHandler(_enterPress2);


            this.Controls.Add(pnForgetPass);
            pnForgetPass.Location = new Point(558, 134);

            pnLogin.Visible = true;
            pnForgetPass.Visible = false;

            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            errorProvider1.Clear();

            // Set color of buttons
            btnLogin.FillColor = mode.C1;
            btnSend.FillColor = mode.C1;

            // Set color of button bodercolor 
            txtUsername.HoverState.BorderColor = mode.C1;
            txtPassword.HoverState.BorderColor = mode.C1;
            txtEmail.HoverState.BorderColor = mode.C1;

            txtUsername.FocusedState.BorderColor = mode.C1;
            txtPassword.FocusedState.BorderColor = mode.C1;
            txtEmail.FocusedState.BorderColor = mode.C1;

            // Set language
            lbLogin.Text = language.lbLogin;
            txtUsername.PlaceholderText = language.txtUsername;
            txtPassword.PlaceholderText = language.txtPass;
            btnLogin.Text = language.btnLogin;
            lbQues.Text = language.lbLoginQues;
            lnkLbLogup.Text = language.linkLbLogup;
            lnkLbForgetPass.Text = language.linkLbForPass;

            lbForPass.Text = language.lbForPass;
            lbDesForPass.Text = language.lbDesForPass;
            txtEmail.PlaceholderText = language.txtEmail;
            btnSend.Text = language.btnSend;

        }

        private void _enterPress1(Object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void _enterPress2(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSend_Click(sender, e);
        }

        private void pcReturn_Click(object sender, EventArgs e)
        {
            loginForm_Load(sender, e);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, language.logupMess8);
                return;
            }
            else if (!ValidateEmail(txtEmail.Text.Trim()))
            {
                errorProvider1.SetError(txtEmail, language.logupMess9);
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, string.Empty);

                SqlConnection con = new SqlConnection(constring);
                string q = "select * from [user] where email = @email";


                // Create cmd and add para
                SqlCommand cmd = new SqlCommand(q, con);

                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    try
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress("kkirigaza76@gmail.com");
                        SmtpClient smtp = new SmtpClient();
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(mail.From.Address, "zzrggqqrtdqhrnnk");
                        smtp.Host = "smtp.gmail.com";

                        //recipient
                        mail.To.Add(new MailAddress(txtEmail.Text));
                        mail.IsBodyHtml = true;
                        mail.Subject = language.loginMess5;
                        mail.Body = language.loginMess4 + reader.GetString(6);

                        //for (int i = 0; i < attachmentFilename.Length; i++)
                        //    mail.Attachments.Add(new Attachment(attachmentFilename[i]));

                        smtp.Send(mail);
                        MessageBox.Show(language.loginMess2, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    txtEmail.Clear();
                    pcReturn_Click(sender, e);
                }
                else
                {
                    MessageBox.Show(language.loginMess3);
                } 
            }
        }
    }
}
