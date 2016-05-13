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
        //取最新主题
        public static async Task GetAllTopic(ObservableCollection<ThemeObject> alltopic)
        {
            try
            {
                var topics = await GetLatest();

                foreach (var topic in topics)
                {
                    alltopic.Add(topic);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //取最热主题
        public static async Task GetHotThemsAsync(ObservableCollection<ThemeObject> hots)
        {
            try
            {
                var hotTheme = await GetHot();

                foreach (var theme in hotTheme)
                {
                    theme.member.avatar_mini = "http:" + theme.member.avatar_mini;
                    theme.member.avatar_normal = "http:" + theme.member.avatar_normal;
                    theme.member.avatar_large = "http:" + theme.member.avatar_large;
                    hots.Add(theme);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //根据ID取回复
        public static async Task GetReplaysAsync(ObservableCollection<ReplyObject> replysList,int id)
        {
            try
            {
                var replys = await GetReply(id);

                foreach (var reply in replys)
                {
                    reply.member.avatar_mini = "http:" + reply.member.avatar_mini;
                    reply.member.avatar_normal = "http:" + reply.member.avatar_normal;
                    reply.member.avatar_large = "http:" + reply.member.avatar_large;
                    replysList.Add(reply);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //取用户信息
        public static async Task GetUserInfoAsync(UserObject userinfo,string name)
        {
            try
            {
                var user = await getUserInfo(name);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //根据节点名称取节点内容
        public static async Task GetNodeByUsernameAsync(ObservableCollection<ThemeObject> nodetopicList,string nodename)
        {
            try
            {
                var alltopics = await GetNodeTpoics(nodename);
                foreach (var topic in alltopics)
                {
                    topic.member.avatar_mini = "http:" + topic.member.avatar_mini;
                    topic.member.avatar_normal = "http:" + topic.member.avatar_normal;
                    topic.member.avatar_large = "http:" + topic.member.avatar_large;
                    nodetopicList.Add(topic);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //根据节点名称取主题
        public async static Task<ObservableCollection<ThemeObject>> GetNodeTpoics(string nodename)
        {
            var http = new HttpClient();
            var url = string.Format("https://www.v2ex.com/api/topics/show.json?node_name={0}", nodename);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ObservableCollection<ThemeObject>>(result);

            return data;
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
        public async static Task<ObservableCollection<ReplyObject>> GetReply(int id)
        {
            var http = new HttpClient();
            var url = string.Format("https://www.v2ex.com/api/replies/show.json?topic_id={0}", id);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ObservableCollection<ReplyObject>>(result);

            return data;
        }


        //取主题信息
        public async static Task<ObservableCollection<ThemeObject>> GetTopics(int id)
        {
            var http = new HttpClient();
            var url = string.Format("https://www.v2ex.com/api/topics/show.json?id={0}", id);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<ObservableCollection<ThemeObject>>(result);

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
