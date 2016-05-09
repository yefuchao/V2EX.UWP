using System.Runtime.Serialization;

namespace V2EX.UWP.Core.Models
{
    /// <summary>
    /// 节点
    /// </summary>
    /// 
    [DataContract]
    public class Node
    {
        [DataMember]
        public string ID
        { get; set; }
        [DataMember]
        public string Name
        { get; set; }
        [DataMember]
        public string Url
        { get; set; }
        [DataMember]
        public string Title
        { get; set; }
        [DataMember]
        public string Title_alternative
        { get; set; }
        [DataMember]
        public string Topics
        { get; set; }
        [DataMember]
        public string Stars
        { get; set; }
        [DataMember]
        public string Header
        { get; set; }
        [DataMember]
        public string Footer
        { get; set; }
        [DataMember]
        public string Created
        { get; set; }
        [DataMember]
        public string Avatar_mini
        { get; set; }
        [DataMember]
        public string Avartar_normal
        { get; set; }
        [DataMember]
        public string Avatar_large
        { get; set; }
    }
}