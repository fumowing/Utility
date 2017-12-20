using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtil.DataPinger
{
    public partial class DataQuery : Form
    {
        public DataQuery()
        {
            InitializeComponent();
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
            DoQuery();
        }

        private void DoQuery()
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            string msg = "success";
            try
            {
                SqlConnection con = new SqlConnection(txtConSTr.Text);
                SqlCommand cmd = new SqlCommand(txtQry.Text, con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                da.FillSchema(dt, SchemaType.Source);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
                //dataGridView1.Refresh();
                end = DateTime.Now;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                end = DateTime.Now;
            }
            finally
            {
                WriteLog(msg, start, end);
            }
        }

        private void WriteLog(string msg, DateTime start, DateTime end)
        {
            StreamWriter sw = new StreamWriter(txtLogPath.Text, true);
            TimeSpan ts = end - start;
            string res = string.Format("{0} Execute query, result : '{1}', execution time : '{2}' ms "
                , start.ToString("yyyy MM dd HH:mm:ss"), msg, ts.TotalMilliseconds);
            sw.WriteLine(res);
            sw.Flush();
            sw.Close();
            lvResult.Items.Add(res);            

        }


    }
}
