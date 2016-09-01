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

        public void CaptureFun(HtmlNode node, CaptureParameter parameter)
        {
            Debug.Write(parameter.Method);
            switch (parameter.Method)
            {
                case MethodEnum.RemoveAll:
                    RemoveAll(node, parameter.OldNode.NodeInfo);
                    break;
                case MethodEnum.Remove:
                    RemoveKeep(node, parameter.OldNode.NodeInfo);
                    break;
                case MethodEnum.Replace:
                    Console.WriteLine("您通过了");
                    break;
                default:
                    break;
            }

        }

        private void RemoveAll(HtmlNode node, List<string[]> NodeInfo)
        {
            Remove(node, NodeInfo, false);
        }

        private void RemoveKeep(HtmlNode node, List<string[]> NodeInfo)
        {
            Remove(node, NodeInfo, true);
        }


        private void Remove(HtmlNode node, List<string[]> NodeInfo, bool keepGrandChildren)
        {
            if (NodeInfo == null)
                return;
            if (NodeInfo != null && NodeInfo.Count > 0)
            {
                foreach (var item in NodeInfo)
                {
                    if (!string.IsNullOrEmpty(item[0]) && string.IsNullOrEmpty(item[1]))
                    {
                        if (node.Name == item[0])
                        {
                            if (item[0]==null)
                            {
                                if (keepGrandChildren)
                                {
                                    node.ParentNode.RemoveChild(node, true);
                                }
                                else
                                {
                                    node.Remove();
                                }

                            }
                            else
                            {
                                if (!node.HasAttributes)
                                {
                                    if (keepGrandChildren)
                                    {
                                        node.ParentNode.RemoveChild(node, true);
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
