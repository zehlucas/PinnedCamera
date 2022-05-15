
namespace PinnedCamera.WebcamView
{
    partial class WebcamView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerWebcamView = new AForge.Controls.VideoSourcePlayer();
            this.SuspendLayout();
            // 
            // playerWebcamView
            // 
            this.playerWebcamView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerWebcamView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.playerWebcamView.BorderColor = System.Drawing.Color.Transparent;
            this.playerWebcamView.Location = new System.Drawing.Point(0, 0);
            this.playerWebcamView.Margin = new System.Windows.Forms.Padding(0);
            this.playerWebcamView.Name = "playerWebcamView";
            this.playerWebcamView.Size = new System.Drawing.Size(537, 396);
            this.playerWebcamView.TabIndex = 1;
            this.playerWebcamView.Text = "videoSourcePlayer";
            this.playerWebcamView.VideoSource = null;
            this.playerWebcamView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playerWebcamView_MouseDown);
            this.playerWebcamView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.playerWebcamView_MouseMove);
            this.playerWebcamView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.playerWebcamView_MouseUp);
            // 
            // WebcamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 396);
            this.ControlBox = false;
            this.Controls.Add(this.playerWebcamView);
            this.Name = "WebcamView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebcamView_FormClosing);
            this.Load += new System.EventHandler(this.WebcamView_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private AForge.Controls.VideoSourcePlayer playerWebcamView;
    }
}