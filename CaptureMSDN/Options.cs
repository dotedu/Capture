using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureMSDN
{
    public class Options
    {
        public string TemplateHtml { get; set; } = "<!doctype html>\r\n<html>\r\n<head>\r\n<meta charset=\"utf-8\">\r\n<title>{0}</title>\r\n</head>\r\n<body>\r\n{1}\r\n</body>\r\n</html>";
        public string TemplateFileName { get; set; } = "Template.html";

        
    }
}
