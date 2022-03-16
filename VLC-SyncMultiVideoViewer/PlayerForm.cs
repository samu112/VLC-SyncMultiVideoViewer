using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLC_SyncMultiVideoViewer
{
    public partial class PlayerForm : Form
    {
        //MainForm
        private Form1 _main;
        //Original Sizes
        private int OriginalWindowHeight;
        private int OriginalWindowWidth;
        private int OriginalViewHeight;
        private int OriginalViewWidth;
        private int OriginalTrackBarWidth;

        //Original Locations
        private Point OriginalViewLocation;
        private Point OriginalResumePauseButtomLocation;
        private Point OriginalVolumeBarLocation;

        //SizeBefore FullScreen
        private int BeforeFullScreenWindowHeight;
        private int BeforeFullScreenWindowWidth;
        private FormWindowState FormSizeState;
        private Point BeforeFullScreenViewPosition;
        private int BeforeFullScreenViewHeight;
        private int BeforeFullScreenViewWidth;


        //The anme of the file
        private string fileName;

        //Indicates whether the user using the video scrollbar or not
        bool navigationControlInUse = false;
        //FullScreen Mode
        bool fullscreen = false;
        bool keyPressed = false;
        bool showControls = false;
        //Volume
        bool volumePressed = false;
        int volumeBeforeMute;


        public PlayerForm(Form1 parent, MediaPlayer player, string fileName)
        {
            _main = parent;
            InitializeComponent();
            //Add video to view
            videoView1.MediaPlayer = player;
            //Save Sizes
            OriginalWindowHeight = this.Height;
            OriginalWindowWidth = this.Width;
            OriginalViewHeight = videoView1.Height;
            OriginalViewWidth = videoView1.Width;
            OriginalTrackBarWidth = trackBar1.Width;

            //Save Locations
            OriginalViewLocation = videoView1.Location;
            OriginalResumePauseButtomLocation = Resume_Pause_Button.Location;
            OriginalVolumeBarLocation = VolumeBar.Location;
            //Get the name of the file
            this.fileName = Path.GetFileName(fileName);
        }

        private void PlayerForm_Resize(object sender, EventArgs e)
        {
            //Get Current Window Size
            int CurrentWindowHeight = this.Height;
            int CUrrentWindowWidth = this.Width;
            //Calculate Difference between Original and Current size
            int HeightDifference = CurrentWindowHeight - OriginalWindowHeight;
            int WidthDifference = CUrrentWindowWidth - OriginalWindowWidth;
            //Resize VideoView
            videoView1.Height = OriginalViewHeight + HeightDifference;
            videoView1.Width = OriginalViewWidth + WidthDifference;
            //Resize TrackBar
            trackBar1.Width = OriginalTrackBarWidth + WidthDifference;
            //Relocate the "Resume/Pause" Button
            Resume_Pause_Button.Location = new Point(this.Width / 2 - Resume_Pause_Button.Width, Resume_Pause_Button.Location.Y);
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            videoView1.MediaPlayer.Play();
            timer1.Start();

            //Hide VolumeBar
            VolumeBar.Hide();
            VolumeText.Hide();
            //Set trackbar limit to file duration
            trackBar1.Maximum = Convert.ToInt32(videoView1.MediaPlayer.Media.Duration / 1000);
            //Set Volume
            videoView1.MediaPlayer.Volume = 50;
            VolumeBar.Value = 50;
            //Write out the length of the file
            TimeSpan t = TimeSpan.FromSeconds(Convert.ToInt32(videoView1.MediaPlayer.Media.Duration / 1000));
            EndTimeLabel.Text = t.ToString(@"hh\:mm\:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            //Write out Time to Title Bar
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(videoView1.MediaPlayer.Time));
            this.Text = dt.ToString(@"hh\:mm\:ss") + "    -    " + TextTrimmer(fileName, 45);
            //Write out current time under trackbar label
            CurrentTimeLabel.Text = dt.ToString(@"hh\:mm\:ss");

            //Mark that user started to use the trackbar
            if (trackBar1.Capture == true)
            {
                navigationControlInUse = true;
            }

            //Change time position after scroll
            if (trackBar1.Capture == false && navigationControlInUse == true)
            {
                try
                {
                    _main.SeekTo(TimeSpan.FromSeconds(trackBar1.Value));
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    TrackBarMaximumFixer();
                }

                //videoView1.MediaPlayer.SeekTo(TimeSpan.FromSeconds(trackBar1.Value));
                navigationControlInUse = false;
                Resume_Pause_Button.Enabled = false;
                Resume_Pause_Button.Enabled = true;
            }

            //Sync trackbar with actual footage time
            if (videoView1.MediaPlayer.IsPlaying == true && trackBar1.Capture == false)
            {
                try
                {
                    trackBar1.Value = Convert.ToInt32(videoView1.MediaPlayer.Time / 1000);
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    TrackBarMaximumFixer();
                }

            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //Write out the trackbar position when dragged
            TimeSpan t = TimeSpan.FromSeconds(trackBar1.Value);
            toolTip1.SetToolTip(trackBar1, t.ToString(@"hh\:mm\:ss"));
        }

        //Extended Method
        private string TextTrimmer(string text, int Maxlenght)
        {
            if (text.Length < Maxlenght) { return text; }

            return text.Substring(0, Maxlenght - 3) + "...";
        }

        private void PlayerForm_KeyUp(object sender, KeyEventArgs e)
        {
            keyPressed = false;
            if (volumePressed == true)
            {
                volumePressed = false;
                Thread.Sleep(500);
                VolumeBar.Hide();
                VolumeText.Hide();
            }

        }

        private void PlayerForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (keyPressed==false)
            {
                //FullScreen -- F
                if (e.KeyCode == Keys.F)
                {
                    keyPressed = true;
                    if (fullscreen == false)
                    {
                        //Save the sizes
                        BeforeFullScreenWindowHeight = this.Height;
                        BeforeFullScreenWindowWidth = this.Width;
                        FormSizeState = this.WindowState;

                        BeforeFullScreenViewPosition = videoView1.Location;
                        BeforeFullScreenViewHeight = videoView1.Height;
                        BeforeFullScreenViewWidth = videoView1.Width;
                        //VolumeBar.Location = new Point(this.Width - 50 - VolumeBar.Width, (this.Height - VolumeBar.Height) / 10);

                        //Make it fullscreen
                        this.WindowState = FormWindowState.Normal;
                        this.FormBorderStyle = FormBorderStyle.None;
                        this.WindowState = FormWindowState.Maximized;
                        videoView1.Location = new Point(0, 0);
                        videoView1.Height = this.Height;
                        videoView1.Width = this.Width;
                        FullScreeenTimer.Enabled = true;
                        fullscreen = true;
                        //Hide toolbars
                        trackBar1.Hide();
                        CurrentTimeLabel.Hide();
                        EndTimeLabel.Hide();
                        Resume_Pause_Button.Hide();

                    }
                    else
                    {
                        //Revert to normal screen
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                        this.WindowState = FormSizeState;
                        this.Height = BeforeFullScreenWindowHeight;
                        this.Width = BeforeFullScreenWindowWidth;

                        //VolumeBar.Location = OriginalVolumeBarLocation;

                        videoView1.Location = BeforeFullScreenViewPosition;
                        videoView1.Height = BeforeFullScreenViewHeight;
                        videoView1.Width = BeforeFullScreenViewWidth;
                        FullScreeenTimer.Enabled = false;
                        fullscreen = false;
                        //Show Toolbars
                        trackBar1.Show();
                        CurrentTimeLabel.Show();
                        EndTimeLabel.Show();
                        Resume_Pause_Button.Show();
                    }
                }
                //Resume/Pause -- SPACE
                if (e.KeyCode == Keys.Space)
                {
                    keyPressed = true;
                    _main.Start_Pause_Toggle();
                }
                //Volume up -- UP
                if (e.KeyCode == Keys.Up)
                {
                    volumePressed = true;
                    VolumeBar.Show();
                    VolumeText.Show();
                    if (VolumeBar.Value<100)
                    {
                        VolumeBar.Value++;
                        videoView1.MediaPlayer.Volume++;
                    }
                    VolumeText.Text = VolumeBar.Value.ToString();
                }
                //Volume down -- DOWN
                if (e.KeyCode == Keys.Down)
                {
                    volumePressed = true;
                    VolumeBar.Show();
                    VolumeText.Show();
                    if (VolumeBar.Value > 0)
                    {
                        VolumeBar.Value--;
                        videoView1.MediaPlayer.Volume--;
                    }
                    VolumeText.Text = VolumeBar.Value.ToString();
                }
                //Mute toggle -- M
                if (e.KeyCode == Keys.M)
                {
                    
                    keyPressed = true;
                    volumePressed = true;
                    if (videoView1.MediaPlayer.Mute == false)
                    {
                        volumeBeforeMute = VolumeBar.Value;
                        VolumeBar.Value = 0;
                    }
                    else
                    {
                        VolumeBar.Value = volumeBeforeMute;
                    }
                    VolumeText.Text = VolumeBar.Value.ToString();
                    VolumeBar.Show();
                    VolumeText.Show();
                    videoView1.MediaPlayer.ToggleMute(); 
                }
                //Exit FullScreen -- ESC
                if (e.KeyCode == Keys.Escape)
                {
                    if (fullscreen == true)
                    {
                        //Revert to normal screen
                        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                        this.WindowState = FormSizeState;
                        this.Height = BeforeFullScreenWindowHeight;
                        this.Width = BeforeFullScreenWindowWidth;

                        //VolumeBar.Location = OriginalVolumeBarLocation;

                        videoView1.Location = BeforeFullScreenViewPosition;
                        videoView1.Height = BeforeFullScreenViewHeight;
                        videoView1.Width = BeforeFullScreenViewWidth;
                        FullScreeenTimer.Enabled = false;
                        fullscreen = false;
                        //Show Toolbars
                        trackBar1.Show();
                        CurrentTimeLabel.Show();
                        EndTimeLabel.Show();
                        Resume_Pause_Button.Show();
                    }
                }
            }

        }

        public void TimerToggle()
        {
            if (timer1.Enabled==true)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }

        private void Resume_Pause_Button_Click(object sender, EventArgs e)
        {
            _main.Start_Pause_Toggle();
            Resume_Pause_Button.Enabled = false;
            Resume_Pause_Button.Enabled = true;
            //this.Focus();
        }

        private void PlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void FullScreeenTimer_Tick(object sender, EventArgs e)
        {
            Point mouseRelativePosition = this.PointToClient(Cursor.Position);
            //label1.Text = "X: " + mouseRelativePosition.X + "   Y: " + mouseRelativePosition.Y;
            label2.Text = mouseRelativePosition.Y.ToString() + "||" + (trackBar1.Location.Y - trackBar1.Height).ToString();
            //label2.Text = "X: " + trackBar1.Location.X + "   Y: " + trackBar1.Location.Y;
            if (mouseRelativePosition.Y > trackBar1.Location.Y - trackBar1.Height)
            {
                label1.Text = "Show";
                if (showControls == false)
                {
                    //Show Controls in FullScreen
                    showControls = true;
                    trackBar1.Show();
                    CurrentTimeLabel.Show();
                    EndTimeLabel.Show();
                    Resume_Pause_Button.Show();

                }
            }
            else
            {
                label1.Text = "Hide";
                if (showControls == true)
                {
                    //Show Controls in FullScreen
                    showControls = false;
                    trackBar1.Hide();
                    CurrentTimeLabel.Hide();
                    EndTimeLabel.Hide();
                    Resume_Pause_Button.Hide();

                }
            }
        }

        private void TrackBarMaximumFixer()
        {
            trackBar1.Maximum = Convert.ToInt32(videoView1.MediaPlayer.Media.Duration / 1000);
            TimeSpan t = TimeSpan.FromSeconds(Convert.ToInt32(videoView1.MediaPlayer.Media.Duration / 1000));
            EndTimeLabel.Text = t.ToString(@"hh\:mm\:ss");
        }
    }
}
