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
using UWP.V2EX.Models;
using System.Collections.ObjectModel;

namespace UWP.V2EX
{
    public class V2EXAPIProxy
    {
        public static async Task GetHotThemsAsync(ObservableCollection<ThemeObject> hots)
        {
            try
            {
                var hotTheme = await GetHot();

                foreach (var theme in hotTheme)
                {
                    hots.Add(theme);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //最热
        public async static Task<ObservableCollection<ThemeObject>> GetHot()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://www.v2ex.com/api/topics/hot.json");
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ObservableCollection<ThemeObject>>(result);

            //var serializer = new DataContractJsonSerializer(typeof(RootObject));

            //var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            //var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }

        //最新
        public async static Task<ObservableCollection<ThemeObject>> GetLatest()
        {
            var http = new HttpClient();

            var response = await http.GetAsync("https://www.v2ex.com/api/topics/latest.json");
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ObservableCollection<ThemeObject>>(result);

            return data;
        }

        //评论
        public async static Task<ObservableCollection<ReplyObject>> GetReply(string id)
        {
            var http = new HttpClient();
            var url = string.Format("https://www.v2ex.com//api/replies/show.json?topic_id={0}", id);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ObservableCollection<ReplyObject>>(result);

            return data;
        }

        //节点
        public async static Task<ObservableCollection<NodeObject>> GetNode(string nodename)
        {
            var http = new HttpClient();
            var url = string.Format("https://www.v2ex.com/api/nodes/show.json?name={0}", nodename);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ObservableCollection<NodeObject>>(result);

            return data;
        }

        //用户信息
        public async static Task<ObservableCollection<UserObject>> getUserInfo(string name)
        {
            var http = new HttpClient();
            var url = string.Format("https://www.v2ex.com/api/members/show.json?username={0}", name);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ObservableCollection<UserObject>>(result);

            return data;
        }
    }

    



}
