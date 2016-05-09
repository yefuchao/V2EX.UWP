using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace V2EX.UWP.Core.Models
{
    /// <summary>
    /// 主题
    /// </summary>
    /// 
    [DataContract]
    public class Subject
    {
        [DataMember]
        public string ID
        {
            get; set;
        }

        [DataMember]
        public string Title
        {
            get; set;
        }

        [DataMember]
        public string Url
        {
            get; set;
        }

        [DataMember]
        public string Content
        {
            get; set;
        }

        [DataMember]
        public string Content_rendered
        {
            get; set;
        }

        [DataMember]
        public string Replies
        {
            get; set;
        }
        [DataMember]
        public string Member_id
        {
            get; set;
        }

        [DataMember]
        public string Node_id
        { get; set; }

        [DataMember]
        public string Created
        {
            get; set;
        }
        [DataMember]
        public string Last_Modified
        {
            get; set;
        }
        [DataMember]
        public string Last_touched
        {
            get; set;
        }

        public ObservableCollection<Member> Members;

        public ObservableCollection<Node> Nodes;

    }
}
