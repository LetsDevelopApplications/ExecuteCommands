using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.ControlBox = false;
            CustomMessageBoxForm.Show("Alert: Something important!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ExecuteCommand("taskkill /IM acrobat.exe");
            this.ControlBox = true;
            label1.Text = "Completed Successfully!!";
        }

        static void ExecuteCommand(string command)
        {
            try
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process proc = new Process { StartInfo = procStartInfo };

                proc.Start();
                string result = proc.StandardOutput.ReadToEnd();
                Console.WriteLine(result);
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying file: {ex.Message}");
            }
        }

    }
}
