using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaptureMSDN
{
    class Capture
    {
        public void WebCapture(string url, string filepath)
        {
            try
            {
                WebClient myWebClient = new WebClient();
                byte[] myDataBuffer = myWebClient.DownloadData(url);
                string ContentHtml = Encoding.UTF8.GetString(myDataBuffer);

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(ContentHtml);
                HtmlNode MainBody = doc.GetElementbyId("mainBody");
                HtmlDocument mainBody = new HtmlDocument();
                mainBody.LoadHtml(MainBody.OuterHtml);
                //*[@id="mainBody"]/text()
                IEnumerable<HtmlNode> childlist = MainBody.Descendants();
                foreach (HtmlNode child_1 in childlist)
                {
                    if (child_1.InnerHtml==null)
                    {
                        child_1.RemoveAll();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string MainCapturesById(string url,string id)
        {
            try
            {
                WebClient myWebClient = new WebClient();
                byte[] myDataBuffer = myWebClient.DownloadData(url);
                string ContentHtml = Encoding.UTF8.GetString(myDataBuffer);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(ContentHtml);
                HtmlNode MainBody = doc.GetElementbyId(id);
                return MainBody.OuterHtml;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string WebCapturesStr(string url, string id)
        {

                HtmlDocument mainBody = new HtmlDocument();
                mainBody.LoadHtml(MainCapturesById(url,id));

            //object[,] DelParam=null;
            List<object[]> DelParam = new List<object[]>();
            DelParam.Add(new object[] { "class", "codeSnippetToolBar", null });
            DelParam.Add(new object[] { "class", "codeSnippetContainerTabs", null });
            DelParam.Add(new object[] { "class", "LW_CollapsibleArea_Anchor_Div", null });
            DelParam.Add(new object[] { "class", "LW_CollapsibleArea_TitleAhref", true });
            DelParam.Add(new object[] { "class", "LW_CollapsibleArea_HrDiv", null });
            DelParam.Add(new object[] { "class", "cl_CollapsibleArea_expanding LW_CollapsibleArea_Img", null });
            DelParam.Add(new object[] { "class", "LW_CollapsibleArea_Title", true });

            DelByAttribtes(mainBody.DocumentNode, DelParam);
                
                string result = mainBody.DocumentNode.OuterHtml;
                
                return result;

        }

        public bool IsOverlap(HtmlNode node)
        {
            IEnumerable<HtmlNode> childlist = node.Descendants(node.Name);

            if (childlist!=null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void DelByAttribtes(HtmlNode htmlnode, List<object[]> Parameters)
        {
            HtmlNode[] childlist = htmlnode.Descendants().ToArray();

            if (Parameters.Count>0)
            {
                foreach (var item in Parameters)
                {
                    foreach (var nodeitem in childlist)
                    {
                        if (nodeitem.Attributes.Contains(item[0].ToString()))
                        {
                            if (nodeitem.GetAttributeValue(item[0].ToString(), "") == item[1].ToString())
                            {
                                Debug.Write(item[2]);
                                if (Convert.ToBoolean(item[2]))
                                {
                                    nodeitem.ParentNode.RemoveChild(nodeitem, true);

                                }
                                else
                                {
                                    nodeitem.Remove();

                                }
                            }

                        }

                    }
                }


            }
        }
    }
}
