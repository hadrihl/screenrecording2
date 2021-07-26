using System;
using System.Linq;
using System.Windows.Forms;
using VisioForge.Types.OutputFormat;

namespace ScreenRecording2
{
    public partial class Form1 : Form
    {
        public void updateTime()
        {
            DateTime localDate = DateTime.Now;
            label1.Text = localDate.ToString("yyyyMMddHHmmss");
        }

        public void startRecording()
        {
            videoCapture1.Screen_Capture_Source = new VisioForge.Types.Sources.ScreenCaptureSourceSettings()
            {
                FullScreen = true
            };

            videoCapture1.Audio_PlayAudio = false;
            videoCapture1.Audio_RecordAudio = true;
            if (videoCapture1.Audio_CaptureDevicesInfo.Any())
            {
                videoCapture1.Audio_CaptureDevice = videoCapture1.Audio_CaptureDevicesInfo[0].Name;
            }
            videoCapture1.Output_Format = new VFMP4v8v10Output();
            videoCapture1.Output_Filename = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) + "\\" + label1.Text + ".mp4";
            videoCapture1.Mode = VisioForge.Types.VFVideoCaptureMode.ScreenCapture;

            videoCapture1.Start();
        }

        public void stopRecording()
        {
            videoCapture1.Stop();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startRecording();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopRecording();
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}
