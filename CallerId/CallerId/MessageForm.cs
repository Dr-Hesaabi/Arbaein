﻿using System;
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
    public partial class MessageForm : Parent
    {
        public MessageForm()
        {
            InitializeComponent();
        }
        public string Message { get; set; }
        private void MessageForm_Load(object sender, EventArgs e)
        {
            label1.Text = Message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
