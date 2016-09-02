using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureMSDN
{
    public class CaptureParameter
    {
        public GetMainMethodEnum GetMainMethod { get; set; }
        public string GetMainString { get; set; }
        public IList<NodeOperate> Nodeoperate { get; set; }
    }


    public class NodeOperate
    {
        public MethodEnum method { get; set; }
        public IList<IList<string>> parameterlist { get; set; }

    }

    public class NodeO
    {
        public IList<ppp> list { get; set; }

    }

    public class ppp
    {
        public string[] a;
    }



    public enum MethodEnum
    {
        Remove,

        RemoveAll,
        Replace,
        AddParent,

        AddChildren,

        DelAttribute,

        ReplaceAttribute,


    }

    public enum GetMainMethodEnum
    {
        Id,
        Xpath,



    }

}
