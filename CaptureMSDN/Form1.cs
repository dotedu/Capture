using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureMSDN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Capture capture = new Capture();
        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://msdn.microsoft.com/zh-cn/library/3tz250sf.aspx";
            textBox1.Text = capture.WebCapturesStr(url, "mainBody");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }

        }
    }
}
