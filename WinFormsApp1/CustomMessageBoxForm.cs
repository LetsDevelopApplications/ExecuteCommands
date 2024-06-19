using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class CustomMessageBoxForm : Form
    {
        public CustomMessageBoxForm()
        {
            InitializeComponent();
            // Customize form properties
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = false; // Hide close button, minimize and maximize buttons

            // CopyFiles();
            try
            {
                //string command = "dir"; // Example command
                ExecuteCommand("taskkill /IM acrobat.exe");
                //ExecuteCommand(command);
                //ExecuteCommand(command);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing command: {ex.Message}");
            }
            Console.ReadLine(); // Optional: to keep console window open
        }

        static void CopyFiles()
        {
            // Source and destination file paths
            string sourceFilePath = @"C:\path\to\source\file.txt";
            string destinationFilePath = @"D:\path\to\destination\file.txt";

            // Copy file
            try
            {
                File.Copy(sourceFilePath, destinationFilePath, true); // true for overwrite if destination file exists
                Console.WriteLine("File copied successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying file: {ex.Message}");
            }


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

        public static DialogResult Show(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            CustomMessageBoxForm customMessageBox = new CustomMessageBoxForm();
            customMessageBox.label1.Text = message;
            customMessageBox.Text = caption;

            // Customize controls based on MessageBoxButtons and MessageBoxIcon
            // Add buttons and other controls as necessary

            return customMessageBox.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}