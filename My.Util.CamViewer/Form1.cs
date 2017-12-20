using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My.Util.CamViewer
{
    public partial class Form1 : Form
    {
        ThreadPool pool = new ThreadPool();
        public Form1()
        {
            InitializeComponent();
            button3.Enabled = false;
            button4.Enabled = false;
            //timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var url = "http://192.168.0.16/video/mjpg.cgi";
            //var url = "http://192.168.0.16/video.cgi?resolution=VGA";
            //SaveStream(url, "living");
            var url = txtLiving.Text;
            pool.LaunchThreads(txtSaveFolder.Text, "living", url);
            button1.Enabled = false;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var url = "http://192.168.0.25/video/mjpg.cgi";
            //SaveStream(url, "celine");
            var url = txtBR2.Text;
            pool.LaunchThreads(txtSaveFolder.Text, "celine", url);
            button2.Enabled = false;
            button4.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pool.KillThread("living");
            button3.Enabled = false;
            button1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pool.KillThread("celine");
            button4.Enabled = false;
            button2.Enabled = true;
        }

        private void SaveStream(string url, string file)
        {
            WebClient webClient = new WebClient();
            webClient.Credentials = new NetworkCredential("admin", "Elyssia1602");

            //var url = "http://192.168.0.25/video/mjpg.cgi";
            //var url = "http://192.168.0.16/video/mjpg.cgi";
            //url = "http://192.168.0.16/video.cgi?resolution=VGA";
            string outputFile = txtSaveFolder.Text + "\\recording"+ file + DateTime.Now.ToString("yyyyMMddHHmmss") +".mp4";
            // Download the file and write it to disk
            using (Stream webStream = webClient.OpenRead(url))
            using (FileStream fileStream = new FileStream(outputFile, FileMode.Create))
            {
                var buffer = new byte[32768];
                int bytesRead;
                Int64 bytesReadComplete = 0;  // Use Int64 for files larger than 2 gb

                // Get the size of the file to download
                Int64 bytesTotal = Convert.ToInt64(webClient.ResponseHeaders["Content-Length"]);

                // Download file in chunks
                while ((bytesRead = webStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bytesReadComplete += bytesRead;
                    fileStream.Write(buffer, 0, bytesRead); fileStream.FlushAsync();
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StopDownload();
            StartDownload();
        }

        private void TryClick(Button btn)
        {
            if (btn.Enabled)
                btn.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            timer1.Stop();
            StopDownload();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            var start = DateTime.Now.Date.AddHours(dateTimePicker1.Value.Hour)
                .AddMinutes(dateTimePicker1.Value.Minute)
                .AddSeconds(dateTimePicker1.Value.Second);
            var end = DateTime.Now.Date.AddHours(dateTimePicker2.Value.Hour)
                .AddMinutes(dateTimePicker2.Value.Minute)
                .AddSeconds(dateTimePicker2.Value.Second);

            if (DateTime.Now >= start && !timer1.Enabled)
            {
                StartDownload();
                timer1.Interval = Convert.ToInt32(numericUpDown1.Value * 1000);
                timer1.Start();
            }
            if (DateTime.Now >= end)
            {
                timer1.Stop();
                StopDownload();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void StartDownload()
        {
            if(chkLiving.Checked)
                TryClick(button1);
            if(chkBR2.Checked)
                TryClick(button2);
        }

        private void StopDownload()
        {
            if (chkLiving.Checked)
                TryClick(button3);
            if (chkBR2.Checked)
                TryClick(button4);        
        }

    }
}
