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

namespace My.Util.Organizer
{
    public partial class Direct_Downloader : Form
    {
        public Direct_Downloader()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = textBox1.Text.Split("\r\n".ToCharArray()).ToList();
            list.ForEach(x => Download(x));
        }

        private void Download(String url)
        {
            if (string.IsNullOrEmpty(url))
                return;

            using (WebClient ftpClient = new WebClient())
            {
                ftpClient.Credentials = new System.Net.NetworkCredential("anonymous", "janeDoe@contoso.com");
                string trnsfrpth = Path.Combine(textBox2.Text, url.Split('/').Last());
                ftpClient.DownloadFile(url, trnsfrpth);
            }
        }
        private void Download2(string url)
        {            
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("anonymous", "janeDoe@contoso.com");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Download Complete, status {0}", response.StatusDescription);

            reader.Close();
            response.Close();  
        }
    }
}
