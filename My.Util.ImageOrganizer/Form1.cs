using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My.Util.ImageOrganizer
{
    public partial class Form1 : Form
    {
        public Form1()
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
                textBox1.Text = Path.Combine(folderBrowserDialog1.SelectedPath, "backup");
            }
        }

        private void ResizeImage(FileInfo file, int scale, int percent)
        {            
            string path = file.FullName;
            using (Image image = Image.FromFile(path))
            {
                int w = image.Width / scale;
                int h = image.Height / scale;
                using (var resized = ImageUtilities.ResizeImage(image, w, h))
                {
                    BackupFile(file);
                    //save the resized image as a jpeg with a quality of 90
                    ImageUtilities.SaveJpeg(path.Replace(file.Extension, string.Format(".{0}{1}", percent, file.Extension)), resized, percent);
                }
            }
            file.Delete();
        }

        private void BackupFile(FileInfo file)
        {
            if (checkBox1.Checked)
            {
                string backupPath = textBox1.Text;
                if (string.IsNullOrEmpty(backupPath))
                {
                    file.CopyTo(file.FullName.Replace(file.Extension, "bak" + file.Extension));
                }
                else
                {
                    if (!Directory.Exists(backupPath))
                        Directory.CreateDirectory(backupPath);
                    file.CopyTo(Path.Combine(backupPath, file.Name));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Text = "Processing";
            SetControls(this, false);
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            backgroundWorker.RunWorkerAsync();

        }

        private void ProcessFolder(DirectoryInfo dir, decimal scale, decimal percentage, BackgroundWorker bw = null)
        {
            if (dir.Exists)
            {
                int i = 0;
                int total = dir.GetFiles().Count() + dir.GetDirectories().Count();
                foreach (FileInfo file in dir.GetFiles())
                {
                    if (bw != null)
                        bw.ReportProgress(i * 100 / total, file.Name);
                    ResizeImage(file, Convert.ToInt32(scale), Convert.ToInt32(percentage));
                    i++;
                    if (bw != null)
                        bw.ReportProgress(i*100 / total, file.Name + "(Completed)");
                }
                foreach (DirectoryInfo cdir in dir.GetDirectories())
                {
                    if (bw != null)
                        bw.ReportProgress(i * 100 / total, cdir.Name);
                    i++;
                    ProcessFolder(cdir, scale, percentage);
                    if (bw != null)
                        bw.ReportProgress(i * 100 / total, cdir.Name + "(Completed)");
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            DirectoryInfo dir = new DirectoryInfo(txtPath.Text);
            ProcessFolder(dir, numericUpDown1.Value, numericUpDown2.Value, backgroundWorker);
            //MessageBox.Show("Completed");
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label4.Text = string.Format("{0} %. Now Processing : {1}", e.ProgressPercentage, Convert.ToString(e.UserState)); 
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = "Complete";
            SetControls(this, true);
            // TODO: do something with final calculation.
        }

        private void SetControls(Control con, bool enabled)
        {
            foreach (Control c in con.Controls)
            {
                SetControls(c, enabled);
            }
            con.Enabled = enabled;
        }
    }
}
