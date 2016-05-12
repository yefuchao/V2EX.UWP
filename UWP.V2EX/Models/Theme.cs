using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UWP.V2EX.Models
{

    [DataContract]
    public class Member
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string tagline { get; set; }
        [DataMember]
        public string avatar_mini { get; set; }
        [DataMember]
        public string avatar_normal { get; set; }
        [DataMember]
        public string avatar_large { get; set; }
    }

    [DataContract]
    public class Node
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string title_alternative { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public int topics { get; set; }
        [DataMember]
        public string avatar_mini { get; set; }
        [DataMember]
        public string avatar_normal { get; set; }
        [DataMember]
        public string avatar_large { get; set; }
    }

    public class ThemeObject
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string content { get; set; }
        [DataMember]
        public string content_rendered { get; set; }
        [DataMember]
        public int replies { get; set; }
        [DataMember]
        public Member member { get; set; }
        [DataMember]
        public Node node { get; set; }
        [DataMember]
        public int created { get; set; }
        [DataMember]
        public int last_modified { get; set; }
        [DataMember]
        public int last_touched { get; set; }
    }



}
