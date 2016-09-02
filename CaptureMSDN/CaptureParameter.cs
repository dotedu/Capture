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


    //public class NodeOperate
    //{
    //    public MethodEnum method { get; set; }
    //    public IList<IList<string>> parameterlist { get; set; }

    //}

    public class NodeOperate
    {
        public MethodEnum method { get; set; }
        public List<parameterlist> parameterlist { get; set; } = null;

    }


    public class parameterlist
    {
        public List<string> parameter { get; set; }

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
        AddAttribute
    }

    public enum GetMainMethodEnum
    {
        Id,
        Xpath,



    }

}
