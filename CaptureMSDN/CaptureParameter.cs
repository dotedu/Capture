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
        public IList<NodeOperate> nodeOperate { get; set; }
    }


    public class NodeOperate
    {
        public MethodEnum method { get; set; }
        public IList<ParameterList> parameterlist { get; set; }

    }

    public class ParameterList
    {
        public IList<string> parameter { get; set; }

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
