
namespace VLC_SyncMultiVideoViewer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.Add_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Start_Pause_Button = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Stop_Button = new System.Windows.Forms.Button();
            this.ShowFile_Button = new System.Windows.Forms.Button();
            this.CurrentTimeLabel = new System.Windows.Forms.Label();
            this.EndTimeLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SpeedBar = new System.Windows.Forms.TrackBar();
            this.Speed_Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // FileListBox
            // 
            this.FileListBox.AllowDrop = true;
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.HorizontalScrollbar = true;
            this.FileListBox.ItemHeight = 20;
            this.FileListBox.Location = new System.Drawing.Point(171, 26);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(465, 264);
            this.FileListBox.TabIndex = 0;
            this.FileListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileListBox_DragDrop);
            this.FileListBox.DragOver += new System.Windows.Forms.DragEventHandler(this.FileListBox_DragOver);
            // 
            // Add_Button
            // 
            this.Add_Button.Location = new System.Drawing.Point(27, 26);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(114, 58);
            this.Add_Button.TabIndex = 1;
            this.Add_Button.Text = "Add File";
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 58);
            this.button1.TabIndex = 2;
            this.button1.Text = "Remove File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Start_Pause_Button
            // 
            this.Start_Pause_Button.Location = new System.Drawing.Point(303, 296);
            this.Start_Pause_Button.Name = "Start_Pause_Button";
            this.Start_Pause_Button.Size = new System.Drawing.Size(210, 81);
            this.Start_Pause_Button.TabIndex = 3;
            this.Start_Pause_Button.Text = "Start/Pause";
            this.Start_Pause_Button.UseVisualStyleBackColor = true;
            this.Start_Pause_Button.Click += new System.EventHandler(this.Start_Pause_Button_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.LargeChange = 0;
            this.trackBar1.Location = new System.Drawing.Point(48, 392);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(718, 56);
            this.trackBar1.SmallChange = 0;
            this.trackBar1.TabIndex = 4;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Stop_Button
            // 
            this.Stop_Button.Location = new System.Drawing.Point(575, 322);
            this.Stop_Button.Name = "Stop_Button";
            this.Stop_Button.Size = new System.Drawing.Size(94, 29);
            this.Stop_Button.TabIndex = 5;
            this.Stop_Button.Text = "STOP";
            this.Stop_Button.UseVisualStyleBackColor = true;
            this.Stop_Button.Click += new System.EventHandler(this.Stop_Button_Click);
            // 
            // ShowFile_Button
            // 
            this.ShowFile_Button.Location = new System.Drawing.Point(679, 51);
            this.ShowFile_Button.Name = "ShowFile_Button";
            this.ShowFile_Button.Size = new System.Drawing.Size(94, 29);
            this.ShowFile_Button.TabIndex = 6;
            this.ShowFile_Button.Text = "ShowFile";
            this.ShowFile_Button.UseVisualStyleBackColor = true;
            this.ShowFile_Button.Click += new System.EventHandler(this.ShowFile_Button_Click);
            // 
            // CurrentTimeLabel
            // 
            this.CurrentTimeLabel.AutoSize = true;
            this.CurrentTimeLabel.Location = new System.Drawing.Point(38, 428);
            this.CurrentTimeLabel.Name = "CurrentTimeLabel";
            this.CurrentTimeLabel.Size = new System.Drawing.Size(63, 20);
            this.CurrentTimeLabel.TabIndex = 7;
            this.CurrentTimeLabel.Text = "00:00:00";
            // 
            // EndTimeLabel
            // 
            this.EndTimeLabel.AutoSize = true;
            this.EndTimeLabel.Location = new System.Drawing.Point(710, 421);
            this.EndTimeLabel.Name = "EndTimeLabel";
            this.EndTimeLabel.Size = new System.Drawing.Size(63, 20);
            this.EndTimeLabel.TabIndex = 8;
            this.EndTimeLabel.Text = "00:00:00";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(38, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 9;
            this.button2.Text = "Converter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SpeedBar
            // 
            this.SpeedBar.LargeChange = 0;
            this.SpeedBar.Location = new System.Drawing.Point(701, 151);
            this.SpeedBar.Maximum = 16;
            this.SpeedBar.Minimum = 1;
            this.SpeedBar.Name = "SpeedBar";
            this.SpeedBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SpeedBar.Size = new System.Drawing.Size(56, 130);
            this.SpeedBar.SmallChange = 0;
            this.SpeedBar.TabIndex = 11;
            this.SpeedBar.Value = 4;
            this.SpeedBar.Scroll += new System.EventHandler(this.SpeedBar_Scroll);
            this.SpeedBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SpeedBar_MouseDown);
            this.SpeedBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SpeedBar_MouseUp);
            // 
            // Speed_Label
            // 
            this.Speed_Label.AutoSize = true;
            this.Speed_Label.Location = new System.Drawing.Point(738, 209);
            this.Speed_Label.Name = "Speed_Label";
            this.Speed_Label.Size = new System.Drawing.Size(50, 20);
            this.Speed_Label.TabIndex = 12;
            this.Speed_Label.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(690, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 28);
            this.label1.TabIndex = 13;
            this.label1.Text = "Speed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Speed_Label);
            this.Controls.Add(this.SpeedBar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.EndTimeLabel);
            this.Controls.Add(this.CurrentTimeLabel);
            this.Controls.Add(this.ShowFile_Button);
            this.Controls.Add(this.Stop_Button);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.Start_Pause_Button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Add_Button);
            this.Controls.Add(this.FileListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FileListBox;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Start_Pause_Button;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Stop_Button;
        private System.Windows.Forms.Button ShowFile_Button;
        private System.Windows.Forms.Label CurrentTimeLabel;
        private System.Windows.Forms.Label EndTimeLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar SpeedBar;
        private System.Windows.Forms.Label Speed_Label;
        private System.Windows.Forms.Label label1;
    }
}

