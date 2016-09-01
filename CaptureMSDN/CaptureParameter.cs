using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureMSDN
{
    public class CaptureParameter
    {
        public MethodEnum Method { get; set; }
        public Node OldNode { get; set; }
        public Node NewNode { get; set; }


    }

    public class Node
    {
        public List<string[]> NodeInfo { get; set; }

    }


    public enum MethodEnum
    {
        /// <summary>
        /// 
        /// </summary>
        Remove,

        RemoveAll,
        /// <summary>
        /// 
        /// </summary>
        Replace,
        /// <summary>
        /// 
        /// </summary>
        AddParent,

        AddChildren,

        DelAttribute,

        ReplaceAttribute,


    }
}
