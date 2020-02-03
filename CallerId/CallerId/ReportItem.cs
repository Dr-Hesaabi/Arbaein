using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallerId
{
    public partial class ReportItem : UserControl
    {
        public ReportItem()
        {
            InitializeComponent();
        }
        public Guid Id { get; set; }
        private void ReportItem_Load(object sender, EventArgs e)
        {
            var item = new DcDataContext(new Cs().My()).Calls.Where(y => y.Id == Id).Select(x => new {Absract = x.Report, CityName = x.CityName, Fullname = x.FullName, OperatorNationalCode = x.OperatorNationalCode, RequestId = x.RequestId , PhoneNumber = x.PhoneNumber}).FirstOrDefault();
            textBox1.Text = item.PhoneNumber;
            textBox2.Text = item.Fullname;
            textBox3.Text = item.CityName;
            textBox4.Text = item.Absract;
        }
    }
}
