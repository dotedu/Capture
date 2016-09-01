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
        public string WebCapturesStr(string url, string id, CaptureParameter param)
        {

                HtmlDocument mainBody = new HtmlDocument();
                mainBody.LoadHtml(MainCapturesById(url,id));




            HtmlNode[] childlist = mainBody.DocumentNode.Descendants().ToArray();

            foreach (var item in childlist)
            {
                if (param.nodeOperate.Count>0)
                {
                    foreach (var paramitem in param.nodeOperate)
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
            NodeOperate removeall = new NodeOperate();
            removeall.method = MethodEnum.RemoveAll;
            param.nodeOperate = new List<NodeOperate>();

            param.GetMainMethod = GetMainMethodEnum.Id;
            param.GetMainString = "mainBody";

            removeall.parameterlist = new List<ParameterList>();
            //list1.parameter.Add
            ParameterList lis1 = new ParameterList(new List<string> { null, "class", "codeSnippetContainerTabs" }) ;

            //参数是一个必须可能跌代的对象,也可是数组  
            //list.AddRange(new Person[] { new Person("aladdin", 20), new Person("zhao", 6) });


            //构造传入批量参数 ,与AddRange效果一样
            //List<Person> mylist = new List<Person>(new Person[] { new Person("aladdin", 20), new Person("zhao", 6) });
            list1.Add(new List<string> { null, "class", "codeSnippetToolBar" });
            removeall.parameterlist.Add(new ParameterList[] { null, "class", "codeSnippetContainerTabs" });
            removeall.parameter.Add(new List<string> { null, "class", "LW_CollapsibleArea_Anchor_Div" });
            removeall.parameter.Add(new List<string> { null, "class", "LW_CollapsibleArea_HrDiv" });
            removeall.parameter.Add(new List<string> { null, "class", "cl_CollapsibleArea_expanding LW_CollapsibleArea_Img" });

            removeall.parameterlist.Add(list1);
            param.nodeOperate.Add(removeall);

            NodeOperate removekeep = new NodeOperate();
            removekeep.method = MethodEnum.Remove;
            removekeep.parameter.Add(new List<string> { null, "class", "LW_CollapsibleArea_TitleAhref" });
            removekeep.parameter.Add(new List<string> { null, "class", "LW_CollapsibleArea_Title" });
            removekeep.parameter.Add(new List<string> { null, "class", "codeSnippetContainerCodeContainer" });
            removekeep.parameter.Add(new List<string> { null, "class", "codeSnippetContainer" });
            removekeep.parameter.Add(new List<string> { null, "class", "codeSnippetContainerCode" });
            removekeep.parameter.Add(new List<string> { null, "class", "sectionblock" });
            removekeep.parameter.Add(new List<string> { null, "class", "introduction" });
            removekeep.parameter.Add(new List<string> { "div", "class", "section" });
            removekeep.parameter.Add(new List<string> { "div", "", null });
            removekeep.parameter.Add(new List<string> { "span", "class", "sentence" });
            removekeep.parameter.Add(new List<string> { "sentencetext", null, "sentence" });
            param.nodeOperate.Add(removekeep);

            return param;

        }

    }
}
