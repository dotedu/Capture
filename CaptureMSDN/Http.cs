using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaptureMSDN
{
    class Http
    {
        const int Net_Timeout = 60000;
        private CookieContainer cookie = new CookieContainer(40);
        public byte[] Download(string Url)
        {
            List<byte> ret = new List<byte>();
            byte[] buffer = new byte[4096];
            long totalLength = -1;
            while (totalLength < 0 || ret.Count < totalLength)
            {
                while (true)
                {
                    try
                    {
                        HttpWebRequest loHttp = (HttpWebRequest)WebRequest.Create(Url);
                        loHttp.Timeout = Net_Timeout;
                        loHttp.ServicePoint.Expect100Continue = false;
                        if (ret.Count != 0)
                            loHttp.AddRange(ret.Count);
                        loHttp.CookieContainer = cookie;
                        HttpWebResponse loWebResponse = (HttpWebResponse)loHttp.GetResponse();

                        if (totalLength < 0)
                            totalLength = loWebResponse.ContentLength;

                        loWebResponse.Cookies = cookie.GetCookies(loHttp.RequestUri);
                        Stream input = loWebResponse.GetResponseStream();
                        int len = 0;
                        while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            for (int i = 0; i < len; i++)
                                ret.Add(buffer[i]);
                        }
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            return ret.ToArray();
        }


        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="URL">下载文件地址</param>
        /// <param name="Filename">下载后的存放地址</param>
        /// <param name="Prog">用于显示的进度条</param>
        public void DownloadFile(string URL, string filename, System.Windows.Forms.ProgressBar prog)
        {
            try
            {
                HttpWebRequest Myrq = (HttpWebRequest)HttpWebRequest.Create(URL);
                HttpWebResponse myrp = (HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;

                if (prog != null)
                {
                    prog.Maximum = (int)totalBytes;
                }

                Stream st = myrp.GetResponseStream();
                Stream so = new FileStream(filename, FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);

                    if (prog != null)
                    {
                        prog.Value = (int)totalDownloadedByte;
                    }
                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="URL">下载文件地址</param>
        /// <param name="Filename">下载后的存放地址</param>
        public void DownloadFile(string URL, string filename)
        {
            DownloadFile(URL, filename, null);
        }
    }
}
