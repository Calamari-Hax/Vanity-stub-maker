using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net; //To upload the webhook to Discord
using System.IO; //For StreamWriter to write the WebRequest
using System.Diagnostics;

using Microsoft.Scripting.Hosting;


namespace Vanity
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Form1()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        public static void sendDiscordWebhook(string URL, string escapedjson)
        {
            var wr = WebRequest.Create(URL);
            wr.ContentType = "application/json";
            wr.Method = "POST";
            using (var sw = new StreamWriter(wr.GetRequestStream()))
                sw.Write(escapedjson);
            wr.GetResponse();
        }


        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }










        private void button2_Click(object sender, EventArgs e)
        {
            sendDiscordWebhook(richTextBox1.Text,
          "{\"username\": \"Vanity\",  \"avatar_url\": \"https://cdn.discordapp.com/attachments/893001254987526157/901758619333312512/Satin.png\",\"embeds\":[    {\"description\":\"Your webhook is working.\", \"title\":\"Working.\", \"color\":12255487}]  }");

        }

        static void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

            if (File.Exists(@"Output/output.py"))
            {
                File.Delete(@"Output/output.py");

               
            }
            Task.Delay(3000);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Output/output.py", true))
            {
                string text = richTextBox3.Text + richTextBox1.Text + richTextBox4.Text;

               file.WriteLine(richTextBox2.Text);
               file.WriteLine(text);
               file.WriteLine(richTextBox5.Text);


            }


















        }

                
            
    }
}



