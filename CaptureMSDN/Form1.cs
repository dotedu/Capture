using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        static List<string> listurl = new List<string>();
        private static int parts = 60;

        private Action<string> OnDownLoadSucess;
        private Action<string> DownLoadFail;

        private Action<int, int> OnDownLoadCom;

        string test { get; set; }

        int Sucess { get; set; } = 0;
        int Fail { get; set; }

        int threadCount = 0;//任务线程


        static string SavePath { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {

            string url = "https://msdn.microsoft.com/zh-cn/library/0b0thckt.aspx";
            System.Diagnostics.Debug.Write(capture.CapturesTitle(capture.MainCapturesById(url)));
            textBox1.Text = capture.OutHtml(url);


            parts = Convert.ToInt32(numericUpDown1.Value);
            OnDownLoadSucess = (url) => {
                RunInMainthread(() => {
                    textBox1.AppendText(url + "：抓取成功。");

                });
            };
            OnDownLoadCom = (Sucess, Fail) => {
                RunInMainthread(() => {
                    MessageBox.Show("抓取结束,成功抓取" + Sucess + "条，失败" + Fail + "条.");
                });
            };


            DownLoadFail = (url) => {
                RunInMainthread(() => {
                    textBox1.AppendText(url + "：抓取失败。");

                });
            };
            RunAsync(() => {
                Thread[] threads = new Thread[parts];

                for (int i = 0; i < parts; i++)
                {
                    string str_l = listurl[i];
                    Thread t = new Thread(new ParameterizedThreadStart(download));
                    t.IsBackground = true;
                    threads[i] = t;
                    threads[i].Name = "Thread" + i.ToString();
                }

                for (int i = 0; i < parts; i++)
                {
                    threads[i].Start(i);
                }
                for (int i = 0; i < parts; i++)
                {
                    while (threads[i].IsAlive)
                    {
                        ;
                    }
                }

            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //初始化一个OpenFileDialog类 
            OpenFileDialog fileDialog = new OpenFileDialog();

            //判断用户是否正确的选择了文件 
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = fileDialog.FileName;
                //textBox1.Text = Path.GetFileName(fileDialog.FileName);
                StreamReader sr = new StreamReader(path, Encoding.UTF8);//读取文件
                string str = null;
                listurl.Clear();
                listBox1.Items.Clear();
                while ((str = sr.ReadLine()) != null)//判断行
                {
                    listBox1.Items.Add(str);
                    listurl.Add(str);

                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dialog.SelectedPath;
                SavePath = textBox2.Text;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }

        }

        public void download(object o)
        {
            int seed = Convert.ToInt32(listurl.Count) % parts == 0 ? Convert.ToInt32(listurl.Count) / parts : Convert.ToInt32(listurl.Count) / parts + 1;

            int tmp = Convert.ToInt32(o) * seed;
            //Debug.Write(tmp);

            int i = tmp;
            //do
            //{
            //Fail = 0;
            for (; i < (tmp + seed <= listurl.Count ? tmp + seed : listurl.Count); i++)
            {
                threadCount++;
                work(listurl[Convert.ToInt32(i)], SavePath);
                Thread.Sleep(500);
            }
            //} while (Fail == 0);

            //OnDownLoadCom?.Invoke(Sucess, Fail);

        }

        void RunAsync(Action action)
        {
            ((Action)(delegate () {
                action?.Invoke();
            })).BeginInvoke(null, null);
        }

        void RunInMainthread(Action action)
        {
            this.BeginInvoke((Action)(delegate () {
                action?.Invoke();

            }
}
