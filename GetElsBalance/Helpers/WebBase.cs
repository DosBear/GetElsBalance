using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace GetElsBalance
{
    static class WebBase
    {
        public static HttpWebRequest RequestPost(string url, string[][] requestHeaders, string data, string[][] cookies)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = Const.URL.CONTENT_TYPE;
            request.UserAgent = Const.URL.USER_AGENT;
            request.Method = "POST";
            request.KeepAlive = false;
            if (cookies != null) request.CookieContainer = new CookieContainer();
            foreach (string[] cookie in cookies)
            {
                request.CookieContainer.Add(new Cookie(cookie[0], cookie[1], "", Const.URL.FTS_HOST));
            }
            foreach (string[] headerPair in requestHeaders)
            {
                request.Headers.Add(headerPair[0], headerPair[1]);
            }


            if (data != null)
            {
                try
                {
                    byte[] postData = Encoding.UTF8.GetBytes(data);
                    request.ContentLength = postData.Length;
                    using (var requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(postData, 0, postData.Length);
                    }
                }
                catch (Exception err)
                {

                    "Ошибка получения данных {0}".ShowError(err.Message);
                }
            }
            return request;
        }
    }
}
