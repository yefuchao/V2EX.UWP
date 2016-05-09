using System.Runtime.Serialization;

namespace V2EX.UWP.Core.Models
{
    /// <summary>
    /// 会员
    /// </summary>
    /// 
    [DataContract]
    public class Member
    {
        [DataMember]
        public string Status
        {
            get;set;
        }
        [DataMember]
        public string ID
        { get; set; }
        [DataMember]
        public string Url
        { get; set; }
        [DataMember]
        public string Username
        { get; set; }
        [DataMember]
        public string Website
        { get; set; }
        [DataMember]
        public string Twitter
        { get; set; }
        [DataMember]
        public string Psn
        { get; set; }
        [DataMember]
        public string Github
        { get; set; }
        [DataMember]
        public string Btc
        { get; set; }
        [DataMember]
        public string Location
        { get; set; }
        [DataMember]
        public string Tagline
        { get; set; }
        [DataMember]
        public string Bio
        { get; set; }
        [DataMember]
        public string Avatar_mini
        { get; set; }
        [DataMember]
        public string Avatar_normal
        { get; set; }
        [DataMember]
        public string Avatar_large
        { get; set; }
        [DataMember]
        public string Created
        { get; set; }
    }
}