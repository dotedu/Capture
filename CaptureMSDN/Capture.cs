using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CaptureMSDN
{
    class Capture
    {
        CaptureProvider capture = new CaptureProvider();



        public void OutHtmlToFlie(string url, string filepath)
        {
            string contenthtml = HttpClient(url);
            CaptureParameter param = getpara();
            if (contenthtml == null)
                return;

            string SaveName = Path.GetFileNameWithoutExtension(url) + "." + MainForm.options.SaveExtension;
            try
            {
                while (MainForm.threadSwitch)
                {
                    Thread.Sleep(1);

                }

                File.WriteAllText(Path.Combine(filepath, SaveName),
                    OutHtml(CapturesBody(contenthtml, param)));
                MainForm.Sucess++;
              MainForm.OnDownLoadSucess?.Invoke(url); 

            }
            catch (Exception)
            {
                throw;
            }
        }

        public string HttpClient(string url)
        {
            string ContentHtml;
            int reconect = 0;
            do
            {
                try
                {
                    while (MainForm.threadSwitch)
                    {
                        Thread.Sleep(1);
                    }


                    WebClient myWebClient = new WebClient();
                    byte[] myDataBuffer = myWebClient.DownloadData(url);
                    ContentHtml = Encoding.UTF8.GetString(myDataBuffer);

                }
                catch (Exception)
                {
                    reconect++;
                    MainForm.DownLoadFail?.Invoke(url, reconect);

                    ContentHtml = null;
                }

            } while (ContentHtml == null && reconect <= MainForm.options.MaxReconnect);

            return ContentHtml;
        }


        public string[] CapturesBody(string html, CaptureParameter param)
        {

            HtmlNode MainBody;
            HtmlDocument doc = new HtmlDocument();


            doc.LoadHtml(html);
            HtmlNode Title = doc.DocumentNode.SelectSingleNode("//title");

            if (param.GetMainMethod == GetMainMethodEnum.Id)
            {
                MainBody = doc.GetElementbyId(param.GetMainString);
            }
            else
            {
                MainBody = doc.DocumentNode.SelectSingleNode(param.GetMainString);

            }

            HtmlDocument mainBody = new HtmlDocument();
            mainBody.LoadHtml(MainBody.OuterHtml);

            HtmlNode[] childlist = mainBody.DocumentNode.Descendants().ToArray();

            foreach (var item in childlist)
            {
                if (MainForm.options.SaveImage)
                {
                    if (item.Name == "img" && item.Attributes.Contains("src"))
                    {
                        if (!string.IsNullOrEmpty(item.Attributes["src"].Value))
                        {

                            string imgsavename = Path.GetFileName(item.Attributes["src"].Value);
                            if (!Directory.Exists(MainForm.options.SavePath + "\\images\\"))//如果不存在就创建file文件夹　　             　　                
                                Directory.CreateDirectory(MainForm.options.SavePath + "\\images\\");//创建该文件夹　

                            int reconect = 0;
                            bool imgIsSave = false;
                            do
                            {
                                try
                                {
                                    DownloadImage(item,item.Attributes["src"].Value);
                                    imgIsSave = true;
                                }
                                catch (Exception)
                                {
                                    reconect++;
                                    MainForm.DownLoadFail?.Invoke(item.Attributes["src"].Value, reconect);
                                }

                            } while (!imgIsSave && reconect < MainForm.options.MaxReconnect);

                        }
                    }


                }


                if (param.Nodeoperate.Count > 0)
                {
                    foreach (var paramitem in param.Nodeoperate)
                    {
                        capture.CaptureFun(item, paramitem);

                    }
                }
            }
            if (MainBody.FirstChild.OuterHtml == " ")
            {
                MainBody.FirstChild.Remove();
            }

            string result = mainBody.DocumentNode.InnerHtml;
            return new string[] { Title.InnerHtml, result };


        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="URL">下载文件地址</param>
        /// <param name="Filename">下载后的存放地址</param>
        public void DownloadImage(HtmlNode node, string URL)
        {
            string filename;
            try
            {
                HttpWebRequest Myrq = (HttpWebRequest)HttpWebRequest.Create(URL);
                HttpWebResponse myrp = (HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;

                Stream st = myrp.GetResponseStream();
                BinaryReader br = new BinaryReader(st);
                string fileType = string.Empty; ;
                FileExtension extension;

                try
                {
                    byte data = br.ReadByte();
                    fileType += data.ToString();
                    data = br.ReadByte();
                    fileType += data.ToString();
                    try
                    {
                        extension = (FileExtension)Enum.Parse(typeof(FileExtension), fileType);
                    }
                    catch
                    {

                        extension = FileExtension.VALIDFILE;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                filename = Path.GetFileNameWithoutExtension(URL) + "."+extension.ToString();
                if (File.Exists(MainForm.options.SavePath + "\\images\\" + filename))
                    return;

                Stream so = new FileStream(MainForm.options.SavePath+ "\\images\\" + filename, FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);

                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();
            }
            catch (Exception)
            {
                throw;
            }
            node.Attributes.Remove("src");
            node.SetAttributeValue("src", "\\images\\" + filename);
        }
        public enum FileExtension
        {
            jpg = 255216,
            gif = 7173,
            png = 13780,
            swf = 6787,
            rar = 8297,
            zip = 8075,
            _7z = 55122,
            VALIDFILE = 9999999
        }

        public string OutHtml(string[] Captures)
        {

            string temple = (File.Exists(MainForm.options.TemplateFileName)) ? File.ReadAllText(MainForm.options.TemplateFileName
                ) : MainForm.options.TemplateHtml;
            string outHtml = string.Format(temple, Captures[0], Captures[1]);
            return outHtml;
        }


        public CaptureParameter getpara()
        {

            CaptureParameter param = new CaptureParameter();
            param.Nodeoperate = new List<NodeOperate>();

            param.GetMainMethod = GetMainMethodEnum.Id;
            param.GetMainString = "mainBody";


            NodeOperate removeall = new NodeOperate();
            param.Nodeoperate.Add(removeall);

            NodeOperate removekeep = new NodeOperate();
            param.Nodeoperate.Add(removekeep);
            NodeOperate delattribute = new NodeOperate();

            NodeOperate addchildren = new NodeOperate();
            param.Nodeoperate.Add(delattribute);

            param.Nodeoperate.Add(addchildren);


            removeall.method = MethodEnum.RemoveAll;
            removekeep.method = MethodEnum.Remove;
            addchildren.method = MethodEnum.AddChildren;
            delattribute.method = MethodEnum.DelAttribute;



            removeall.parameterlist = new List<parameterlist>(new parameterlist[] {
                new parameterlist() {parameter = new List<string>{ null, "class", "codeSnippetToolBar|codeSnippetContainerTabs" }},
                //new parameterlist() {parameter = new List<string>{ null, "class", "codeSnippetContainerTabs" }},
                new parameterlist() {parameter = new List<string>{ null, "class", "LW_CollapsibleArea_Anchor_Div" }},
                new parameterlist() {parameter = new List<string>{ null, "class", "LW_CollapsibleArea_HrDiv" }},
                new parameterlist() {parameter = new List<string>{ null, "class", "cl_CollapsibleArea_expanding" }}
            });

            removekeep.parameterlist = new List<parameterlist>(new parameterlist[] {
                new parameterlist() {parameter = new List<string>{ null, "class", "LW_CollapsibleArea_TitleAhref" }},
                new parameterlist() {parameter = new List<string>{ null, "class", "LW_CollapsibleArea_Title" } },
                new parameterlist() {parameter = new List<string>{ null, "class", "codeSnippetContainerCodeContainer" } },
                new parameterlist() {parameter = new List<string>{ null, "class", "codeSnippetContainer" } },
                new parameterlist() {parameter = new List<string>{ null, "class", "codeSnippetContainerCode" } },
                new parameterlist() {parameter = new List<string>{ null, "class", "sectionblock" } },
                new parameterlist() {parameter = new List<string>{ null, "class", "introduction" } },
                new parameterlist() {parameter = new List<string>{ "div", "class", "section" } },
                new parameterlist() {parameter = new List<string>{ "div", null, null } },
                new parameterlist() {parameter = new List<string>{ "span", "class", "sentence" } },
                new parameterlist() {parameter = new List<string>{ "sentencetext", null, "sentence" } }
            });

            delattribute.parameterlist = new List<parameterlist>(new parameterlist[] {
                new parameterlist() {parameter = new List<string>{ "strong", "xmlns", null,} },
                new parameterlist() {parameter = new List<string>{ "span", "xmlns", null,} }
            });

            addchildren.parameterlist = new List<parameterlist>(new parameterlist[] {
                new parameterlist() {parameter = new List<string>{ "pre", null, null,"code","class","code" }}
            });

            return param;

        }

    }

}
