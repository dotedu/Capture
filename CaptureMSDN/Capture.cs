using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaptureMSDN
{
    class Capture
    {

        CaptureProvider capture = new CaptureProvider();
        Options options = new Options();

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
                return ContentHtml;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string CapturesTitle(string html)
        {

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode Title = doc.DocumentNode.SelectSingleNode("//title");
            return Title.InnerHtml;

        }
        public string CapturesBody(string html,CaptureParameter param)
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
            if (MainBody.FirstChild.OuterHtml== " ")
            {
                MainBody.FirstChild.Remove();
            }
            string result = mainBody.DocumentNode.InnerHtml;
                
                return result;

        }


        public string OutHtml(string url)
        {
            string temple = (File.Exists(Path.Combine(Environment.CurrentDirectory, options.TemplateFileName))) ? File.ReadAllText(Path.Combine(Environment.CurrentDirectory, options.TemplateFileName)) : options.TemplateHtml;
            string outHtml = string.Format(temple, CapturesTitle(MainCapturesById(url)), CapturesBody(MainCapturesById(url), getpara()));
            return outHtml;
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
