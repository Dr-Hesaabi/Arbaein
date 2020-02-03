using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallerId
{
    public partial class MainForm : Parent
    {
        public MainForm()
        {
            InitializeComponent();
        }
        static public MainForm mf;

        private void MainForm_Load(object sender, EventArgs e)
        {
            mf = this;

            Launcher lan = new Launcher();
            lan.MdiParent = this;
            lan.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
