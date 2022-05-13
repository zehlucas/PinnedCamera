
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
            this.picWebcamView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcamView)).BeginInit();
            this.SuspendLayout();
            // 
            // picWebcamView
            // 
            this.picWebcamView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picWebcamView.Location = new System.Drawing.Point(0, 0);
            this.picWebcamView.Name = "picWebcamView";
            this.picWebcamView.Size = new System.Drawing.Size(800, 450);
            this.picWebcamView.TabIndex = 0;
            this.picWebcamView.TabStop = false;
            this.picWebcamView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WebcamView_MouseDown);
            this.picWebcamView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WebcamView_MouseMove);
            this.picWebcamView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WebcamView_MouseUp);
            // 
            // WebcamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.picWebcamView);
            this.Name = "WebcamView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebcamView_FormClosing);
            this.Load += new System.EventHandler(this.WebcamView_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WebcamView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WebcamView_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WebcamView_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picWebcamView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picWebcamView;
    }
}