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
            Debug.Write(Operate.method);
            switch (Operate.method)
            {
                case MethodEnum.RemoveAll:
                        RemoveAll(node, Operate.parameterlist);
                    break;
                case MethodEnum.Remove:
                        RemoveKeep(node, Operate.parameterlist);
                    break;
                case MethodEnum.Replace:
                    //Console.WriteLine("您通过了");
                    break;
                default:
                    break;
            }

        }

        private void RemoveAll(HtmlNode node, IList<IList<string>> parameter)
        {
            Remove(node, parameter, false);
        }

        private void RemoveKeep(HtmlNode node, IList<IList<string>> parameter)
        {
            Remove(node, parameter, true);
        }


        private void Remove(HtmlNode node, IList<IList<string>> parameterlist, bool keepGrandChildren)
        {
            if (parameterlist == null)
                return;
            if (parameterlist != null && parameterlist.Count > 0)
            {
                foreach (var item in parameterlist)
                {
                    if (!string.IsNullOrEmpty(item[0]) && string.IsNullOrEmpty(item[1]))
                    {
                        if (node.Name == item[0])
                        {
                            if (item[1]==null)
                            {
                                if (keepGrandChildren)
                                {
                                    //node.ParentNode.RemoveChild(node, true);
                                    node.RemoveNodeKeepChildren();
                                }
                                else
                                {
                                    node.Remove();
                                }

                            }
                            else if (item[1] == "")
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
                    else if (!string.IsNullOrEmpty(item[0]) && !string.IsNullOrEmpty(item[1]))
                    {

                        if (node.Name == item[0])
                        {

                            if (string.IsNullOrEmpty(item[2]))
                            {
                                item[2] = "";
                            }

                            if (node.Attributes.Contains(item[1]))
                            {
                                if (node.GetAttributeValue(item[1], "") == item[2])
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
                    else if (string.IsNullOrEmpty(item[0]) && !string.IsNullOrEmpty(item[1]))
                    {
                        if (string.IsNullOrEmpty(item[2]))
                        {
                            item[2] = "";
                        }
                        if (node.Attributes.Contains(item[1]))
                        {
                            if (node.GetAttributeValue(item[1], "") == item[2])
                            {
                                if (keepGrandChildren)
                                {
                                    node.ParentNode.RemoveChild(node, true);
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
            }
        }
    }
}
