using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V2EX.UWP.Core.Models;
using V2EX.UWP.Core.Tools;
using Windows.Data.Json;

namespace V2EX.UWP.Core.Https
{
    /// <summary>
    /// API服务类 将接收到json字符串格式化成实体类
    /// </summary>
    public class APIService:APIBaseService
    {
        private string _local_path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;

        /// <summary>
        /// 最新主题列表
        /// </summary>
        /// 
        public async Task<List<Subject>> GetLatest()
        {
            try
            {
                if (NetworkManager.Current.Network == 4)  //无网络连接
                {
                    List<Subject> list = await FileHelper.Current.ReadObjectAsync<List<Subject>>("subject.json");
                    return list;
                }
                else
                {
                    JsonObject json = await GetJson(ServiceURL.Latest);
                    if (json != null)
                    {
                        List<Subject> list = new List<Subject>();
                        JsonArray ja = json.GetArray();
                        foreach (var item in ja)
                        {
                            list.Add(new Subject {
                                ID = (item.GetObject())["id"].GetNumber().ToString(),
                                Title = (item.GetObject())["title"].GetString(),
                                Url = (item.GetObject())["url"].GetString(),
                                Content = (item.GetObject())["content"].GetString(),
                                Content_rendered = (item.GetObject())["content_rendered"].GetString(),
                                Replies = (item.GetObject())["replies"].GetString(),
                                Member_id = ((item.GetObject())["member"].GetObject())["id"].GetNumber().ToString(),
                                Node_id = ((item.GetObject())["node"].GetObject())["id"].GetNumber().ToString(),
                                Created = (item.GetObject())["created"].GetString(),
                                Last_Modified = (item.GetObject())["last_modified"].GetString(),
                                Last_touched = (item.GetObject())["last_touched"].GetString()
                            });
                        }
                        await FileHelper.Current.WriteObjectAsync<List<Subject>>(list, "subject.json");
                        return list;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
