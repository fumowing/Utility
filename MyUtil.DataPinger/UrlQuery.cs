using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtil.DataPinger
{
    public partial class UrlQuery : Form
    {
        public UrlQuery()
        {
            InitializeComponent();
            LoadCOnfig();
        }

        private void LoadCOnfig()
        {
            string configvalue1 = ConfigurationManager.AppSettings["UrlList"];
            string configvalue2 = ConfigurationManager.AppSettings["LogPath"];
            string[] urls = configvalue1.Split('|');
            foreach (string url in urls)
            {
                lbUrl.Items.Add(url);
            }
            txtLogPath.Text = configvalue2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
                StartTimer();
            else
                StopTimer();
        }

        private void StartTimer()
        {
            timer1.Interval = Convert.ToInt32(nudInterval.Value * 1000);
            timer1.Start();
            button1.Text = "Stop";
        }

        private void StopTimer()
        {
            timer1.Stop();
            button1.Text = "Start";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DoRequest();
        }

        private void btnAddUrl_Click(object sender, EventArgs e)
        {
            string uriName = txtUrl.Text;
            Uri uriResult;
            bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult) 
                && uriResult.Scheme == Uri.UriSchemeHttp;
            if (result)
            {
                lbUrl.Items.Add(txtUrl.Text);
            }
            else
            {
                MessageBox.Show("Please key in a valid url");
            }
        }

        private void DoRequest()
        {
            foreach (string item in lbUrl.Items)
            {
                LoadPage(item);
            }
        }

        private void LoadPage(string url)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            string msg = "success";
            string response = "";

            try
            {
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //Stream stream = response.GetResponseStream();
                response = GetResponse(url);
                //MessageBox.Show(response);
                end = DateTime.Now;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                end = DateTime.Now;
            }
            finally
            {
                WriteLog(url, msg, start, end, response);
            }
        }

        private string GetResponse(String url)
        {

            string strResponse = "";
            WebClient clnt = new WebClient();

            //Get string response
            try
            {
                strResponse = clnt.DownloadString(url);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return strResponse;
        }

        private void WriteLog(string url, string msg, DateTime start, DateTime end, string response)
        {
            StreamWriter sw = new StreamWriter(txtLogPath.Text, true);
            TimeSpan ts = end - start;
            string res = string.Format("{0} Loading Page '{3}', result : '{1}', execution time : '{2}' ms "
                , start.ToString("yyyy MM dd HH:mm:ss"), msg, ts.TotalMilliseconds, url);
            sw.WriteLine(res);
            if (checkBox1.Checked)
                sw.WriteLine(response);
            sw.Flush();
            sw.Close();
            lbLog.Items.Add(res);

        }

        private void lbUrl_DoubleClick(object sender, EventArgs e)
        {
            lbUrl.Items.RemoveAt(lbUrl.SelectedIndex);            
        }


    }
}
