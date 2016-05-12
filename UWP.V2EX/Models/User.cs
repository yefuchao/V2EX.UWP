using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UWP.V2EX.Models
{
    [DataContract]
    public class UserObject
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string website { get; set; }
        [DataMember]
        public string twitter { get; set; }
        [DataMember]
        public string psn { get; set; }
        [DataMember]
        public string github { get; set; }
        [DataMember]
        public string btc { get; set; }
        [DataMember]
        public string location { get; set; }
        [DataMember]
        public string tagline { get; set; }
        [DataMember]
        public string bio { get; set; }
        [DataMember]
        public string avatar_mini { get; set; }
        [DataMember]
        public string avatar_normal { get; set; }
        [DataMember]
        public string avatar_large { get; set; }
        [DataMember]
        public int created { get; set; }
    }

}
