using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My.Util.Organizer
{
    public partial class Form2 : Form
    {
        private List<String> _Files = new List<string>();
        public Form2(List<String> files)
        {
            _Files = files;
            InitializeComponent();
            listBox1.DataSource = _Files;
            listBox1.Refresh();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
