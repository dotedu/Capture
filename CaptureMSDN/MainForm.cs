using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureMSDN
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Capture capture = new Capture();
        static List<string> listurl = new List<string>();
        public static bool threadSwitch = false;

        public static bool threadAbort = false;
        public static CancellationTokenSource cts = new CancellationTokenSource();
        
        public static Options options = configure.ReadOptions();

        public static Action<string> OnDownLoadSucess;
        public static Action<string,int> DownLoadFail;

        public static Action<int> OnDownLoadCom;

        public static Action<string, string> OnDownLoadImg;


        public static int Sucess { get; set; } = 0;
        int Fail { get; set; }

        int threadCount = 0;//任务线程


        static string SavePath { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            if (listurl.Count <= 0 || listurl == null)
                return;
            button1.Enabled = false;

            //string url = UrllistBox.SelectedItem.ToString();
            //System.Diagnostics.Debug.Write(capture.CapturesTitle(capture.HttpClient(url)));

            //string contenthtml = capture.HttpClient(url);
            //CaptureParameter param = capture.getpara();
            //textBox1.Text = capture.OutHtml(capture.CapturesBody(contenthtml, param));


            //cparts = Convert.ToInt32(numericUpDown1.Value);
            OnDownLoadSucess = (url) =>
            {
                RunInMainthread(() =>
                {
                    textBox1.AppendText(DateTime.Now.ToUniversalTime().ToString() + "：" + url + " 抓取成功。\r\n");

                });
            };


            DownLoadFail = (url, reconect) =>
            {
                RunInMainthread(() =>
                {
                    textBox1.AppendText(DateTime.Now.ToUniversalTime().ToString() + "：" + url + "：抓取失败。进行第" + reconect.ToString() + "次重试\r\n");

                });
            };


            OnDownLoadCom = (Sucess) =>
            {
                RunInMainthread(() =>
                {
                    button1.Enabled = true;

                    textBox1.AppendText(DateTime.Now.ToUniversalTime().ToString() + "：抓取结束。共抓取" + Sucess.ToString() + "条记录\r\n");

                });
            };



            //OnDownLoadImg = (Imgurl, imgsavepath) =>
            //{
            //    Rundownload(() =>
            //    {
            //        int reconect = 0;
            //        bool imgIsSave = false;
            //        do
            //        {
            //            if (File.Exists(imgsavepath))
            //                break;

            //            try
            //            {

            //                capture.DownloadFile(Imgurl, imgsavepath);
            //                imgIsSave = true;
            //            }
            //            catch (Exception)
            //            {
            //                reconect++;
            //                DownLoadFail?.Invoke(Imgurl, reconect);
            //            }

            //        } while (!imgIsSave && reconect < MainForm.options.MaxReconnect);
            //    });
            //};

            RunAsync(() =>
            {
                Thread[] threads = new Thread[options.Seeds];
                if (listurl.Count > 0 && listurl != null)
                {
                    for (int i = 0; i < options.Seeds; i++)
                    {
                        string str_l = listurl[i];
                        Thread t = new Thread(new ParameterizedThreadStart(download));

                        t.IsBackground = true;
                        threads[i] = t;
                        threads[i].Name = "Thread" + i.ToString();
                        threads[i].Start(i);
                    }

                    for (int i = 0; i < options.Seeds; i++)
                    {
                        while (threads[i].IsAlive)
                        {
                            ;
                        }
                    }
                    do
                    {

                    } while (threadSwitch);
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
                StreamReader sr = new StreamReader(path, Encoding.UTF8);//读取文件
                string str = null;
                listurl.Clear();
                UrllistBox.Items.Clear();
                while ((str = sr.ReadLine()) != null)//判断行
                {
                    UrllistBox.Items.Add(str);
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
                SavePathText.Text = dialog.SelectedPath;
                options.SavePath = SavePathText.Text;
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



            int seed = Convert.ToInt32(listurl.Count) % options.Seeds == 0 ? Convert.ToInt32(listurl.Count) / options.Seeds : Convert.ToInt32(listurl.Count) / options.Seeds + 1;

            int tmp = Convert.ToInt32(o) * seed;
            //Debug.Write(tmp);

            int i = tmp;
            for (; i < (tmp + seed <= listurl.Count ? tmp + seed : listurl.Count); i++)
            {
                if (cts.Token.IsCancellationRequested)
                {
                    break;
                }

                Thread.Sleep(500);
                threadCount++;
                capture.OutHtmlToFlie(listurl[Convert.ToInt32(i)], options.SavePath);
                //Thread.Sleep(500);
            }

            if (Sucess>= listurl.Count)
            {
                MainForm.OnDownLoadCom?.Invoke(Sucess);

            }
        }



        void RunAsync(Action action)
        {
            ((Action)(delegate () {
                action?.Invoke();
            })).BeginInvoke(null, null);
        }

        void Rundownload(Action action)
        {
            ((Action)(delegate () {
                action?.Invoke();
            })).BeginInvoke(null, null);
        }

        void RunInMainthread(Action action)
        {
            this.BeginInvoke((Action)(delegate () {
                action?.Invoke();
            }));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, configure.OptionsFileName),
                    JsonConvert.SerializeObject(options, Formatting.Indented));
            options = configure.ReadOptions();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SavePathText.Text = options.SavePath;
            ReGetNumeric.Value = options.MaxReconnect;
            SeedNumeric.Value = options.Seeds;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (button10.Text == "继续")
            {//开始
                button10.Text = "暂停";
                threadSwitch = false;
                            }
            else
            {//暂停
                button10.Text = "继续";
                threadSwitch = true;
            }
        }

        private void SeedNumeric_ValueChanged(object sender, EventArgs e)
        {
            options.Seeds =Convert.ToInt32(SeedNumeric.Value);
        }

        private void ReGetNumeric_ValueChanged(object sender, EventArgs e)
        {
            options.MaxReconnect= Convert.ToInt32(ReGetNumeric.Value);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            cts.Cancel(); 
        }
    }
}

