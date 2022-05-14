using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace PinnedCamera.Menu
{
    public partial class StartMenu : Form
    {
        FilterInfoCollection filterInfoCollection;
        WebcamView.WebcamView webcamView;

        Size screenSize;
        Size webcamViewSize;

        public StartMenu()
        {
            InitializeComponent();
        }

        private void StartMenu_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cmbCamera.Items.Add(filterInfo.Name);
            }
            btnStart.Enabled = false;
            btnStop.Enabled = false;
            
            screenSize = new Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height);
            webcamViewSize = new Size(screenSize.Width / trackSize.Value, screenSize.Height / trackSize.Value);

            //cmbSize.SelectedIndex = 0;
            //cmbCamera.SelectedIndex = 2;
            //3wse'ptureDevice = new VideoCaptureDevice();
        }

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
        }


        private void StartMenu_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (webcamView != null)
            {
                webcamView.StopCam();
                webcamView.Dispose();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Stop cam because it will be used in WebCamview

            webcamView = new WebcamView.WebcamView(monikerString: filterInfoCollection[cmbCamera.SelectedIndex].MonikerString);
            webcamView.TopMost = true;
            webcamView.Show();

            webcamView.Size = webcamViewSize;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            cmbCamera.Enabled = false;
        }

        private void btbStop_Click(object sender, EventArgs e)
        {
            if (webcamView != null)
            {
                webcamView.StopCam();
                webcamView.Dispose();
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                cmbCamera.Enabled = true;
            }
        }

        private void trackSize_Scroll(object sender, EventArgs e)
        {
            webcamViewSize = new Size(screenSize.Width / trackSize.Value, screenSize.Height / trackSize.Value);
            if (webcamView != null)
            {
                webcamView.Size = webcamViewSize;
            }
        }
    }
}
