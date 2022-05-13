using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinnedCamera.WebcamView
{
    public partial class WebcamView : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private string monikerString;
        VideoCaptureDevice videoCaptureDevice;

        public WebcamView()
        {
            InitializeComponent();
        }

        public WebcamView(string monikerString)
        {
            InitializeComponent();
            this.monikerString = monikerString;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
        }

        private void WebcamView_Load(object sender, EventArgs e)
        {
            
            videoCaptureDevice = new VideoCaptureDevice(monikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();

            // To fill image to picturebox size
            picWebcamView.SizeMode = PictureBoxSizeMode.StretchImage;
            picWebcamView.Left = 0;
            picWebcamView.Top = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsPath gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                Region = new Region(gp);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawEllipse(new Pen(new SolidBrush(this.BackColor), 1), 0, 0, this.Width - 1, this.Height - 1);
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            picWebcamView.Image = (Bitmap)eventArgs.Frame.Clone(); 
        }

        private void WebcamView_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void WebcamView_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, (Size)dragCursorPoint);
                this.Location = Point.Add(dragFormPoint, (Size)diff);
            }
        }

        private void WebcamView_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void WebcamView_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCam();
        }

        public void StopCam()
        {
            //if other camera is running, stop it
            if (videoCaptureDevice != null)
            {
                videoCaptureDevice.Stop();
            }
        }
    }
}
