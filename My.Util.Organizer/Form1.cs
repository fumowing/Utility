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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            List<string> list = textBox1.Text.Split("\n\r".ToArray()).ToList();
            list.ForEach(x => Download(x));
        }

        private void Download(string url)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString(url);
                    File.WriteAllText(Path.Combine(textBox2.Text, url.Split('/').Last()), json);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
