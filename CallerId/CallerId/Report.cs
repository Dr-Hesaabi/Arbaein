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

namespace CallerId
{
    public partial class Report : Parent
    {
        public Report()
        {
            InitializeComponent();
        }
        
        List<Call> calls = new List<Call>();
        public void Refresh()
        {
            if (!Login.IsAdmin)
            {
                calls = calls.Where(x => x.OperatorNationalCode == Login.NationalCode).ToList();
            }
            foreach (var item in calls.Select(x => new { x.Id }))
            {
                ReportItem ri = new ReportItem();
                ri.Dock = DockStyle.Top;
                ri.Id = item.Id;
                panel2.Controls.Add(ri);
            }
        }
        private void Report_Load(object sender, EventArgs e)
        {
            calls = new DcDataContext(new Cs().My()).Calls.ToList();
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            calls = calls.Where(x => x.Date >= DateTime.Now.AddDays(-1 * Convert.ToInt32(textBox1.Text))).ToList();
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Login.IsAdmin)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Comma Seprated Values|*.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try {
                        string Output = "کد ملی اپراتور, نام و نام خانوادگی تماس گیرنده, شهر, تاریخ, شماره تلفن" + "\n";
                        foreach (var item in new DcDataContext().Calls.Select(x => new { OperatorsNationalCode = x.OperatorNationalCode, Fullname = x.FullName, CityName = x.CityName, Date = x.Date, PhoneNumber = x.PhoneNumber }))
                        {
                            Output += item.OperatorsNationalCode + "," + item.Fullname + "," + item.CityName + "," + item.Date + "," + item.PhoneNumber + "\n";
                        }
                        File.WriteAllText(sfd.FileName, Output, Encoding.UTF8);
                        new MessageForm { Message = "ذخیره شد" }.ShowDialog();
                    }
                    catch
                    {
                        new MessageForm { Message = "فرایند با خطا مواجه شد. لطفا دوباره تلاش کنید." }.ShowDialog();

                    }

                }
            }
            else
            {
                new MessageForm { Message = "دسترسی به این بخش برای مدیر سیستم میسر است" }.ShowDialog();
            }
        }
    }
}
