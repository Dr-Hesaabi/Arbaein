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
    public partial class User : Parent
    {
        public User()
        {
            InitializeComponent();
        }
        DcDataContext dc = new DcDataContext(new Cs().My());
        static bool IsUpdate = false;
        static string prevNationalCode = String.Empty;

        public void Refresh()
        {
            dataGridView1.DataSource = dc.Users.Select(x => new { کدملی = x.NationalCode, نام = x.Fullname });
            prevNationalCode = "";
            dataGridView1.ClearSelection();
        }
        private void User_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsUpdate)
            {
                dc.User_Insert(textBox1.Text, textBox2.Text, textBox3.Text, checkBox1.Checked, textBox4.Text);
            }
            else
            {
                dc.User_Update(prevNationalCode, textBox1.Text, textBox2.Text, textBox3.Text, checkBox1.Checked, textBox4.Text);
                Toggle();
            }
        }
        public void Toggle()
        {
            if (!IsUpdate)
            {
                IsUpdate = true;
                button1.Text = "ویرایش";
                string NationalCode = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                var user = dc.Users.Where(x => x.NationalCode == NationalCode).FirstOrDefault();
                textBox1.Text = user.NationalCode;
                textBox2.Text = user.Fullname;
                textBox4.Text = String.Empty;
                textBox3.Text = user.FatherName;
                checkBox1.Checked = user.IsAdmin;
                new MessageForm { Message = "اگر قصد ویرایش کلمه ی عبور را ندارید، آنرا خالی رها کنید" + "\n" + "برای خروج از حالت ویرایش، دوباره روی لیست کلیک کنید" }.ShowDialog();
            }
            else
            {
                button1.Text = "ثبت";
                IsUpdate = false;
                textBox1.Text =
                textBox2.Text =
                textBox4.Text =
                textBox3.Text = String.Empty;
                checkBox1.Checked = false;
                Refresh();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Toggle();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                prevNationalCode = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }

        }
    }
}
