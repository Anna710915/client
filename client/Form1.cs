using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Diagnostics;

namespace client
{

    public partial class Form1 : Form
    {
        TcpClient client;
        int port;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
           port = int.Parse(textPort.Text);
                // TcpListener server = new TcpListener(port);
           client = new TcpClient(textHost.Text, port);
        }

        private async void getFiles_Click(object sender, EventArgs e)
        {
            StreamReader sr = null;
            StreamWriter sw = null;
            try
            {
                sr = new StreamReader(client.GetStream());
                sw = new StreamWriter(client.GetStream());
                sw.AutoFlush = true;
                
                // Send the message to the connected TcpServer.
                await sw.WriteLineAsync("true");
                textStatus.Text += "Click get files " + Environment.NewLine;

                string responseData = await sr.ReadLineAsync();
                string[] arrayFiles = responseData.Trim().Split(';');
                textStatus.Text += "Get files " + Environment.NewLine;
                for (int j = 0; j < arrayFiles.Length; j++)
                {
                    listFiles.Items.Add(arrayFiles[j]);
                }

            } catch (Exception ex)
            {
                sr.Close();
                sw.Close();
                client.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            StreamWriter sw = null;
            StreamReader sr = null;
            FileStream fileStream = null;
            try
            {
                string curItem = listFiles.SelectedItem.ToString();
                textStatus.Text += "Loading file " + curItem + "..." + Environment.NewLine;
                sw = new StreamWriter(client.GetStream());
                sr = new StreamReader(client.GetStream());
                sw.AutoFlush = true;
                await sw.WriteLineAsync(curItem);
                byte[] recievedFile = null;
                byte[] buffer = new byte[1];

                while (true)
                {
                    int count = await client.GetStream().ReadAsync(buffer, 0, 1);
                    if (count == 0)
                    {
                        break;
                    }
                    if (recievedFile == null)
                    {
                        recievedFile = buffer;
                    }
                    else
                    {
                        recievedFile = recievedFile.Concat(buffer).ToArray();
                    }

                }

                textStatus.Text += "Downloading file " + curItem + "..." + "Bytes: " + recievedFile.Length + Environment.NewLine;

                ////Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\exe");
                fileStream = File.Create(Directory.GetCurrentDirectory() + "\\" + curItem);

                fileStream.Write(recievedFile, 0, recievedFile.Length);
                fileStream.Flush();
                fileStream.Close();

                // Use ProcessStartInfo class
                textStatus.Text += "Start executing file " + curItem + "..." + Environment.NewLine;

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = false;
                startInfo.FileName = Directory.GetCurrentDirectory() + "\\" + curItem;

                try
                {
                    // Start the process with the info we specified.
                    // Call WaitForExit and then the using statement will close.
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        textStatus.Text += "Processing file " + curItem + "..." + Environment.NewLine;
                        exeProcess.WaitForExit();
                        textStatus.Text += "Close file " + curItem + "." + Environment.NewLine;
                    }
                }
                catch
                {
                    textStatus.Text += "Error starting " + curItem + "." + Environment.NewLine;
                }

            } finally
            {
                sr.Close();
                sw.Close();
                client.Close();
            }
           
        }
    }

}
