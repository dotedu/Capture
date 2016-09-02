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
                if (node.ParentNode!=null)
                {
                    node.ParentNode.InsertBefore(child, node);

                }
            }
            node.Remove();
        }


        public static string[] GetAttributeValues(this HtmlNode node,string name,string def)
        {
            string value = node.GetAttributeValue(name, def);
            string[] values = value.Split(' ');
            return values;
        }

        public static bool IsExistAttributeValues(this HtmlNode node, string name, string value)
        {
            string[] array = GetAttributeValues(node, name,"");
            return System.Array.Exists(array, element => element == value);
        }


        public static void AddNodeBetwenParent(this HtmlNode node, string name)
        {
            AddNodeBetwenParent(node, name, null, null);
        }
        public static void AddNodeBetwenParent(this HtmlNode node, string name, string attribute, string value)
        {
            HtmlNode nodebefor = (string.IsNullOrEmpty(attribute) || string.IsNullOrEmpty(value)) ? HtmlNode.CreateNode("<" + name + ">") : HtmlNode.CreateNode("<" + name + " " + attribute + "=\"" + value + "\">");
            HtmlNode nodeafter = HtmlNode.CreateNode("</" + name + ">");
            node.InsertBefore(nodebefor,node);
            node.InsertAfter(nodeafter,node);
        }

        public static void AddNodeBetwenChild(this HtmlNode node, string name, string attribute, string value)
        {
            string nodeinsert= (string.IsNullOrEmpty(attribute) || string.IsNullOrEmpty(value)) ? "<" + name + ">{0} </" + name + ">" : "<" + name + " " + attribute + "=\"" + value + "\">{0} </" + name + ">";
            node.InnerHtml = string.Format(nodeinsert, node.InnerHtml);

        }

    }
}
