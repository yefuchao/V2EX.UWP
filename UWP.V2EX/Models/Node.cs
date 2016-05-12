using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UWP.V2EX.Models
{
    [DataContract]
    public class NodeObject
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string title_alternative { get; set; }
        [DataMember]
        public int topics { get; set; }
        [DataMember]
        public int stars { get; set; }
        [DataMember]
        public string header { get; set; }
        [DataMember]
        public object footer { get; set; }
        [DataMember]
        public int created { get; set; }
        [DataMember]
        public string avatar_mini { get; set; }
        [DataMember]
        public string avatar_normal { get; set; }
        [DataMember]
        public string avatar_large { get; set; }
    }

    public class AllNodes
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string title_alternative { get; set; }
        public int topics { get; set; }
        public string header { get; set; }
        public string footer { get; set; }
        public int created { get; set; }
    }
}
