using HtmlAgilityPack;
using System.Diagnostics;

namespace CaptureMSDN
{
    internal static class HtmlAgilityPackExtensions
    {
        public static void RemoveNodeKeepChildren(this HtmlNode node)
        {
            foreach (var child in node.ChildNodes)
            {
                Debug.Write(node.Name+node.OuterHtml);
                node.ParentNode.InsertBefore(child, node);
            }
            node.Remove();
        }
        public static void AddNodeBetwenParent(this HtmlNode node,string name,string attribute, string value)
        {
            HtmlNode nodebefor;
            HtmlNode nodeafter;

            if (string.IsNullOrEmpty(attribute)|| string.IsNullOrEmpty(value))
            {
                nodebefor = HtmlNode.CreateNode("<" + name + ">"); ;
                nodeafter = HtmlNode.CreateNode("</" + name + ">");
            }
            else
            {
                nodebefor = HtmlNode.CreateNode("<"+name+">");
                nodeafter = HtmlNode.CreateNode("</" + name + ">");
            }
        }

        public static void AddNodeBetwenParent()
        {

        }

    }
}
