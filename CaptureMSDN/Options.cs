using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureMSDN
{
    public class Options
    {
        public string TemplateHtml { get; set; } = "<!doctype html>\r\n<html>\r\n<head>\r\n<meta charset=\"utf-8\">\r\n<title>{0}</title>\r\n</head>\r\n<body>\r\n{1}\r\n</body>\r\n</html>";
        public string TemplateFileName { get; set; } = Environment.CurrentDirectory + "\\Template\\Template.html";
        public int Seeds { get; set; } = 50;
        public int MaxReconnect { get; set; } = 5;
        public string SavePath { get; set; } = Environment.CurrentDirectory + "\\documents";

        public string SaveExtension { get; set; } = "html";
        public bool SaveImage { get; set; } = true;
    }

    public class configure
    {
        internal const string OptionsFileName = "options.cfg";
        internal static Options ReadOptions()
        {
            Options options;
            if (File.Exists(Path.Combine(Environment.CurrentDirectory, OptionsFileName)))
            {
                options = JsonConvert.DeserializeObject<Options>(
                    File.ReadAllText(Path.Combine(Environment.CurrentDirectory, OptionsFileName)));
            }
            else
            {
                options = new Options();
                File.WriteAllText(Path.Combine(Environment.CurrentDirectory, OptionsFileName),
                    JsonConvert.SerializeObject(options, Formatting.Indented));
            }
            return options;
        }
    }
}
