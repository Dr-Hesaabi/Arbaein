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
    public partial class RequestForm : Parent
    {
        public RequestForm()
        {
            InitializeComponent();
        }
        DcDataContext dc = new DcDataContext(new Cs().My());
        static Guid selected;
        public void Refresh()
        {
            dataGridView1.DataSource = dc.Requts.Select(x => new { شناسه = x.Id, عنوان = x.Title }).ToList();
            textBox1.Text= textBox2.Text = String.Empty;
            dataGridView1.Refresh();
        }
        private void RequestForm_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >  0)
            {
                selected = new Guid(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
            groupBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dc.Request_Update(selected, textBox2.Text);
            groupBox1.Visible = false;
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dc.Request_Delete(selected);
            groupBox1.Visible = false;
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dc.Request_Insert(textBox1.Text);
            Refresh();
        }
    }
}
