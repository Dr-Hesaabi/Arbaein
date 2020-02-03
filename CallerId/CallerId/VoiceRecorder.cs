using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CallerId
{
    public partial class VoiceRecorder : UserControl
    {
        public VoiceRecorder()
        {
            InitializeComponent();
        }
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);
        string musica = "";

        public void Record()
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            label2.Visible = true;
            StartTime = DateTime.Now;
            timer1.Start();
            mciSendString("open new type waveaudio alias Som", null, 0, 0);
            mciSendString("record Som", null, 0, 0);
        }
        public void Stop()
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            label2.Visible = false;
            timer1.Stop();
            mciSendString("pause Som", null, 0, 0);
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "wave|*.wav";
            if (save.ShowDialog() == DialogResult.OK)
            {
                mciSendString("save Som " + save.FileName, null, 0, 0);
                mciSendString("close Som", null, 0, 0);
                Reset();
            }
        }
        private DateTime StartTime;
        public void Reset()
        {
            lblTime.Text = "00:00:00";
        }
        private void VoiceRecorder_Load(object sender, EventArgs e)
        {
            Reset();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan dt = DateTime.Now - StartTime;
            lblTime.Text = dt.Hours + ":" + dt.Minutes + ":" + dt.Seconds;
        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            Record();
        }

        private void btnStop_Click_1(object sender, EventArgs e)
        {
            Stop();
        }
    }
}
