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
        String ipAd;
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
            try
            {
                port = int.Parse(textPort.Text);
                IPAddress address = IPAddress.Parse(textHost.Text);
                ipAd = textHost.Text;

                if (client == null || !client.Connected)
                {
                    try
                    {
                        client = new TcpClient(textHost.Text, port);
                    } catch
                    {
                        textStatus.Text += "Unable to connect to the server with IP = "
                            + textHost.Text + " and port = " + port + Environment.NewLine;
                    }
                    
                }
                
            }
            catch(Exception ex)
            {
                textStatus.Text += "Invalid port or address: address - " + textHost.Text + 
                    ". port - " + textPort.Text + Environment.NewLine;
            }

        }

        private async void getFiles_Click(object sender, EventArgs e)
        {
            
            if(client != null)
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
                    listFiles.Items.Clear();
                    for (int j = 0; j < arrayFiles.Length; j++)
                    {
                      listFiles.Items.Add(arrayFiles[j]);
                    }

                }
                catch (Exception ex)
                {
                    textStatus.Text += "Exception " + Environment.NewLine;
                } 
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if(client != null && listFiles.SelectedItem != null)
            {
                StreamWriter sw = null;
                StreamReader sr = null;

                try
                {
                    string curItem = listFiles.SelectedItem.ToString();
                    textStatus.Text += "Loading file " + curItem + "..." + Environment.NewLine;
                    sw = new StreamWriter(client.GetStream());
                    sr = new StreamReader(client.GetStream());
                    sw.AutoFlush = true;
                    await sw.WriteLineAsync(curItem);
                    byte[] buffer = new byte[1024];

                    textStatus.Text += "Downloading file " + curItem + "..." + Environment.NewLine;

                    using (FileStream outputFile = File.Create(Directory.GetCurrentDirectory() + "\\" + curItem))
                    {
                        while (true)
                        {
                            int count = await sr.BaseStream.ReadAsync(buffer, 0, buffer.Length);
                            if (count == 0)
                            {
                                break;
                            }
                            await outputFile.WriteAsync(buffer, 0, count);
                        }
                    };

                    ProcessStartInfo startInfo = new ProcessStartInfo();

                    startInfo.UseShellExecute = true;
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



                } catch (Exception ex)
                {
                    textStatus.Text += "Error: " + ex.Message + Environment.NewLine;
                }
            }
            
           
        }
    }

}
