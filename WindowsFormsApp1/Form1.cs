using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public SerialPort serialport=null;
        public Form1()
        {
            InitializeComponent();
            serialport = new SerialPort
            {
                PortName = "COM1",
                BaudRate = 9600,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One
            };
            serialport.DataReceived -= new SerialDataReceivedEventHandler(fuck);
            serialport.DataReceived -= new SerialDataReceivedEventHandler(fuck);
        }

        private void fuck(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
