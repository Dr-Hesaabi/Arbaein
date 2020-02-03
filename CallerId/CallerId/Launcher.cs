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
    public partial class Launcher : Parent
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void Launcher_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Login.IsAdmin)
            {
                new MessageForm { Message = "تنها دسترسی برای مدیر سیستم مجاز است" }.ShowDialog();
            }
            else
            {
                RequestForm re = new RequestForm();
                re.MdiParent = MainForm.mf;
                re.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!Login.IsAdmin)
            {
                new MessageForm { Message = "تنها دسترسی برای مدیر سیستم مجاز است" }.ShowDialog();
            }
            else
            {
                User re = new User();
                re.MdiParent = MainForm.mf;
                re.Show();
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            new CallAndRecord { PhoneNumber = "" }.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            r.MdiParent = MainForm.mf;
            r.Show();
        }
    }
}
