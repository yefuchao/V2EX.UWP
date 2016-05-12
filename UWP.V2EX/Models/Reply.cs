using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.V2EX.Models
{
    public class Members
    {
        public int id { get; set; }
        public string username { get; set; }
        public string tagline { get; set; }
        public string avatar_mini { get; set; }
        public string avatar_normal { get; set; }
        public string avatar_large { get; set; }
    }

    public class ReplyObject
    {
        public int id { get; set; }
        public int thanks { get; set; }
        public string content { get; set; }
        public string content_rendered { get; set; }
        public Members member { get; set; }
        public int created { get; set; }
        public int last_modified { get; set; }
    }
}
