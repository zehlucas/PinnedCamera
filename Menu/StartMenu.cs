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
        VideoCaptureDevice videoCaptureDevice;
        WebcamView.WebcamView webcamView;

        Size imageSize;
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

            cmbSize.Items.Add("Small");
            cmbSize.Items.Add("Medium");
            cmbSize.Items.Add("Large");

            cmbSize.SelectedIndex = 0;
            //cmbCamera.SelectedIndex = 2;
            //videoCaptureDevice = new VideoCaptureDevice();
        }

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            StopCam();

            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cmbCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
            picImgPreview.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            imageSize = bitmap.Size;
            picImgPreview.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void StartMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCam();
            if (webcamView != null)
            {
                webcamView.StopCam();
                webcamView.Dispose();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Stop cam because it will be used in WebCamview
            StopCam();
            webcamView = new WebcamView.WebcamView(monikerString: filterInfoCollection[cmbCamera.SelectedIndex].MonikerString);
            webcamView.TopMost = true;
            webcamView.Show();
            webcamView.Size = webcamViewSize;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void StopCam()
        {
            //if other camera is running, stop it
            if (videoCaptureDevice != null)
            {
                videoCaptureDevice.Stop();
            }
        }

        private void btbStop_Click(object sender, EventArgs e)
        {
            if (webcamView != null)
            {
                webcamView.StopCam();
                webcamView.Dispose();
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                videoCaptureDevice.Start();
            }
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSize.SelectedIndex == 0)
            {
                webcamViewSize = new Size(imageSize.Width / 3, imageSize.Height / 3);
            }
            if (cmbSize.SelectedIndex == 1)
            {
                webcamViewSize = new Size(imageSize.Width / 2, imageSize.Height / 2);
            }
            if (cmbSize.SelectedIndex == 2)
            {
                webcamViewSize = imageSize;
            }
            if(webcamView != null)
            {
                webcamView.Size = webcamViewSize;
            }
        }
    }
}
