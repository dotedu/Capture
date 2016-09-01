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

        CaptureProvider capture = new CaptureProvider();

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

            List<CaptureParameter> param = new List<CaptureParameter>();

            CaptureParameter removeall = new CaptureParameter();

            removeall.Method = MethodEnum.RemoveAll;

            removeall.OldNode = new Node();
            removeall.OldNode.NodeInfo = new List<string[]>();
            removeall.OldNode.NodeInfo.Add(new string[] { null, "class", "codeSnippetToolBar" });
            removeall.OldNode.NodeInfo.Add(new string[] { null, "class", "codeSnippetContainerTabs" });
            removeall.OldNode.NodeInfo.Add(new string[] { null, "class", "LW_CollapsibleArea_Anchor_Div" });
            removeall.OldNode.NodeInfo.Add(new string[] { null, "class", "LW_CollapsibleArea_HrDiv" });
            removeall.OldNode.NodeInfo.Add(new string[] { null, "class", "cl_CollapsibleArea_expanding LW_CollapsibleArea_Img" });
            param.Add(removeall);

            CaptureParameter removekeep = new CaptureParameter();
            removekeep.Method = MethodEnum.Remove;
            removekeep.OldNode = new Node();
            removekeep.OldNode.NodeInfo = new List<string[]>();
            removekeep.OldNode.NodeInfo.Add(new string[] { null, "class", "LW_CollapsibleArea_TitleAhref" });
            removekeep.OldNode.NodeInfo.Add(new string[] { null, "class", "LW_CollapsibleArea_Title" });
            removekeep.OldNode.NodeInfo.Add(new string[] { null, "class", "codeSnippetContainerCodeContainer" });
            removekeep.OldNode.NodeInfo.Add(new string[] { null, "class", "codeSnippetContainer" });
            removekeep.OldNode.NodeInfo.Add(new string[] { null, "class", "codeSnippetContainerCode" });
            removekeep.OldNode.NodeInfo.Add(new string[] { null, "class", "sectionblock" });
            removekeep.OldNode.NodeInfo.Add(new string[] { null, "class", "introduction" });
            //removekeep.OldNode.NodeInfo.Add(new string[] { null, "class", "section" });
            removekeep.OldNode.NodeInfo.Add(new string[] { "div", "", null });
            removekeep.OldNode.NodeInfo.Add(new string[] { null, "class", "sentence" });
            param.Add(removekeep);




            List<object[]> DelParam = new List<object[]>();

            DelParam.Add(new object[] { null, "class", "LW_CollapsibleArea_TitleAhref", true });
            DelParam.Add(new object[] { null, "class", "LW_CollapsibleArea_Title", true });
            DelParam.Add(new object[] { null, "class", "codeSnippetContainerCodeContainer", true });
            DelParam.Add(new object[] { null, "class", "codeSnippetContainer", true });
            DelParam.Add(new object[] { null, "class", "codeSnippetContainerCode", true });           
            DelParam.Add(new object[] { null, "class", "sectionblock", true });
            DelParam.Add(new object[] { "span", "class", "sentence", true });
            DelParam.Add(new object[] { "div", "class", "introduction", true });
            DelParam.Add(new object[] { "div", "class", "section", true });


            DelParam.Add(new object[] { "div", "", null, true });
            //DelParam.Add(new object[] { "sentencetext", null, null, true });

            //DelByAttribtes(mainBody.DocumentNode, DelParam);

            HtmlNode[] childlist = mainBody.DocumentNode.Descendants().ToArray();

            foreach (var item in childlist)
            {
                if (param.Count>0)
                {
                    foreach (var paramitem in param)
                    {
                        capture.CaptureFun(item, paramitem);

                    }
                }

            }
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
            if (Parameters.Count>0)
            {
                foreach (var item in Parameters)
                {
                    if (item[0]==null)
                    {
                        item[0] = "all";
                    }
                    HtmlNode[] childlist = (item[0].ToString()!="all")?htmlnode.Descendants(item[0].ToString()).ToArray(): htmlnode.Descendants().ToArray();
                    if (childlist.Length>0)
                    {

                        foreach (var nodeitem in childlist)
                        {
                            
                            if (item[1]==null&&nodeitem.Name==item[0].ToString())
                            {

                                if (Convert.ToBoolean(item[3]))
                                {
                                    nodeitem.ParentNode.RemoveChild(nodeitem, true);
                                }
                                else
                                {
                                    nodeitem.Remove();
                                }
                            }
                            else if (item[1].ToString() == "" && nodeitem.Name == item[0].ToString()&&nodeitem.Attributes.Count==0)
                            {
                                if (Convert.ToBoolean(item[3]))
                                {
                                    nodeitem.ParentNode.RemoveChild(nodeitem, true);
                                }
                                else
                                {
                                    nodeitem.Remove();
                                }

                            }
                            else if (nodeitem.Attributes.Contains(item[1].ToString()))
                            {
                                if (item[2]==null)
                                {
                                    item[2] = "";
                                }
                                if (nodeitem.GetAttributeValue(item[1].ToString(), "") == item[2].ToString())
                                {
                                    //Debug.Write(item[3]);
                                    if (Convert.ToBoolean(item[3]))
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

        public void AddParentNode(HtmlNode node,string name, IDictionary<string, object> attributes)
        {
            string newnodestr = "<" + name + "{0}>{1}</" + name + ">";
            string nodeInner = node.OuterHtml;
            if (attributes.Count>0)
            {
                StringBuilder data = new StringBuilder(string.Empty);
                foreach (var item in attributes)
                {
                    data.AppendFormat(" {0}=\"{1}\"", item.Key,item.Value);
                }
            }


            HtmlNode newnode = HtmlNode.CreateNode("");
            node.ParentNode.ReplaceChild(newnode, node);
        }


    }
}
