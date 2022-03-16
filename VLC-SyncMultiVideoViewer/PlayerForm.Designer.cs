
namespace VLC_SyncMultiVideoViewer
{
    partial class PlayerForm
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
            this.components = new System.ComponentModel.Container();
            this.videoView1 = new LibVLCSharp.WinForms.VideoView();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.Resume_Pause_Button = new System.Windows.Forms.Button();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.VolumeText = new System.Windows.Forms.Label();
            this.FullScreeenTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayerBackground = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // videoView1
            // 
            this.videoView1.BackColor = System.Drawing.Color.Black;
            this.videoView1.Enabled = false;
            this.videoView1.Location = new System.Drawing.Point(12, 12);
            this.videoView1.MediaPlayer = null;
            this.videoView1.Name = "videoView1";
            this.videoView1.Size = new System.Drawing.Size(776, 393);
            this.videoView1.TabIndex = 0;
            this.videoView1.TabStop = false;
            this.videoView1.Text = "videoView1";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.LargeChange = 0;
            this.trackBar1.Location = new System.Drawing.Point(12, 405);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(775, 30);
            this.trackBar1.SmallChange = 0;
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TabStop = false;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(21, 430);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(50, 20);
            this.CurrentTimeLabel.TabIndex = 2;
            this.CurrentTimeLabel.Text = "label1";
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Location = new System.Drawing.Point(720, 430);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(50, 20);
            this.EndTimeLabel.TabIndex = 3;
            this.EndTimeLabel.Text = "label1";
            // 
            // Resume_Pause_Button
            // 
            this.Resume_Pause_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Resume_Pause_Button.Location = new System.Drawing.Point(323, 426);
            this.Resume_Pause_Button.Name = "Resume_Pause_Button";
            this.Resume_Pause_Button.Size = new System.Drawing.Size(136, 29);
            this.Resume_Pause_Button.TabIndex = 4;
            this.Resume_Pause_Button.TabStop = false;
            this.Resume_Pause_Button.Text = "Resume/Pause";
            this.Resume_Pause_Button.UseVisualStyleBackColor = true;
            this.Resume_Pause_Button.Click += new System.EventHandler(this.Resume_Pause_Button_Click);
            // 
            // VolumeBar
            // 
            this.VolumeBar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.VolumeBar.Enabled = false;
            this.VolumeBar.Location = new System.Drawing.Point(714, 150);
            this.VolumeBar.Maximum = 100;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.VolumeBar.Size = new System.Drawing.Size(56, 130);
            this.VolumeBar.TabIndex = 5;
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // VolumeText
            // 
            this.VolumeText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.VolumeText.AutoSize = true;
            this.VolumeText.Location = new System.Drawing.Point(754, 211);
            this.VolumeText.Name = "VolumeText";
            this.VolumeText.Size = new System.Drawing.Size(45, 20);
            this.VolumeText.TabIndex = 6;
            this.VolumeText.Text = "100%";
            // 
            // FullScreeenTimer
            // 
            this.FullScreeenTimer.Interval = 1000;
            this.FullScreeenTimer.Tick += new System.EventHandler(this.FullScreeenTimer_Tick);
            // 
            // PlayerBackground
            // 
            this.PlayerBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayerBackground.Location = new System.Drawing.Point(0, 405);
            this.PlayerBackground.Name = "PlayerBackground";
            this.PlayerBackground.Size = new System.Drawing.Size(822, 50);
            this.PlayerBackground.TabIndex = 7;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VolumeText);
            this.Controls.Add(this.VolumeBar);
            this.Controls.Add(this.Resume_Pause_Button);
            this.Controls.Add(this.CurrentTimeLabel);
            this.Controls.Add(this.EndTimeLabel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.PlayerBackground);
            this.Controls.Add(this.videoView1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "PlayerForm";
            this.Text = "PlayerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerForm_FormClosing);
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlayerForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PlayerForm_KeyUp);
            this.Resize += new System.EventHandler(this.PlayerForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.videoView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public LibVLCSharp.WinForms.VideoView videoView1;
        public System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label CurrentTimeLabel;
        private System.Windows.Forms.Label EndTimeLabel;
        private System.Windows.Forms.Button Resume_Pause_Button;
        private System.Windows.Forms.TrackBar VolumeBar;
        private System.Windows.Forms.Label VolumeText;
        private System.Windows.Forms.Timer FullScreeenTimer;
        private System.Windows.Forms.FlowLayoutPanel PlayerBackground;
    }
}