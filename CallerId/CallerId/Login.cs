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
    public partial class Login : Parent
    {
        static public bool IsAdmin = false;
        static public string NationalCode = String.Empty;
        DcDataContext dc = new DcDataContext(new Cs().My());
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(dc.User_Login(textBox1.Text, textBox2.Text).FirstOrDefault().Success))
            {
                MainForm mf = new MainForm();
                mf.Show();
                this.Hide();
                var user = dc.Users.Where(x => x.NationalCode == textBox1.Text).FirstOrDefault();
                IsAdmin = user.IsAdmin;
                NationalCode = user.NationalCode;
            }
            else
                new MessageForm { Message = "نام کاربری یا کلمه ی عبور صحیح نیست" }.ShowDialog();

        }
    }
}
