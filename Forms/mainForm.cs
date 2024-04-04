using AxWMPLib;
using chatApp.Classes;
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

        dynamic mode;
        dynamic language;

        // List users in database into users panel
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
                            users[i].Color = mode.C3;

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

        // Set movement for this form using mouse
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

        // Load form
        private void mainForm_Load(object sender, EventArgs e)
        {
            pcReceiver.Image = null;
            lbFullnameReceiver.Text = "Fullname";
            lbUsernameReceiver.Text = "Username";

            this.Controls.Add(pnFile);
            pnFile.Location = new Point(377, 97);

            pnReceiver.Controls.Add(pnSearch);
            pnSearch.Location = new Point(377, 21);

            this.Controls.Add(pnImagesAndVideos);
            pnImagesAndVideos.Location = new Point(493, 515);

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
            setMode();  

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

        // Hover avatar picture
        private void pcAva_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(fullname, pcAva);
        }

        // Hover exit button
        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Red;
        }

        // Hover minimize button
        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.Gray;
        }

        // Mouse leave exit button
        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = SystemColors.ButtonFace;
        }

        // Mouse leave minimize button
        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor= SystemColors.ButtonFace;
        }

        // Exit button click
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Minimized button click
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Send button click
        private void btnSend_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            if (!string.Equals(txtChat.Text, "") && pcReceiver.Image != null && flPnChosenVideos.Controls.Count == 0 && flPnChosenImages.Controls.Count == 0)
            {
                string q = "insert into [chat](sender, receiver, message, time)values(@sender, @receiver, @message, @time)";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@sender", username);
                cmd.Parameters.AddWithValue("@receiver", lbUsernameReceiver.Text);
                cmd.Parameters.AddWithValue("@message", txtChat.Text);
                cmd.Parameters.AddWithValue("@time", DateTime.Now);

                cmd.ExecuteNonQuery();

                setControls();
                messageChat();
            }
            else if (flPnChosenImages.Controls.Count > 0 && pcReceiver.Image != null && txtChat.Text == "" && flPnChosenVideos.Controls.Count == 0 && pnEmotions.Visible == false)
            {
                Console.Write("true");
                string q = "insert into [chat](sender, receiver, image, time)values(@sender, @receiver, @image, @time)";

                foreach (PictureBox pic in flPnChosenImages.Controls)
                {
                    MemoryStream meme = new MemoryStream();
                    pic.Image.Save(meme, pic.Image.RawFormat);

                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@sender", username);
                    cmd.Parameters.AddWithValue("@receiver", lbUsernameReceiver.Text);
                    cmd.Parameters.AddWithValue("@image", meme.ToArray());
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
                setControls();
                messageChat();
            }
            else if (flPnChosenVideos.Controls.Count > 0 && flPnChosenImages.Controls.Count == 0 && txtChat.Text == "" && pnEmotions.Visible == false)
            {
                string q = "insert into [chat](sender, receiver, video, time)values(@sender, @receiver, @video, @time)";

                foreach (uctrlVideos vid in flPnChosenVideos.Controls)
                {
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@sender", username);
                    cmd.Parameters.AddWithValue("@receiver", lbUsernameReceiver.Text);
                    cmd.Parameters.AddWithValue("@video", vid.VidPath);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }

                setControls();
                messageChat();
            }
            else if (flPnChosenVideos.Controls.Count == 0 && flPnChosenImages.Controls.Count == 0 && txtChat.Text == "" && pnEmotions.Visible == true)
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

                cmd.ExecuteNonQuery();

                setControls();
                messageChat();
            }

            con.Close();
        }

        // Show message in chat panel
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

        // Logout button click
        private void btnLogout_Click(object sender, EventArgs e)
        {
            username = null;
            fullname = null;
            this.Hide();

            loginForm login = new loginForm();
            login.Show();
        }

        // Image button click
        private void btnImage_Click(object sender, EventArgs e)
        {
            if (pcReceiver.Image != null)
            {
                pnImagesAndVideos.Controls.Add(flPnChosenImages);
                flPnChosenImages.Location = new Point(3, 3);
                pnImagesAndVideos.Controls.Add(pcCloseImagePanel);

                openFileDialog1.Filter = "Select image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
                openFileDialog1.Multiselect = true;


                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach(String filePath in openFileDialog1.FileNames)
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Size = new Size(80, 80);
                        pictureBox.Image = System.Drawing.Image.FromFile(filePath);
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                        flPnChosenImages.Controls.Add(pictureBox);
                    }


                    flPnChosenImages.Visible = true;
                    flPnChosenVideos.Visible = false;
                    pnImagesAndVideos.Visible = true;

                    pnImagesAndVideos.BringToFront();
                    pnImagesAndVideos.Focus();
                }
                else
                {
                    flPnImages.Controls.Clear();
                    pnImagesAndVideos.Visible = false;
                }
            }
        }

        // Set controls for this form
        private void setControls()
        {
            flPnChosenVideos.Controls.Clear();
            flPnChosenImages.Controls.Clear();

            pnImagesAndVideos.Visible = false;
            pnEmotions.Visible = false;
            pnFile.Visible = false;
            pnChat.Visible = true;
            pnSearch.Visible = false;
            pnSetting.Visible = false;
            pnUsers.Visible = true;

            pnChat.Controls.Clear();
            flPnImages.Controls.Clear();
            flPnVideos.Controls.Clear();

            txtChat.Clear();
        }


        // Close image panel click
        private void pcCloseImagePanel_Click(object sender, EventArgs e)
        {
            flPnChosenVideos.Controls.Clear();
            flPnChosenImages.Controls.Clear();

            pnImagesAndVideos.Visible = false;
        }

        // Vidoe button click
        private void btnVideo_Click(object sender, EventArgs e)
        {
            pnImagesAndVideos.Controls.Clear();
            if (pcReceiver.Image != null)
            {
                pnImagesAndVideos.Controls.Add(flPnChosenVideos);
                flPnChosenVideos.Location = new Point(3, 3);
                pnImagesAndVideos.Controls.Add(pcCloseImagePanel);

                openFileDialog1.Filter = "Select video(*.mp4)|*.mp4";
                openFileDialog1.Multiselect = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (String filePath in openFileDialog1.FileNames)
                    {
                        uctrlVideos vid = new uctrlVideos();

                        vid.VidPath = filePath;
                        vid.minimize(80, 80, "none");

                        flPnChosenVideos.Controls.Add(vid);
                    }

                    pnImagesAndVideos.Visible = true;
                    flPnChosenImages.Visible = false;
                    flPnChosenVideos.Visible = true;

                    pnImagesAndVideos.BringToFront();
                    pnImagesAndVideos.Focus();
                }
                else
                {
                    flPnVideos.Controls.Clear();
                    pnImagesAndVideos.Visible = false;
                }
            }
        }

        // Sent files button click
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

        // Chat button click
        private void btnChat_Click(object sender, EventArgs e)
        {
            pnChat.Visible = true;
            pnUsers.Visible = true;

            pnUsers.BringToFront();
            pnChat.BringToFront();
        }

        // Sent files return button click
        private void btnReturn_Click(object sender, EventArgs e)
        {
            setControls();
            messageChat();
        }

        // Emotions button click
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

        // Close emotions panel click
        private void pcCloseEmoPanel_Click(object sender, EventArgs e)
        {
            pnEmotions.Visible = false;
        }

        // Message search button click
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

                    if (count == 0) MessageBox.Show(language.mainMess2);
                }
                else
                {
                    pnSearch.Visible = true;
                    pnSearch.BringToFront();
                }
            }    
        }

        // Close search panel click
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

        // Check setting from database
        private void setMode()
        {
            toolTip1.RemoveAll();
            
            SqlDataAdapter adapter = new SqlDataAdapter("select * from [setting]", constring);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        // Check uimode
                        if (row["uimode"].ToString() == "light1")
                        {
                            mode = new lightmode1();
                            radBtnLight1.Checked = true;
                        }
                        else
                        {
                            mode = new lightmode2();
                            radBtnLight2.Checked = true;
                        }

                        // Check language
                        if (row["language"].ToString() == "English")
                        {
                            language = new english();
                            comBxLanguge.SelectedIndex = 1;
                        }
                        else
                        {
                            language = new vietnamese();
                            comBxLanguge.SelectedIndex = 0;
                        }
                    }
                }
            }


            lightmode1 light = new lightmode1();
            lightmode2 dark = new lightmode2();

            // Set coloof panels
            pnTools.BackColor = mode.C1;
            pnUsers.BackColor = mode.C2;
            pnReceiver.BackColor = mode.C2;
            pnType.BackColor = mode.C2;
            pnChat.BackColor = mode.C3;
            pnFile.BackColor = mode.C3;
            btnSetSave.FillColor = mode.C1;

            // Set color of button in pnType
            btnSend.BackColor = mode.C1;
            btnEmotions.BackColor = mode.C4;
            btnImage.BackColor = mode.C4;
            btnVideo.BackColor = mode.C4;

            // Set control of setting panel
            pcLight1.FillColor = light.C1;
            pcLight2.FillColor = light.C2;
            pcLight3.FillColor = light.C3;
            pcLight4.FillColor = light.C4;

            pcDark1.FillColor = dark.C1;
            pcDark2.FillColor = dark.C2;
            pcDark3.FillColor = dark.C3;
            pcDark4.FillColor = dark.C4;

            // Set language for controls in this form
            radBtnLight1.Text = language.lightMode1;
            radBtnLight2.Text = language.lightMode2;
            lbLanguage.Text = language.lbLanguage;

            lbImages.Text = language.lbImage;
            lbVideos.Text = language.lbVideo;

            lbUsernameReceiver.Text = language.lbUsernameRec;
            lbFullnameReceiver.Text = language.lbFullnameRec;
            btnSetSave.Text = language.btnSetSave;
            txtChat.PlaceholderText = language.txtMess;
            txtSearch.PlaceholderText = language.txtSearch;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            pnSetting.Visible = true;
            pnUsers.Visible = false;

            pnSetting.BringToFront();
        }

        private void btnSetSave_Click(object sender, EventArgs e)
        {
            string lang = comBxLanguge.SelectedItem.ToString();

            string uimode;
            if (radBtnLight1.Checked) uimode = "light1";
            else uimode = "light2";

            SqlConnection con = new SqlConnection(constring);
            con.Open();

            string q = "update [setting]" +
                "set uimode=@uimode, language=@language";

            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@uimode", uimode);
            cmd.Parameters.AddWithValue("@language", lang);

            cmd.ExecuteNonQuery();

            MessageBox.Show(language.mainMess1);

            mainForm_Load(sender, e);
        }

        private void btnChat_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(language.tooltipBtnMessage, btnChat);
        }

        private void btnSetting_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(language.tooltipBtnSetting, btnSetting);
        }

        private void btnLogout_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(language.tooltipBtnLogout, btnLogout);
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(language.tooltipSearch, btnSearch);
        }

        private void btnFiles_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(language.tooltipFile, btnFiles);
        }

        private void btnVideo_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(language.tooltipVideo, btnVideo);
        }

        private void btnImage_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(language.tooltipImage, btnImage);
        }

        private void btnEmotions_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(language.tooltipEmo, btnEmotions);
        }

        private void btnSend_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(language.tooltipSend, btnSend);
        }

        private void pnImagesAndVideos_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
        }

        private void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                txtChat.AppendText(Environment.NewLine);
            }
        }

        private void txtChat_TextChanged(object sender, EventArgs e)
        {
            if (txtChat.Text == Environment.NewLine)
            {
                txtChat.Clear();
            }
        }
    }
}
