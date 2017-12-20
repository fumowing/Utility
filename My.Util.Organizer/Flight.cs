using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace My.Util.Organizer
{
    public partial class Flight : Form
    {
        public Flight()
        {
            InitializeComponent();
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            try
            {
                string url = txtAddress.Text;
                List<String> result = new List<string>();
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                //ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AllwaysGoodCertificate);
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = false;
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    MessageBox.Show(response.ResponseUri.OriginalString);
                    WebHeaderCollection header = response.Headers;

                    var encoding = ASCIIEncoding.ASCII;
                    using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                    {
                        string responseText = reader.ReadToEnd();
                        MessageBox.Show(responseText);
                    }
                }

                //string page = "";
                //using (WebClient webClient = new WebClient())
                //{
                //    var stream = webClient.OpenRead(url);
                //    using (StreamReader sr = new StreamReader(stream))
                //    {
                //        page = sr.ReadToEnd();
                //    }
                //}

                WebClient wc = new WebClient();
                string data = wc.DownloadString(url);
                HtmlAgilityPack.HtmlDocument resultat = new HtmlAgilityPack.HtmlDocument();
                resultat.LoadHtml(data);
                string downloaded = string.Empty;
                List<HtmlNode> screenreaders = resultat.DocumentNode.Descendants().Where
                    (x => (x.Name == "span" && x.GetAttributeValue("class", "").ToLower().Contains("screenreader"))).ToList();
                screenreaders.ForEach(a =>
                {
                    result.Add(string.Format("{0}", a.InnerHtml));
                }
                );
                MessageBox.Show(result.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //https://booking.jetstar.com/sg/en/booking/search-flights?s=true&adults=4&children=1&infants=0&currency=SGD&mon=true&r=true&channel=DESKTOP&origin1=SIN&destination1=HKG&departuredate1=2017-08-03&origin2=HKG&destination2=SIN&departuredate2=2017-08-06
            string url = string.Format("https://booking.jetstar.com/sg/en/booking/search-flights?s=true&adults={0}&children={1}&infants=0&currency=SGD&mon=true&r=true&channel=DESKTOP&origin1={5}&destination1={2}&departuredate1={3}&origin2={2}&destination2={5}&departuredate2={4}"
                , 2, 1, "CGK", "2017-08-03", "2017-08-03", "SIN");

            string url2 = string.Format("https://booking.jetstar.com/sg/en/booking/search-flights?s=true&adults={0}&children={1}&infants=0&currency=SGD&mon=true&r=true&channel=DESKTOP&origin1={5}&destination1={2}&departuredate1={3}&origin2={2}&destination2={5}&departuredate2={4}"
                , Convert.ToInt32(numAdult.Value), Convert.ToInt32(numChildren.Value)
                , txtDest.Text, dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"), txtSrc.Text);

            OpenChrome(url);
            OpenChrome(url2);
        }

        private void OpenChrome(string url)
        {
            //name = HttpUtility.UrlEncode(name);
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", url);
        }

    }
}
