using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SceneClipse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listViewBookmark.Columns.Add("Time", 50);
            listViewBookmark.Columns.Add("dblTime", 0);
            listViewBookmark.Columns.Add("Caption", 80);
            listViewBookmark.LargeImageList = imageList1;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            axMediaPlayer1.URL = @"c:\Wildlife.wmv";
            timerPlayTime.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            axMediaPlayer1.Ctlcontrols.stop();
        }

        private void timerCurrentTime_Tick(object sender, EventArgs e)
        {
            string sCurrentTime = DateTime.Now.ToString("tt HH:mm:ss");
            labelTimeDisplay.Text = sCurrentTime;
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if( axMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused )
               axMediaPlayer1.Ctlcontrols.play();
            else if( axMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying )
               axMediaPlayer1.Ctlcontrols.pause();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFiledialog1 = new OpenFileDialog();
            // openFiledialog1.Filter = "Movie files|*.wmv";

            if( openFiledialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                axMediaPlayer1.URL = openFiledialog1.FileName;
                textBoxOpenFileName.Text = openFiledialog1.FileName;
                timerPlayTime.Start();

                // labelOpenFileName.Text = "재생중인 파일 : " + openFiledialog1.FileName;
            }

            
        }

        private void timerPlayTime_Tick(object sender, EventArgs e)
        {
            if (axMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying ||
                axMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                string sVideoTime = axMediaPlayer1.Ctlcontrols.currentPositionString;
                labelPlayTime.Text = "재생 중 : \n" + sVideoTime;
            }
            else
            {
                labelPlayTime.Text = "";
                timerPlayTime.Stop();
            }
        }

        private void buttonBookmark_Click(object sender, EventArgs e)
        {

            string sVideoTime = axMediaPlayer1.Ctlcontrols.currentPositionString;
            double dVideoTime = axMediaPlayer1.Ctlcontrols.currentPosition;

            // mediaplayer에서 이미지 가져오기
            using (Bitmap bitmap = new Bitmap(axMediaPlayer1.Width, axMediaPlayer1.Height - 76))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(axMediaPlayer1.PointToScreen(new System.Drawing.Point()).X,
                        axMediaPlayer1.PointToScreen(new System.Drawing.Point()).Y,
                        0, 0,
                        new System.Drawing.Size(
                            axMediaPlayer1.Width, axMediaPlayer1.Height - 76));

                }
                // 이미지 표시(디버그용)                }
                // bitmap.Save("e:\\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                // if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                // pictureBox1.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.PixelFormat.DontCare);
                imageList1.Images.Add(bitmap);
            }

            ListViewItem item = new ListViewItem(sVideoTime);
            item.SubItems.Add(dVideoTime.ToString());
            item.SubItems.Add("책갈피 " + sVideoTime);
            item.ImageIndex = imageList1.Images.Count;

            listViewBookmark.Items.Add(item);

            //listBookmark.DisplayMember = "sVideoTime";
            //listBookmark.Items.Add(item);          

        }

        private void listViewBookmark_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listViewBookmark_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedItems.Count > 0)
            {
                string sVideoTime = (sender as ListView).SelectedItems[0].SubItems[1].Text;
                double dVideoTime;
                double.TryParse(sVideoTime, out dVideoTime);

                axMediaPlayer1.Ctlcontrols.currentPosition = dVideoTime;

                pictureBox1.Image = imageList1.Images[(sender as ListView).SelectedItems[0].Index];
            }
        }
    }

    internal class BookmarkItem
    {
        public BookmarkItem(string s, double d)
        {
            sTimeBookmark = s;
            dTimeBookmark = d;
        }
        public string sTimeBookmark { get; set; }
        public double dTimeBookmark { get; set; }
    }
}
