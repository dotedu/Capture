using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureMSDN
{
    public class CaptureProvider
    {

        public void CaptureFun(HtmlNode node, NodeOperate Operate)
        {
            switch (Operate.method)
            {
                case MethodEnum.RemoveAll:
                    if (Operate.parameterlist == null)
                        break;
                    RemoveAll(node, Operate.parameterlist);
                    break;
                case MethodEnum.Remove:
                    if (Operate.parameterlist == null)
                        break;
                    RemoveKeep(node, Operate.parameterlist);
                    break;
                case MethodEnum.AddChildren:
                    if (Operate.parameterlist == null)
                        break;
                    AddChildren(node, Operate.parameterlist);
                    break;
                case MethodEnum.Replace:
                    if (Operate.parameterlist == null)
                        break;
                    Replace(node, Operate.parameterlist);
                    break;
                default:
                    break;
            }

        }

        private void RemoveAll(HtmlNode node, IList<parameterlist> parameter)
        {
            Remove(node, parameter, false);
        }

        private void RemoveKeep(HtmlNode node, IList<parameterlist> parameter)
        {
            Remove(node, parameter, true);
        }


        private void Remove(HtmlNode node, IList<parameterlist> parameterlist, bool keepGrandChildren)
        {
            if (parameterlist != null && parameterlist.Count > 0)
            {
                foreach (var item in parameterlist)
                {
                    
                    if (!string.IsNullOrEmpty(item.parameter[0]) && string.IsNullOrEmpty(item.parameter[1]))
                    {
                        if (node.Name == item.parameter[0])
                        {
                            if (item.parameter[1]==null)
                            {
                                if (keepGrandChildren)
                                {
                                    node.RemoveNodeKeepChildren();
                                }
                                else
                                {
                                    node.Remove();
                                }

                            }
                            else if (item.parameter[1] == "")
                            {
                                if (!node.HasAttributes)
                                {
                                    if (keepGrandChildren)
                                    {
                                        node.RemoveNodeKeepChildren();
                                    }
                                    else
                                    {
                                        node.Remove();
                                    }


                                }
                            }
                        }
                    }
                    else if (!string.IsNullOrEmpty(item.parameter[0]) && !string.IsNullOrEmpty(item.parameter[1]))
                    {

                        if (node.Name == item.parameter[0])
                        {

                            if (string.IsNullOrEmpty(item.parameter[2]))
                            {
                                item.parameter[2] = "";
                            }

                            if (node.Attributes.Contains(item.parameter[1]))
                            {
                                RemoveByAttvalue(node, item.parameter[1], item.parameter[2], keepGrandChildren);
                            }


                        }
                    }
                    else if (string.IsNullOrEmpty(item.parameter[0]) && !string.IsNullOrEmpty(item.parameter[1]))
                    {
                        if (string.IsNullOrEmpty(item.parameter[2]))
                        {
                            item.parameter[2] = "";
                        }
                        if (node.Attributes.Contains(item.parameter[1]))
                        {
                            RemoveByAttvalue(node, item.parameter[1], item.parameter[2], keepGrandChildren);

                        }

                    }
                }
            }
        }



        private void RemoveByAttvalue(HtmlNode node, string attname,string attvalue, bool keepGrandChildren)
        {
            if (attvalue.Contains('&'))
            {
                string[] values = attvalue.Split('&');
                foreach (var item in values)
                {
                    if(!node.IsExistAttributeValues(attname, item))
                    {
                        return;
                    }                   
                }
                if (keepGrandChildren)
                {
                    node.RemoveNodeKeepChildren();
                }
                else
                {
                    node.Remove();
                }
            }
            else
            {
                string[] values = attvalue.Split('|');
                foreach (var item in values)
                {
                    if (node.IsExistAttributeValues(attname, item))
                    {
                        if (keepGrandChildren)
                        {
                            node.RemoveNodeKeepChildren();
                        }
                        else
                        {
                            node.Remove();
                        }
                        break;
                    }
                }

            }


        }


        private void AddChildren(HtmlNode node, IList<parameterlist> parameterlist)
        {
            if (parameterlist != null && parameterlist.Count > 0)
            {
                foreach (var item in parameterlist)
                {
                    if (string.IsNullOrEmpty(item.parameter[2]))
                    {
                        item.parameter[2] = "";
                    }
                    if (string.IsNullOrEmpty(item.parameter[0])|| string.IsNullOrEmpty(item.parameter[3]))
                    {
                        return;
                    }
                    else if (string.IsNullOrEmpty(item.parameter[1]))
                    {
                        if (node.Name==item.parameter[0])
                        {
                            node.AddNodeBetwenChild(item.parameter[3], item.parameter[4], item.parameter[5]);
                        }

                    }
                    else
                    {
                        if (node.Name == item.parameter[0]&&node.Attributes.Contains(item.parameter[1]))
                        {
                            if (item.parameter[2].Contains('&'))
                            {
                                string[] values = item.parameter[2].Split('&');
                                foreach (var value in values)
                                {
                                    if (!node.IsExistAttributeValues(item.parameter[1], value))
                                    {
                                        return;

                                    }

                                }

                            }
                            else
                            {
                                string[] values = item.parameter[2].Split('|');
                                foreach (var value in values)
                                {
                                    if (!node.IsExistAttributeValues(item.parameter[1], value))
                                    {
                                        node.AddNodeBetwenChild(item.parameter[3], item.parameter[4], item.parameter[5]);
                                    }

                                }

                            }
                        }
                    }
                }
            }
        }
        private void Replace(HtmlNode node, IList<parameterlist> parameterlist)
        {

        }
        private void AddParent(HtmlNode node, IList<parameterlist> parameterlist)
        {

        }
        private void DelAttribute(HtmlNode node, IList<parameterlist> parameterlist)
        {

        }

        private void AddAttribute(HtmlNode node, IList<parameterlist> parameterlist)
        {

        }
        private void ReplaceAttribute(HtmlNode node, IList<parameterlist> parameterlist)
        {

        }
        

    }
}
