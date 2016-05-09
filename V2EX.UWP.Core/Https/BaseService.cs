using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;

namespace V2EX.UWP.Core.Https
{
    /// <summary>
    /// 访问HTTP服务器基础服务
    /// </summary>
    static class BaseService
    {
        /// <summary>
        /// 向服务器发送GET请求 返回服务器回复数据(string)
        /// </summary>
        public async static Task<string> SendGetRequest(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uri = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 向服务发送GET请求 返回服务器回复数据（bytes)
        /// </summary>
        ///
        public async static Task<IBuffer> SendGetRequestAsBytes(String url)
        {
            try
            {
                HttpClient client = new HttpClient();
                Uri uri = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsBufferAsync();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        } 

        /// <summary>
        /// 向服务器发送POST请求 返回服务器回复数据(string)
        /// </summary>
        /// 
        public async static Task<string> SendPostRequest(string url,string body)
        {
            try
            {
                HttpRequestMessage mSent = new HttpRequestMessage(HttpMethod.Post,new Uri(url));
                mSent.Content = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json; charset=utf-8");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.SendRequestAsync(mSent);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }   
}
