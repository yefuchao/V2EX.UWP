using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace V2EX.UWP.Core.Https
{
    /// <summary>
    /// API服务基类
    /// </summary>
    public class APIBaseService
    {
        private void Printlog(string info)
        {
#if DEBUG   
            Debug.WriteLine(DateTime.Now.ToString() + "" + info);
#endif
        }

        protected async Task<JsonObject> GetJson(string url)
        {
            try
            {
                string json = await BaseService.SendGetRequest(url);
                if (json != null)
                {
                    Printlog("请求数据成功 URL：" + url);
                    return JsonObject.Parse(json);
                }
                else
                {
                    Printlog("请求Json数据失败 URL：" + url);
                    return null;
                }
            }
            catch (Exception)
            {
                Printlog("请求Json数据失败 URL：" + url);
                return null;
            }
        }


    }
}
