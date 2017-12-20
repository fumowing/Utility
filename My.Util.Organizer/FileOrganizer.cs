using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace My.Util.Organizer
{
    public partial class FileOrganizer : Form
    {
        public FileOrganizer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = "D:\\Anime\\Downloads";
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessFolder(txtPath.Text, 2);
            MessageBox.Show("Completed!");
        }

        private void ProcessFolder(string folder, int level)
        {
            DirectoryInfo di = new DirectoryInfo(folder);
            foreach (FileInfo file in di.GetFiles())
            {
                string title = GetTitle(file);
                string path = CreateFolder(folder, title, file.Name);
                if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(title))
                {
                    MoveFile(file, path);
                }
            }
            level--;
            if (level != 0)
            {
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    ProcessFolder(dir.FullName, level);
                }
            }
        }

        private void MoveFile(FileInfo file, string path)
        {
            string dest = Path.Combine(path, file.Name);
            File.Move(file.FullName, dest);
            WriteLog(string.Format("File moved {0} -> {1}", file.FullName, dest));
        }
        private void MoveFile(FileInfo file, string path, string newName)
        {
            string dest = Path.Combine(path, newName);
            File.Move(file.FullName, dest);
            WriteLog(string.Format("File moved {0} -> {1}", file.FullName, dest));
        }

        private void WriteLog(string msg)
        {
            if (!chkWriteLog.Checked)
                return;

            string file = Path.Combine(txtPath.Text, string.Format("{0}.log", DateTime.Now.ToString("yyyyMMdd")));
            StreamWriter sw = new StreamWriter(file, true);
            sw.WriteLine(string.Format("{0} : {1}", DateTime.Now.ToShortTimeString(), msg));
            sw.Flush();
            sw.Close();
            //throw new NotImplementedException();
        }

        private string GetTitle(FileInfo file)
        {
            MatchCollection mc = GetMatches(file.FullName);
            string title = "";
            foreach (Match m in mc)
            {
                title = m.Groups["name"].Value;
                //MessageBox.Show();
            }
            return title;
        }

        private string CreateFolder(string path, string title, string fileName)
        {
            string folderPath = Path.Combine(path, title);
            if(!Directory.Exists(folderPath) && (new DirectoryInfo(path)).Name != title )
            {
                if (chkPrompt.Checked && MessageBox.Show("Do you want to create folder '" + title + "'?", fileName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Directory.CreateDirectory(folderPath);
                    WriteLog(string.Format("Folder Created : {0}", folderPath));
                }
                else
                {
                    folderPath = CheckOther(path, title);
                    if (folderPath != string.Empty)
                    {
                        if (MessageBox.Show("Do you want to move in '" + folderPath + "'?", fileName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                        {
                            folderPath = string.Empty;
                        }
                    }
                }
            }
            if ((new DirectoryInfo(path)).Name == title)
                folderPath = string.Empty;
            return folderPath;
        }

        private string CheckOther(string path, string title)
        {
            string result = string.Empty;
            DirectoryInfo baseDir = new DirectoryInfo(path);
            DirectoryInfo parent = baseDir.Parent;
            if (parent != null)
            {
                foreach (DirectoryInfo dir in parent.GetDirectories().Where(x => x.FullName != path).ToList())
                {
                    string folderPath = Path.Combine(dir.FullName, title);
                    if (Directory.Exists(folderPath))
                    {
                        result = folderPath;
                        break;
                    }
                }
            }
            return result;
        }
        public static MatchCollection GetMatches(string strInput)
        {
            //Regex regex = new Regex(@"(?<=%download%#)\d+");
            Regex regex = new Regex(@"\[.*\] (?<name>.*) - (?<episode>\d+).* \[.*\]");
            return regex.Matches(strInput);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<FolderItem> animeList = GenerateList();

            gvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gvList.AutoGenerateColumns = true;
            gvList.DataSource = animeList;
            gvList.Refresh();
            this.WindowState = FormWindowState.Maximized;
        }

        private List<FolderItem> GenerateList()
        {
            DirectoryInfo di = new DirectoryInfo(txtPath.Text);
            List<FolderItem> animeList = new List<FolderItem>();
            foreach (DirectoryInfo subDir in di.GetDirectories())
            {
                animeList.AddRange(CreateList(subDir));
            }
            return animeList;
        }

        private List<FolderItem> GenerateList(string sortExp)
        {
            DirectoryInfo di = new DirectoryInfo(txtPath.Text);
            List<FolderItem> animeList = new List<FolderItem>();
            foreach (DirectoryInfo subDir in di.GetDirectories())
            {
                animeList.AddRange(CreateList(subDir));
            }
            var propertyInfo = animeList[0].GetType().GetProperty(sortExp, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            return animeList.OrderBy(e => propertyInfo.GetValue(e, null)).ToList();

            //return animeList;
        }

        private List<FolderItem> CreateList(DirectoryInfo subDir)
        {
            List<FolderItem> list = new List<FolderItem>();
            foreach(DirectoryInfo dir in subDir.GetDirectories())
            {
                FolderItem item = new FolderItem();
                item.Title = dir.Name;
                item.FullPath = dir.FullName;
                item.Count = dir.GetFiles().Length;
                if(item.Count > 0)
                    item.LastEpisode = dir.GetFiles().OrderBy(x => x.Name).Last().Name;
                item.Parent = dir.Parent.Name;
                List<int> epList = GetEpisodes(dir);
                if (epList.Count > 0)
                {
                    item.Max = epList.Max();
                    item.Missing = GetMissing(epList);
                }
                list.Add(item);
            }
            return list;
        }

        private string GetMissing(List<int> epList)
        {
            StringBuilder sb = new StringBuilder();
            List<int> missing = new List<int>();
            for (int i = 1; i <= epList.Max(); i++)
            {
                if (!epList.Contains(i))
                    missing.Add(i);
            }
            missing.ForEach(x => sb.Append(x+";"));
            return sb.ToString();
        }

        private List<int> GetEpisodes(DirectoryInfo dir)
        {
            List<int> epList = dir.GetFiles().Select(x => GetEpisode(x.Name)).OrderBy(x => x).ToList();
            return epList;
        }

        private int GetEpisode(string name)
        {
            int no = 0;
            var test = GetMatches(name);
            if (test.Count > 0)
            {
                no = Convert.ToInt32( test[0].Groups["episode"].Value);
            }
            return no;
        }

        class FolderItem
        {
            public string Title { get; set; }
            public string Missing { get; set; }
            public int Count { get; set; }
            public int Max { get; set; }
            public string FullPath { get; set; }
            public string Parent { get; set; }
            public string LastEpisode { get; set; }
            public FolderItem()
            {

            }

            public FolderItem(string title, string fullPath, int count, int max)
            {
                this.Title = title;
                this.FullPath = fullPath;
                this.Count = count;
                this.Max = max;

            }
        }

        private void gvList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            List<FolderItem> animeList = GenerateList(gvList.Columns[e.ColumnIndex].HeaderText);
            gvList.DataSource = animeList;
            gvList.Refresh();

        }

        private void OpenLocation(string filePath)
        {
            //if (!File.Exists(filePath))
            //{
            //    return;
            //}

            string argument = @"/select, " + filePath;
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        private void OpenChrome(string name)
        {
            name = HttpUtility.UrlEncode(name);
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", string.Format(txtSearchUrl.Text, name));
        }

        private void OpenChrome(string name, List<string> list)
        {
            list.Where(x => !string.IsNullOrEmpty(x)).ToList()
                .ForEach(x =>
                        Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", SearchUrl(name, x))                    
                );
        }

        private string SearchUrl(string name, string episode)
        {
            string keyword = string.Format("{0} {1:00} [480p]", name, Convert.ToInt32(episode));
            return string.Format(txtSearchUrl.Text, HttpUtility.UrlEncode(keyword));
        }

        private void DownloadFirstPage()
        {
            string keyword = "horriblesubs [480p]";
            string url = string.Format(txtSearchUrl.Text, HttpUtility.UrlEncode(keyword));
            List<String> result = new List<string>();

            WebClient wc = new WebClient();
            string data = wc.DownloadString(url);
            HtmlAgilityPack.HtmlDocument resultat = new HtmlAgilityPack.HtmlDocument();
            resultat.LoadHtml(data);
            string downloaded = string.Empty;
            List<HtmlNode> anchors = resultat.DocumentNode.Descendants().Where
                (x => (x.Name == "a" && x.InnerText.ToLower().Contains("torrent"))).ToList();
            anchors.ForEach(a => 
                {
                    string torrentUrl = a.Attributes["href"].Value;
                    downloaded = DownloadFile(torrentUrl);
                    string fileName = new Uri(torrentUrl).Segments.Last();
                    result.Add(string.Format("{0} \n => {1}", HttpUtility.UrlDecode(fileName), downloaded));
                }
            );
            new Form2(result).ShowDialog(this);
        }

        private void DownloadMissing(string name, List<string> list)
        {
            StringBuilder result = new StringBuilder();
            list.Where(x => !string.IsNullOrEmpty(x)).ToList()
                .ForEach(x =>
                {
                    result.AppendLine(SearchAndDownload(SearchUrl(name, x)));
                    result.AppendLine();
                }
            );
            MessageBox.Show(result.ToString());
        }

        private void gvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenLocation( gvList.Rows[e.RowIndex].Cells[4].Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DecodeFileName(txtPath.Text);
        }

        private void DecodeFileName(string folder)
        {
            DirectoryInfo di = new DirectoryInfo(folder);
            foreach (FileInfo file in di.GetFiles())
            {
                string title = GetTitle(file);
                string path = file.Directory.FullName;
                if (!string.IsNullOrEmpty(path))
                {
                    string decoded = HttpUtility.UrlDecode(file.Name);
                    MoveFile(file, path, decoded);
                }
            }

        }

        private DataGridViewRow GetSelectedRow()
        {
            Int32 selected = gvList.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            return gvList.Rows[selected];
        }

        private string GetSelectedName()
        {
            return GetSelectedRow().Cells[0].Value.ToString();
        }

        private string GetSelectedMissing()
        {
            return GetSelectedRow().Cells[1].Value.ToString();
        }

        private string GetSelectedPath()
        {
            return GetSelectedRow().Cells[4].Value.ToString();
        }

        private void searchGoogleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedName = GetSelectedName();
            string name = HttpUtility.UrlEncode(selectedName);
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "https://www.google.com.sg/?gfe_rd=cr&ei=lVAFV5yKBMqFuASc753YBQ&gws_rd=ssl#q=" + name);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedName = GetSelectedName();
            OpenChrome(selectedName);
        }

        private void searchMissingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedName = GetSelectedName();
            string missings = GetSelectedMissing();
            OpenChrome(selectedName, missings.Split(';').ToList());
        }

        private void downloadMissingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedName = GetSelectedName();
            string missings = GetSelectedMissing();
            DownloadMissing(selectedName, missings.Split(';').ToList());
        }

        private void markEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = GetSelectedPath();
            Directory.Move(path, path + " (end)");
        }

        private void gvList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = gvList.HitTest(e.X, e.Y);
                gvList.ClearSelection();
                gvList.Rows[hti.RowIndex].Selected = true;
            }
        }

        private string SearchAndDownload(string url)
        {
            WebClient wc = new WebClient();
            string data = wc.DownloadString(url);
            HtmlAgilityPack.HtmlDocument resultat = new HtmlAgilityPack.HtmlDocument();
            resultat.LoadHtml(data);
            string downloaded = string.Empty;
            List<HtmlNode> anchors = resultat.DocumentNode.Descendants().Where
                (x => (x.Name == "a" && x.InnerText.ToLower().Contains("torrent"))).ToList();
            if (anchors.Count > 0)
            {
                string torrentUrl = anchors.First().Attributes["href"].Value;
                downloaded = DownloadFile(torrentUrl);
            }
            return string.Format("{0} \n => {1}", url, downloaded);
        }
         
        private string DownloadFile(string url)
        {
            try
            {
                url = HttpUtility.HtmlDecode(url);
                WebClient wc = new WebClient();
                Uri uri = new Uri(url);
                string fileName = System.IO.Path.GetFileName(uri.LocalPath);
                if (string.IsNullOrEmpty(fileName))
                    fileName = Guid.NewGuid().ToString() + ".torrent";
                fileName = Path.Combine(txtTorrentFolder.Text, fileName);
                //http://www.nyaa.se/?page=download&tid=786320
                //string fileName = "D:\\" + HttpUtility.UrlDecode("%5BHorribleSubs%5D%20Assassination%20Classroom%20S2%20-%2007%20%5B480p%5D.torrent");
                wc.DownloadFile(url, fileName);
                //MessageBox.Show(string.Format("{0} downloaded", fileName));
                return string.Format("'{0}' downloaded.", fileName);
            }
            catch (Exception ex)
            {
                return "Failed Error : " + ex.Message;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<FolderItem> animeList = GenerateList().Where(x => !string.IsNullOrEmpty(x.Missing)).ToList();
            gvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gvList.AutoGenerateColumns = true;
            gvList.DataSource = animeList;
            gvList.Refresh();
            this.WindowState = FormWindowState.Maximized;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenLocation(txtTorrentFolder.Text);
        }

        private void gvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in gvList.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if(!string.IsNullOrEmpty(Convert.ToString( Myrow.Cells[1].Value)))
                {
                    Myrow.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                }
                if (Myrow.Cells.Count >=5 && Myrow.Cells[4].Value.ToString().ToLower().Contains("(end)"))
                {
                    Myrow.DefaultCellStyle.BackColor = Color.LightCyan;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (FileInfo file in (new DirectoryInfo(txtPath.Text)).GetFiles("*.*", SearchOption.AllDirectories))
            {
                string dest = file.FullName.Replace(file.Name, Path.GetFileNameWithoutExtension(file.FullName));
                file.MoveTo(dest);
            }
            MessageBox.Show("Completed");
        }


        private void button8_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> folders = new Dictionary<string, string>();
            DirectoryInfo dirs = new DirectoryInfo(txtPath.Text);
            foreach (DirectoryInfo dir in dirs.GetDirectories())
            {
                folders.Add(dir.Name, GetSize(dir).ToString("N3") + " GB");
            }
            gvList.DataSource = folders.OrderByDescending(x => x.Value).ToList();
            gvList.AutoGenerateColumns = true;
            gvList.Refresh();
        }

        private double GetSize(DirectoryInfo dir)
        {
            var size = dir.GetFiles("*", SearchOption.AllDirectories).Sum(f => f.Length);
            return Convert.ToDouble((double)size / (double)(1024 * 1024 * 1024));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DownloadFirstPage();
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            Flight form = new Flight();
            form.Show();
            //this.Close();
        }

        private static bool AllwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
        private static bool ValidateRemoteCertificate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (error == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            Console.WriteLine("X509Certificate [{0}] Policy Error: '{1}'",
                cert.Subject,
                error.ToString());

            return false;
        }

        //enum FolderView
        //{
        //    DETAILS = 0x704b,
        //    TILES = 0x704c,
        //    EXTRA_LARGE_ICONS = 0x704d,
        //    LARGE_ICONS = 0x704f,
        //    MEDIUM_ICONS = 0x704e,
        //    SMALL_ICONS = 0x7050,
        //    LIST = 0x7051,
        //    CONTENT = 0x7052
        //}

        //private static void SetFolderView(string path, FolderView view)
        //{
        //    try
        //    {
        //        if (Directory.Exists(path))
        //        {
        //            int tries = 0;

        //            WinAPI.ShellExecute(IntPtr.Zero, "Open", path, "", "", WinAPI.ShowCommands.SW_NORMAL);

        //            IntPtr hwndFolder = IntPtr.Zero;

        //            while (hwndFolder == IntPtr.Zero && tries < 100)
        //            {
        //                hwndFolder = WinAPI.FindWindow("CabinetWClass", Path.GetFileName(path));
        //                tries++;
        //                Thread.Sleep(100);
        //            }

        //            if (hwndFolder != IntPtr.Zero)
        //            {
        //                IntPtr hwndFolderShellTab = WinAPI.FindWindowEx(hwndFolder, IntPtr.Zero, "ShellTabWindowClass", Path.GetFileName(path));
        //                IntPtr hwndFolderDUIViewWnd = WinAPI.FindWindowEx(hwndFolderShellTab, IntPtr.Zero, "DUIViewWndClassName", "");
        //                IntPtr hwndFolderDirectUIHWND = WinAPI.FindWindowEx(hwndFolderDUIViewWnd, IntPtr.Zero, "DirectUIHWND", "");
        //                IntPtr hwndFolderCtrlNotifySink1 = WinAPI.FindWindowEx(hwndFolderDirectUIHWND, IntPtr.Zero, "CtrlNotifySink", "");
        //                IntPtr hwndFolderCtrlNotifySink2 = WinAPI.FindWindowEx(hwndFolderDirectUIHWND, hwndFolderCtrlNotifySink1, "CtrlNotifySink", "");
        //                IntPtr hwndFolderCtrlNotifySink3 = WinAPI.FindWindowEx(hwndFolderDirectUIHWND, hwndFolderCtrlNotifySink2, "CtrlNotifySink", "");
        //                IntPtr hwndFolderSHELLDLL_DefView = WinAPI.FindWindowEx(hwndFolderCtrlNotifySink3, IntPtr.Zero, "SHELLDLL_DefView", "ShellView");

        //                WinAPI.SendMessage(hwndFolderSHELLDLL_DefView, WinAPI.WM_COMMAND, new IntPtr((int)view), IntPtr.Zero);

        //                bool returnValue = WinAPI.PostMessage(hwndFolder, WinAPI.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        //                if (!returnValue)
        //                    throw new Win32Exception(Marshal.GetLastWin32Error());
        //            }
        //            else
        //            {
        //                Console.WriteLine("Can not get handle of opened folder");
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
    }

    //static public class WinAPI
    //{
    //    [DllImport("Shell32.dll")]
    //    public static extern int ShellExecuteA(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirecotry, int nShowCmd);

    //    public static int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirecotry, int nShowCmd)
    //    {
    //        return ShellExecuteA(hwnd, lpOperation, lpFile, lpParameters, lpDirecotry, nShowCmd);
    //    }
    //}
}
