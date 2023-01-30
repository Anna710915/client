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

namespace client
{
    

    public partial class Form1 : Form
    {
        TcpClient client;
        int port;
        IPAddress ipAddress;

        public Form1()
        {
            InitializeComponent();
        }

        private void startClient()
        {
            try
            {
                SendMessageFromSocket(11000);
            }
            catch (Exception ex)
            {
                this.label1.Invoke((MethodInvoker)(() => this.label1.Text = ex.Message));
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private void SendMessageFromSocket(int port)
        {
            //// Буфер для входящих данных
            //byte[] bytes = new byte[1024];

            //// Соединяемся с удаленным устройством

            //// Устанавливаем удаленную точку для сокета
            ////IPAddress ipAddr = IPAddress.Any;

            
            //IPAddress ipAddr = IPAddress.Parse("192.168.43.233");
            //IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            //Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //// Соединяем сокет с удаленной точкой
            //sender.Connect(ipEndPoint);

            //string message = "";
            //this.textBox1.Invoke((MethodInvoker)(() => message = this.textBox1.Text));

            //this.label1.Invoke((MethodInvoker)(() => this.label1.Text = "Сокет соединяется с " + sender.RemoteEndPoint.ToString()));
            
            //byte[] msg = Encoding.UTF8.GetBytes(message);

            //// Отправляем данные через сокет
            //int bytesSent = sender.Send(msg);

            //// Получаем ответ от сервера
            //int bytesRec = sender.Receive(bytes);

            //this.label1.Invoke((MethodInvoker)(() => this.label1.Text = "\nОтвет от сервера: {0}\n\n" + Encoding.UTF8.GetString(bytes, 0, bytesRec)));


    

            //// Освобождаем сокет
            //sender.Shutdown(SocketShutdown.Both);
            //sender.Close();
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
                textStatus.Text = "Click get files " + Environment.NewLine;

                string responseData = await sr.ReadLineAsync();
                string[] arrayFiles = responseData.Trim().Split(';');
                textStatus.Text = "Get files \n" + Environment.NewLine;
                for (int j = 0; j < arrayFiles.Length; j++)
                {
                    listFiles.Items.Add(arrayFiles[j]);
                }

            }
            finally
            {
                sr.Close();
                sw.Close();
                client.Close();
            }
}

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
