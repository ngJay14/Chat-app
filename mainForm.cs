using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace chatApp
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        public string username { get; set; }
        public string fullname { get; set; }

        string constring = "Data Source=HUUNGUYEN;Initial Catalog=chatApp;Integrated Security=True;Encrypt=False";

        int togMove;
        int mValx;
        int mValy;

        private void usersItem()
        {
            pnUsers.Controls.Clear();

            SqlDataAdapter adapter = new SqlDataAdapter("select * from [user]", constring);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if(dt != null )
            {
                if(dt.Rows.Count > 0)
                {
                    uctrlUsers[] users = new uctrlUsers[dt.Rows.Count];

                    for(int i = 0; i < 1; i++)
                    {
                        foreach(DataRow row in dt.Rows)
                        {
                            users[i] = new uctrlUsers();

                            MemoryStream stream = new MemoryStream((byte[])row["ava"]);

                            users[i].Ava = new Bitmap(stream);
                            users[i].Username = row["username"].ToString();
                            users[i].Fullname = $"{row["firstname"]} {row["lastname"]}";

                            users[i].Click += (sender, e) =>
                            {
                                pcReceiver.Image = new Bitmap(stream);
                                lbUsernameReceiver.Text = row["username"].ToString();
                                lbFullnameReceiver.Text = $"{row["firstname"]} {row["lastname"]}";

                                pnChat.Controls.Clear();
                                setControls();
                                messageChat();
                            };

                            if (users[i].Username == username)
                            {
                                pnUsers.Controls.Remove(users[i]);
                            }
                            else
                            {
                                pnUsers.Controls.Add(users[i]);
                            }
                        }
                    }
                }
            }
        }

        private void mainForm_MouseDown(object sender, MouseEventArgs e)
        {
            togMove = 1;
            mValx = e.X;
            mValy = e.Y;
        }

        private void mainForm_MouseUp(object sender, MouseEventArgs e)
        {
            togMove = 0;
        }

        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (togMove == 1) 
            {
                this.SetDesktopLocation(MousePosition.X - mValx, MousePosition.Y - mValy);
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void mainForm_Load(object sender, EventArgs e)
        {

            this.Controls.Add(pnFile);
            pnFile.Location = new Point(380, 97);

            pnReceiver.Controls.Add(pnSearch);
            pnSearch.Location = new Point(377, 21);

            pcEmo1.Click += new EventHandler(this.btnSend_Click);
            pcEmo2.Click += new EventHandler(this.btnSend_Click);
            pcEmo3.Click += new EventHandler(this.btnSend_Click);
            pcEmo4.Click += new EventHandler(this.btnSend_Click);
            pcEmo5.Click += new EventHandler(this.btnSend_Click);
            pcEmo6.Click += new EventHandler(this.btnSend_Click);
            pcEmo7.Click += new EventHandler(this.btnSend_Click);
            pcEmo8.Click += new EventHandler(this.btnSend_Click);
            pcEmo9.Click += new EventHandler(this.btnSend_Click);
            pcEmo10.Click += new EventHandler(this.btnSend_Click);

            setControls();

            SqlConnection con = new SqlConnection(constring);
            con.Open();

            string q = "select * from [user] where username = '"+ username +"'";

            SqlCommand cmd = new SqlCommand(q, con);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            if(reader.HasRows) 
            {
                byte[] ava = (byte[]) reader["ava"];
                fullname = $"{reader["firstname"]} {reader["lastname"]}";

                if (ava == null)
                    pcAva.Image = null;
                else
                {
                    MemoryStream me = new MemoryStream(ava);
                    pcAva.Image = System.Drawing.Image.FromStream(me);
                    pcAva.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            con.Close();

            lbName.Text = $"Chatoo - {fullname}";


            usersItem();
        }

        private void pcAva_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(fullname, pcAva);
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Red;
        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.Gray;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = SystemColors.ButtonFace;
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor= SystemColors.ButtonFace;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);

            if (txtChat.Text != "" && pcReceiver.Image != null && videoPlayer.URL == "" && pcImageChosen.Image == null)
            {
                string q = "insert into [chat](sender, receiver, message, time)values(@sender, @receiver, @message, @time)";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@sender", username);
                cmd.Parameters.AddWithValue("@receiver", lbUsernameReceiver.Text);
                cmd.Parameters.AddWithValue("@message", txtChat.Text);
                cmd.Parameters.AddWithValue("@time", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();

                setControls();
                messageChat();
            }
            else if (pcImageChosen.Image != null && pcReceiver.Image != null && txtChat.Text == "" && videoPlayer.URL == "")
            {
                MemoryStream meme = new MemoryStream();
                pcImageChosen.Image.Save(meme, pcImageChosen.Image.RawFormat);

                string q = "insert into [chat](sender, receiver, image, time)values(@sender, @receiver, @image, @time)";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@sender", username);
                cmd.Parameters.AddWithValue("@receiver", lbUsernameReceiver.Text);
                cmd.Parameters.AddWithValue("@image", meme.ToArray());
                cmd.Parameters.AddWithValue("@time", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();

                setControls();
                messageChat();
            }
            else if (videoPlayer.URL != "" && pcImageChosen.Image == null && txtChat.Text == "")
            {
                string q = "insert into [chat](sender, receiver, video, time)values(@sender, @receiver, @video, @time)";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@sender", username);
                cmd.Parameters.AddWithValue("@receiver", lbUsernameReceiver.Text);
                cmd.Parameters.AddWithValue("@video", videoPlayer.URL);
                cmd.Parameters.AddWithValue("@time", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();

                setControls();
                messageChat();
            }
            else if (videoPlayer.URL == "" && pcImageChosen.Image == null && txtChat.Text == "" && pnEmotions.Visible == true)
            {
                PictureBox icon = (PictureBox) sender;
                MemoryStream meme = new MemoryStream();
                icon.Image.Save(meme, icon.Image.RawFormat);

                string q = "insert into [chat](sender, receiver, icon, time)values(@sender, @receiver, @icon, @time)";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@sender", username);
                cmd.Parameters.AddWithValue("@receiver", lbUsernameReceiver.Text);
                cmd.Parameters.AddWithValue("@icon", meme.ToArray());
                cmd.Parameters.AddWithValue("@time", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();

                setControls();
                messageChat();
            }

            con.Close();
        }

        private void messageChat()
        {
            int prey_ctrlMessage = 0;
            int padding = 20;

            SqlDataAdapter adapter;
            adapter = new SqlDataAdapter("select * from [chat] order by time asc", constring);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if(dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DateTime time = (DateTime)row["time"];

                    // If message is text value
                    if (row["message"] != DBNull.Value && row["image"] == DBNull.Value && row["video"] == DBNull.Value)
                    {
                        if (username == row["sender"].ToString() && lbUsernameReceiver.Text == row["receiver"].ToString())
                        {
                            uctrlMessTextSen txtSen = new uctrlMessTextSen();
                            //txtSen.Message = row["message"].ToString().Replace("\r\n", "<br />");
                            txtSen.Message = row["message"].ToString();
                            txtSen.Time = time.ToString("HH:mm:ss dd/MM/yyyy");

                            pnChat.Controls.Add(txtSen);
                            pnChat.ScrollControlIntoView(txtSen);

                            txtSen.Location = new Point((754 - txtSen.Width - padding), prey_ctrlMessage);

                            prey_ctrlMessage += txtSen.Height;
                        }
                        else if (username == row["receiver"].ToString() && lbUsernameReceiver.Text == row["sender"].ToString())
                        {
                            uctrlMessTextRec txtRec = new uctrlMessTextRec();
                            txtRec.Ava = pcReceiver.Image;
                            //txtRec.Message = row["Message"].ToString().Replace("\r\n", "<br
                            txtRec.Message = row["Message"].ToString();
                            txtRec.Time = time.ToString("HH:mm:ss dd/MM/yyyy");

                            pnChat.Controls.Add(txtRec);
                            pnChat.ScrollControlIntoView(txtRec);

                            txtRec.Location = new Point(5, prey_ctrlMessage);

                            prey_ctrlMessage += txtRec.Height;
                        }
                    }
                    // If message is image value
                    else if (row["image"] != DBNull.Value && row["message"] == DBNull.Value && row["video"] == DBNull.Value)
                    {
                        MemoryStream stream = new MemoryStream((byte[])row["image"]);

                        if (username == row["sender"].ToString() && lbUsernameReceiver.Text == row["receiver"].ToString())
                        {
                            uctrlMessImageSen imageSen = new uctrlMessImageSen();
                            imageSen.Image = new Bitmap(stream);
                            imageSen.Time = time.ToString("HH:mm:ss dd/MM/yyyy");

                            pnChat.Controls.Add(imageSen);
                            pnChat.ScrollControlIntoView(imageSen);

                            imageSen.Location = new Point((754 - imageSen.Width - padding), prey_ctrlMessage);

                            prey_ctrlMessage += imageSen.Height;
                        }
                        else if (username == row["receiver"].ToString() && lbUsernameReceiver.Text == row["sender"].ToString())
                        {
                            uctrlMessImageRec imageRec = new uctrlMessImageRec();
                            imageRec.Ava = pcReceiver.Image;
                            imageRec.Image = new Bitmap(stream);
                            imageRec.Time = time.ToString("HH:mm:ss dd/MM/yyyy");

                            pnChat.Controls.Add(imageRec);
                            pnChat.ScrollControlIntoView(imageRec);

                            imageRec.Location = new Point(5, prey_ctrlMessage);

                            prey_ctrlMessage += imageRec.Height;
                        }
                    }
                    // If message is video value
                    else if (row["video"] != DBNull.Value && row["image"] == DBNull.Value && row["message"] == DBNull.Value)
                    {
                        if (username == row["sender"].ToString() && lbUsernameReceiver.Text == row["receiver"].ToString())
                        {
                            uctrlMessVideoSen videoSen = new uctrlMessVideoSen();
                            videoSen.VidPath = row["video"].ToString();
                            videoSen.Time = time.ToString("HH:mm:ss dd/MM/yyyy");

                            pnChat.Controls.Add(videoSen);
                            pnChat.ScrollControlIntoView(videoSen);

                            videoSen.Location = new Point((754 - videoSen.Width - padding), prey_ctrlMessage);

                            prey_ctrlMessage += videoSen.Height;
                        }
                        else if (username == row["receiver"].ToString() && lbUsernameReceiver.Text == row["sender"].ToString())
                        {
                            uctrlMessVideoRec videoRec = new uctrlMessVideoRec();
                            videoRec.Ava = pcReceiver.Image;
                            videoRec.VidPath = row["video"].ToString();
                            videoRec.Time = time.ToString("HH:mm:ss dd/MM/yyyy");

                            pnChat.Controls.Add(videoRec);
                            pnChat.ScrollControlIntoView(videoRec);

                            videoRec.Location = new Point(5, prey_ctrlMessage);

                            prey_ctrlMessage += videoRec.Height;
                        }
                    }
                    // If message is icon value
                    else if (row["icon"] != DBNull.Value && row["video"] == DBNull.Value && row["image"] == DBNull.Value && row["message"] == DBNull.Value)
                    {
                        MemoryStream streamIcon = new MemoryStream((byte[])row["icon"]);

                        if (username == row["sender"].ToString() && lbUsernameReceiver.Text == row["receiver"].ToString())
                        {
                            uctrlMessIconSen iconSen = new uctrlMessIconSen();
                            iconSen.Icon = new Bitmap(streamIcon);
                            iconSen.Time = time.ToString("HH:mm:ss dd/MM/yyyy");

                            pnChat.Controls.Add(iconSen);
                            pnChat.ScrollControlIntoView(iconSen);

                            iconSen.Location = new Point((754 - iconSen.Width - padding), prey_ctrlMessage);

                            prey_ctrlMessage += iconSen.Height;
                        }
                        else if (username == row["receiver"].ToString() && lbUsernameReceiver.Text == row["sender"].ToString())
                        {
                            uctrlMessIconRec iconRec = new uctrlMessIconRec();
                            iconRec.Ava = pcReceiver.Image;
                            iconRec.Icon = new Bitmap(streamIcon);
                            iconRec.Time = time.ToString("HH:mm:ss dd/MM/yyyy");

                            pnChat.Controls.Add(iconRec);
                            pnChat.ScrollControlIntoView(iconRec);

                            iconRec.Location = new Point(5, prey_ctrlMessage);

                            prey_ctrlMessage += iconRec.Height;
                        }
                    }
                }
                pnChat.VerticalScroll.Value = pnChat.VerticalScroll.Maximum;
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            username = null;
            fullname = null;
            this.Hide();

            loginForm login = new loginForm();
            login.Show();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            if (pcReceiver.Image != null)
            {
                this.Controls.Add(pnImage);

                pnImage.Location = new Point(493, 541);
                pnImage.Controls.Add(pcImageChosen);
                pnImage.Controls.Add(pcCloseImagePanel);

                openFileDialog1.Filter = "Select image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pcImageChosen.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                    pcImageChosen.Visible = true;
                    videoPlayer.Visible = false;
                    pnImage.Visible = true;
                    pnImage.BringToFront();
                }
                else
                    pnImage.Visible = false;
            }
        }

        private void setControls()
        {
            videoPlayer.URL = "";
            pcImageChosen.Image = null;
            pnImage.Visible = false;
            pnEmotions.Visible = false;
            pnFile.Visible = false;
            pnChat.Visible = true;
            pnSearch.Visible = false;

            pnChat.Controls.Clear();
            flPnImages.Controls.Clear();
            flPnVideos.Controls.Clear();

            txtChat.Clear();
        }

        private void pcCloseImagePanel_Click(object sender, EventArgs e)
        {
            setControls();
        }

        private void btnVideo_Click(object sender, EventArgs e)
        {
            pnImage.Controls.Clear();
            if (pcReceiver.Image != null)
            {
                this.Controls.Add(pnImage);

                pnImage.Location = new Point(493, 541);
                pnImage.Controls.Add(pcCloseImagePanel);
                pnImage.Controls.Add(videoPlayer);

                openFileDialog1.Filter = "Select video(*.mp4)|*.mp4";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    videoPlayer.uiMode = "none";
                    videoPlayer.URL = openFileDialog1.FileName;

                    pnImage.Visible = true;
                    pcImageChosen.Visible = false;
                    videoPlayer.Visible = true;

                    pnImage.BringToFront();
                }
                else
                    pnImage.Visible = false;

                pnImage.BringToFront();

            }
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            setControls();

            if (pcReceiver.Image != null)
            {
                pnChat.Visible = false;
                pnFile.Visible = true;
                pnFile.BringToFront();

                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter("select * from [chat] order by time asc", constring);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["sender"].ToString() == username && row["receiver"].ToString() == lbUsernameReceiver.Text
                            || row["receiver"].ToString() == username && row["sender"].ToString() == lbUsernameReceiver.Text)
                        {
                            if (row["image"] != DBNull.Value && row["message"] == DBNull.Value && row["video"] == DBNull.Value)
                            {
                                MemoryStream stream = new MemoryStream((byte[])row["image"]);

                                uctrlImage image = new uctrlImage();
                                image.Image = new Bitmap(stream);

                                flPnImages.Controls.Add(image);
                            }
                            else if (row["video"] != DBNull.Value && row["image"] == DBNull.Value && row["message"] == DBNull.Value)
                            {
                                uctrlVideos video = new uctrlVideos();
                                video.VidPath = row["video"].ToString();

                                flPnVideos.Controls.Add(video);
                            }
                        }
                    }
                }
            }
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            pnChat.Visible = true;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            setControls();
            messageChat();
        }

        private void btnEmotions_Click(object sender, EventArgs e)
        {
            if (pcReceiver.Image != null)
            {
                this.Controls.Add(pnEmotions);

                pnEmotions.Location = new Point(493, 562);

                pnEmotions.Visible = true;
                pnEmotions.BringToFront(); 
            }
        }

        private void pcCloseEmoPanel_Click(object sender, EventArgs e)
        {
            pnEmotions.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int count = 0;

            if (pcReceiver.Image != null && pnChat.Visible == true)
            {
                if (pnSearch.Visible && txtSearch.Text != "")
                {
                    foreach (var ctl in pnChat.Controls)
                    {
                        if (ctl is uctrlMessTextSen)
                        {
                            uctrlMessTextSen messSen = ctl as uctrlMessTextSen;
                            if (messSen.searchMess(txtSearch.Text)) count++;
                        }
                        else if (ctl is uctrlMessTextRec)
                        {
                            uctrlMessTextRec messRec = ctl as uctrlMessTextRec;
                            if (messRec.searchMess(txtSearch.Text)) count++;
                        }
                    }

                    if (count == 0) MessageBox.Show("Message not found !");
                }
                else
                {
                    pnSearch.Visible = true;
                    pnSearch.BringToFront();
                }
            }    
        }

        private void pcCloseSearchPanel_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            pnSearch.Visible=false;

            foreach (var ctl in pnChat.Controls)
            {
                if (ctl is uctrlMessTextSen)
                {
                    uctrlMessTextSen messSen = ctl as uctrlMessTextSen;
                    messSen.unSearchMess();
                }
                else if (ctl is uctrlMessTextRec)
                {
                    uctrlMessTextRec messRec = ctl as uctrlMessTextRec;
                    messRec.unSearchMess();
                }
            }
        }
    }
}
