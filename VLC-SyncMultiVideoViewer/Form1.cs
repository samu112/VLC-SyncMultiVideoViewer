using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
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
    //Damaged mp4 recover: https://forum.videolan.org/viewtopic.php?t=153554
    public partial class Form1 : Form
    {
        private bool navigationControlInUse = false;

        private List<Media> mediaFiles = new List<Media>();
        private List<MediaPlayer> mediaPlayers = new List<MediaPlayer>();
        private List<VideoView> videViews = new List<VideoView>();
        private List<PlayerForm> PlayerForms = new List<PlayerForm>();

        private bool IsPaused = false;

        
        private int errorCounter;//describe how long (seconds) a problem is occured
        private const int errorLimit = 5;//describe how many seconds te problem can be before error message
        private bool errorOccured = false;

        public Form1()
        {

            //var media = new Media(al, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4", FromType.FromLocation);
            //MediaPlayer player = new MediaPlayer(media);
            //videoView1.MediaPlayer = player;
            //media.Dispose();
            //player.Play();
            //player.Media.Parse();



            //VLC Initialization
            Core.Initialize();
            //Normal Initialization
            InitializeComponent();

            //OpenFile Dialog
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select Media files";

            //Title
            this.Text = "VLC-SyncMultiVideoViewer";
            //Coutns how many ticks the error presents
            errorCounter = 0;
            //Add base value to SpeedBar
            Speed_Label.Text = SpeedBarValueToText();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    FileListBox.Items.Add(file);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedItemIndex = FileListBox.SelectedIndex;
            //Check if empty         
            if (FileListBox.Items.Count != 0)
            {
                //Check if delete item is not 0
                if (selectedItemIndex > 0) { FileListBox.SelectedIndex = selectedItemIndex--; }
                else { FileListBox.SelectedIndex = 0; }
                //If not empty but selectItemIndex is -1 it is a bug, handle
                if (selectedItemIndex != -1)
                {
                    FileListBox.Items.RemoveAt(selectedItemIndex);
                }
            }
        }

        private void Start_Pause_Button_Click(object sender, EventArgs e)
        {
            //LibVLC al = new LibVLC();
            //var media = new Media(al, FileListBox.Items[0].ToString(), FromType.FromPath);
            //MediaPlayer player = new MediaPlayer(media);
            //mediaPlayers.Add(player);

            if (PlayerForms.Count == 0)
            {            
                if (FileListBox.Items.Count != 0)
                {
                    trackBar1.Enabled = true;
                    LibVLC al = new LibVLC();
                    for (int i = 0; i < FileListBox.Items.Count; i++)
                    {
                        Media tempMedia = new Media(al, FileListBox.Items[i].ToString(), FromType.FromPath);
                        mediaFiles.Add(tempMedia);
                    }
                    for (int i = 0; i < mediaFiles.Count; i++)
                    {
                        MediaPlayer TempPlayer = new MediaPlayer(mediaFiles[i]);
                        mediaPlayers.Add(TempPlayer);
                    }

                    //Hide Views(except the 1st)
                    //if (FileListBox.Items.Count > 1)
                    //{
                    //    for (int i = 1; i < mediaPlayers.Count; i++)
                    //    {
                    //        VideoView tempView = new VideoView();
                    //        tempView.MediaPlayer = mediaPlayers[i];
                    //        videViews.Add(tempView);
                    //    }
                    //}
                    for (int i = 0; i < mediaPlayers.Count; i++)
                    {
                        //VideoView tempView = new VideoView();
                        //tempView.MediaPlayer = mediaPlayers[i];
                        //videViews.Add(tempView);
                        PlayerForm tempPlayer = new PlayerForm(this, mediaPlayers[i], FileListBox.Items[0].ToString());
                        PlayerForms.Add(tempPlayer);
                        videViews.Add(tempPlayer.videoView1);
                    }
                    PlayerForms[0].Show();
                    trackBar1.Maximum = Convert.ToInt32(PlayerForms[0].videoView1.MediaPlayer.Media.Duration / 1000);
                    EndTimeLabel.Text = TimeSpan.FromSeconds(trackBar1.Maximum).ToString();
                    errorCounter = 0;
                    timer1.Start();


                    foreach (var mediaPlayer in mediaPlayers)
                    {
                        mediaPlayer.Play();
                    }
                }
            }
            else
            {
                Start_Pause_Toggle();
            }







        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Write out Time to Title Bar
            TimeSpan dt = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(PlayerForms[0].videoView1.MediaPlayer.Time));
            this.Text = "VLC-SyncMultiVideoViewer    -    " + dt.ToString(@"hh\:mm\:ss");
            CurrentTimeLabel.Text = dt.ToString(@"hh\:mm\:ss");

            //Mark that user started to use the trackbar
            if (trackBar1.Capture == true)
            {
                navigationControlInUse = true;
            }

            //Change time position after scroll
            if (trackBar1.Capture == false && navigationControlInUse == true)
            {
                SeekTo(TimeSpan.FromSeconds(trackBar1.Value));
                //videoView1.MediaPlayer.SeekTo(TimeSpan.FromSeconds(trackBar1.Value));
                navigationControlInUse = false;
            }

            //Sync trackbar with actual footage time
            if (PlayerForms[0].videoView1.MediaPlayer.IsPlaying == true && trackBar1.Capture == false)
            {
                try
                {
                    trackBar1.Value = Convert.ToInt32(PlayerForms[0].videoView1.MediaPlayer.Time / 1000);
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    TrackBarMaximumFixer();
                }

            }
            //File is damaged
            if (errorCounter > errorLimit && errorOccured == false)
            {
                errorOccured = true;
                DialogResult dialogResult = MessageBox.Show("It seems that some files are corrupted and we can't find the length of the file, so you won't be able to seek forward and backward and the files can get out of sync too.\nWould you like to fix them?", "Corrupted Files", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Stop_Button_Click(sender, e);
                    ConverterForm FileFixerForm = new ConverterForm(FileListBox.Items);
                    FileFixerForm.Show();
                }
            }
        }

        //Synchronized Seek
        public void SeekTo(TimeSpan seekValue)
        {
            foreach (var form in PlayerForms)
            {
                form.videoView1.MediaPlayer.Play();
                form.videoView1.MediaPlayer.SeekTo(seekValue);
                if (IsPaused == true)
                {
                    form.videoView1.MediaPlayer.Pause();
                }
            }
        }

        public void Start_Pause_Toggle()
        {
            foreach (var form in PlayerForms)
            {
                if (IsPaused == false)
                {
                    form.videoView1.MediaPlayer.Pause();
                    form.TimerToggle();
                    timer1.Stop();
                }
                else
                {
                    form.TimerToggle();
                    timer1.Start();
                    form.videoView1.MediaPlayer.Play();
                }  
            }
            if (IsPaused == false) { IsPaused = true; }
            else { IsPaused = false; }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //Write out the trackbar position when dragged
            TimeSpan t = TimeSpan.FromSeconds(trackBar1.Value);
            toolTip1.SetToolTip(trackBar1, t.ToString(@"hh\:mm\:ss"));
            if (IsPaused == true)
            {
                SeekTo(TimeSpan.FromSeconds(trackBar1.Value));
            }
        }

        private void ShowFile_Button_Click(object sender, EventArgs e)
        {
            try
            {
                PlayerForms[FileListBox.SelectedIndex].Show();

            }
            catch (Exception execption)
            {
                MessageBox.Show("nope");
            }

        }

        private void Stop_Button_Click(object sender, EventArgs e)
        {
            if (PlayerForms.Count != 0)
            {
                //Reset main form
                timer1.Stop();
                trackBar1.Value = trackBar1.Minimum;
                trackBar1.Enabled = false;
                this.Text = "VLC-SyncMultiVideoViewer";
                CurrentTimeLabel.Text = "00:00:00";
                EndTimeLabel.Text = "00:00:00";
                errorOccured = false;
            }

            //Close all other forms
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < PlayerForms.Count; i++)
                {
                    mediaFiles[i].Dispose();
                    mediaFiles.RemoveAt(i);
                    mediaPlayers[i].Dispose();
                    mediaPlayers.RemoveAt(i);
                    videViews[i].Dispose();
                    videViews.RemoveAt(i);
                    PlayerForms[i].Dispose();
                    PlayerForms.RemoveAt(i);
                }
            }

        }

        private void FileListBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void FileListBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; // get all files droppeds  
            if (files != null && files.Any())
                foreach (var file in files)
                {
                    if (!File.GetAttributes(file).HasFlag(FileAttributes.Directory))
                    {
                        FileListBox.Items.Add(file);
                    }

                }
        }
        private void TrackBarMaximumFixer()
        {
            errorCounter++;
            trackBar1.Maximum = Convert.ToInt32(PlayerForms[0].videoView1.MediaPlayer.Media.Duration / 1000);
            TimeSpan t = TimeSpan.FromSeconds(Convert.ToInt32(PlayerForms[0].videoView1.MediaPlayer.Media.Duration / 1000));
            EndTimeLabel.Text = t.ToString(@"hh\:mm\:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConverterForm test = new ConverterForm(FileListBox.Items);
            test.Show();
        }

        private void Speed_button_Click(object sender, EventArgs e)
        {
            PlayerForms[0].videoView1.MediaPlayer.SetRate(2);//2=2x of the original speed
        }

        private void SpeedBar_Scroll(object sender, EventArgs e)
        {
            Speed_Label.Text = SpeedBarValueToText();
        }
        private string SpeedBarValueToText()
        {
            string value = ((double)SpeedBar.Value * 0.25).ToString();
            if (value.Length != 4)
            {
                char decimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                if (!value.Contains(decimalSeparator))
                {
                    value += decimalSeparator;
                }
                for (int i = 0; i < 4 - value.Length; i++)
                {
                    value += "0";
                }
            }
            return value;
        }
    }
}
