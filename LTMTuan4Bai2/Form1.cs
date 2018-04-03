using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

//Kiem tra dich vu TCP hoac UDP tai 1 cong cua host co duoc mo hay khong
namespace LTMTuan4Bai2
{
    public partial class Form1 : Form
    {
        byte[] data;
        string input, stringData;
        IPEndPoint ip;

        //TcpClient server;
        TcpClient client;
        IPEndPoint ipe;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Dang kiem tra dich vu TCP...");
            for (int i = 1; i <= 80; i++)
            {
                checkTCP(i, textBox1.Text);
            }
            listBox1.Items.Add("Dang kiem tra dich vu UDP...");
            for (int i = 1; i <= 80; i++)
            {
                checkUDP(i, textBox1.Text);
            }
        }
        private void checkTCP(int port, string ipAddress)
        {
            ipe = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            client = new TcpClient();
            try
            {
                client.Connect(ipe);
                listBox1.Items.Add(ipe.ToString() + " open");
                client.Close();
            }
            catch (SocketException se)
            {
                listBox1.Items.Add(ipe.ToString() + " closed");
            }
        }
        private void checkUDP(int port, string ipAddress)
        {
            UdpClient udp = new UdpClient();
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            byte[] data = new byte[1024];
            udp.Client.ReceiveTimeout = 1000;
            udp.Connect(ipe);
            udp.Send(data, data.Length);
            try
            {
                udp.Receive(ref ipe);
                listBox1.Items.Add(ipe.ToString() + " open");
            }
            catch
            {
                listBox1.Items.Add(ipe.ToString() + " closed");
            }
        }

    }
}
