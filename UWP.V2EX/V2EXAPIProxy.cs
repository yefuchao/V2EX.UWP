using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UWP.V2EX
{
    public class V2EXAPIProxy
    {
        //最热
        public async static Task<List<RootObject>> GetHot()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://www.v2ex.com/api/topics/hot.json");
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<RootObject>>(result);

            //var serializer = new DataContractJsonSerializer(typeof(RootObject));

            //var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            //var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }

        //最新
        public async static Task<List<RootObject>> GetLatest()
        {
            var http = new HttpClient();

            var response = await http.GetAsync("https://www.v2ex.com/api/topics/latest.json");
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<RootObject>>(result);

            return data;
        }

        //节点
        public async static Task<List<NodeObject>> GetNode(string nodename)
        {
            var http = new HttpClient();
            var url = string.Format("https://www.v2ex.com/api/nodes/show.json?name={0}", nodename);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<NodeObject>>(result);

            return data;
        }

        //用户信息
        public async static Task<List<UserObject>> getUserInfo(string name)
        {
            var http = new HttpClient();
            var url = string.Format("https://www.v2ex.com/api/members/show.json?username={0}", name);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<List<UserObject>>(result);

            return data;
        }
    }

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

    [DataContract]
    public class RootObject
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

    public class UserObject
    {
        public string status { get; set; }
        public int id { get; set; }
        public string url { get; set; }
        public string username { get; set; }
        public string website { get; set; }
        public string twitter { get; set; }
        public string psn { get; set; }
        public string github { get; set; }
        public string btc { get; set; }
        public string location { get; set; }
        public string tagline { get; set; }
        public string bio { get; set; }
        public string avatar_mini { get; set; }
        public string avatar_normal { get; set; }
        public string avatar_large { get; set; }
        public int created { get; set; }
    }

}
