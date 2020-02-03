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
    public partial class CallAndRecord : Parent
    {
        public CallAndRecord()
        {
            InitializeComponent();
        }
        static public Guid MyId;
        static public bool Saved = false;
        public string PhoneNumber { get; set; }
        private void CallAndRecord_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new DcDataContext(new Cs().My()).Requts;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Title";
            MyId = Guid.NewGuid();
            textBox1.Text = PhoneNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Saved)
            {
                new DcDataContext(new Cs().My()).Call_Insert(MyId, Login.NationalCode, textBox2.Text, textBox3.Text, (Guid)comboBox1.SelectedValue, textBox4.Text, DateTime.Now, textBox1.Text);
                new MessageForm { Message = "ثبت شد" }.ShowDialog();
                Saved = true;
            }
            else
            {
                new DcDataContext(new Cs().My()).Call_Update(MyId, Login.NationalCode, textBox2.Text, textBox3.Text, (Guid)comboBox1.SelectedValue, textBox4.Text, textBox1.Text);
                new MessageForm { Message = "ویرایش شد" }.ShowDialog();
            }
        }
    }
}
