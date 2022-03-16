using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLC_SyncMultiVideoViewer
{
    public partial class ConverterForm : Form
    {
        List<string> importedFiles = new List<string>();

        public ConverterForm(ListBox.ObjectCollection files)
        {
            InitializeComponent();
            if (files.Count != 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    //https://stackoverflow.com/questions/4646920/populating-a-datagridview-with-text-and-progressbars
                    object[] row = new object[] { files[i].ToString(), 0, false };
                    dataGridView1.Rows.Add(row);
                    importedFiles.Add(files[i].ToString());
                }

            }
        }

        private void Fix_Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < importedFiles.Count; i++)
            {
                Conversion(importedFiles[i]);
            }
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "Converter\\HandBrakeCLI.exe";
            //startInfo.Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg";
            //process.StartInfo = startInfo;
            //process.Start();

            //Command: HandBrakeCLI.exe -i "Matek differenciálszámítás gyakorlat.mp4" -o "testOut.mp4"
        }

        private void Conversion(string file)
        {
            string command = '"' + Directory.GetCurrentDirectory() + @"\Converter\HandBrakeCLI.exe" + '"' + " -i " + '"' + file + '"' + " -o " + '"' + Path.GetDirectoryName(file) + Path.GetFileNameWithoutExtension(file) + "-CONVERTED" + Path.GetExtension(file) + '"';
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd")
                {
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false,
                    Arguments = String.Format("/c \"{0}\"", command),
                }
            };
            process.OutputDataReceived += (s, e) => SetText(e.Data);
            process.Start();
            process.BeginOutputReadLine();

            process.WaitForExit();
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text += text;
            }
        }


    }
}
