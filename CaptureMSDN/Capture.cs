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

        public void WebCapture(string url,string filepath)
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

        public string MainCapturesById(string url)
        {
            try
            {
                WebClient myWebClient = new WebClient();
                byte[] myDataBuffer = myWebClient.DownloadData(url);
                string ContentHtml = Encoding.UTF8.GetString(myDataBuffer);
                //HtmlDocument doc = new HtmlDocument();
                //doc.LoadHtml(ContentHtml);
               // HtmlNode MainBody = doc.GetElementbyId(id);
                return ContentHtml;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string WebCapturesStr(string html,CaptureParameter param)
        {

            HtmlNode MainBody;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            
            if (param.GetMainMethod== GetMainMethodEnum.Id)
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
                if (param.Nodeoperate.Count>0)
                {
                    foreach (var paramitem in param.Nodeoperate)
                    {
                        capture.CaptureFun(item, paramitem);

                    }
                }
            }

            string result = mainBody.DocumentNode.OuterHtml;
                
                return result;

        }

        public CaptureParameter getpara()
        {



            CaptureParameter param = new CaptureParameter();
            param.Nodeoperate = new List<NodeOperate>() ;

            param.GetMainMethod = GetMainMethodEnum.Id;
            param.GetMainString = "mainBody";


            NodeOperate removeall = new NodeOperate();
            param.Nodeoperate.Add(removeall);

            NodeOperate removekeep = new NodeOperate();
            param.Nodeoperate.Add(removekeep);

            removeall.method = MethodEnum.RemoveAll;
            removeall.parameterlist = new List<IList<string>>();
            removeall.parameterlist.Add(new List<string> { null, "class", "codeSnippetToolBar" });
            removeall.parameterlist.Add(new List<string> { null, "class", "codeSnippetContainerTabs" });
            removeall.parameterlist.Add(new List<string> { null, "class", "LW_CollapsibleArea_Anchor_Div" });
            removeall.parameterlist.Add(new List<string> { null, "class", "LW_CollapsibleArea_HrDiv" });
            removeall.parameterlist.Add(new List<string> { null, "class", "cl_CollapsibleArea_expanding LW_CollapsibleArea_Img" });



            removekeep.method = MethodEnum.Remove;
            removekeep.parameterlist = new List<IList<string>>();
            removekeep.parameterlist.Add(new List<string> { null, "class", "LW_CollapsibleArea_TitleAhref" });
            removekeep.parameterlist.Add(new List<string> { null, "class", "LW_CollapsibleArea_Title" });
            removekeep.parameterlist.Add(new List<string> { null, "class", "codeSnippetContainerCodeContainer" });
            removekeep.parameterlist.Add(new List<string> { null, "class", "codeSnippetContainer" });
            removekeep.parameterlist.Add(new List<string> { null, "class", "codeSnippetContainerCode" });
            removekeep.parameterlist.Add(new List<string> { null, "class", "sectionblock" });
            removekeep.parameterlist.Add(new List<string> { null, "class", "introduction" });
            removekeep.parameterlist.Add(new List<string> { "div", "class", "section" });
            removekeep.parameterlist.Add(new List<string> { "div", "", null });
            removekeep.parameterlist.Add(new List<string> { "span", "class", "sentence" });
            removekeep.parameterlist.Add(new List<string> { "sentencetext", null, "sentence" });

            return param;

        }

    }
}
