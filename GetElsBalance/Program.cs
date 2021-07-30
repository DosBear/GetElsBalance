using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace GetElsBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            "GetElsBalance {0}".ShowText(Const.APP.VERSION);

            "Подключение к ".ShowKeyWalue(Const.URL.FTS_SERVER, ConsoleColor.Green);

            var auth_sessget = WebBase.RequestPost(Const.URL.FTS_SERVER + Const.URL.FTS_AUTH, new string[][] { },
                                            Const.URL.AUTH_DATA.FormatWith(Const.AUTH.NAME, Const.AUTH.PASSWORD),
                                            new string[][] { });

            string tmp, respData, FtsCabinetCookie = "";
            using (HttpWebResponse webResponse = (HttpWebResponse)auth_sessget.GetResponse())
            {
                if (webResponse.Headers.Get("Set-Cookie") != null)
                {
                    tmp = webResponse.Headers.Get("Set-Cookie").Trim();
                    FtsCabinetCookie = tmp.Split(';')[0];
                    respData = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                    if (respData.IndexOf(Const.URL.AUTH_OK) >= 0)
                    {
                        "Авторизация - ".ShowKeyWalue("OK", ConsoleColor.Green);
                    }
                    else
                    {
                        "Авторизация - ".ShowKeyWalue("НЕТ", ConsoleColor.Red);
                        return;
                    }
                }
            }


            var balans_get = WebBase.RequestPost(Const.URL.FTS_SERVER + Const.URL.FTS_BALANCE, new string[][] { }, "",   
                                            new string[][] {
                                                   new string[]{FtsCabinetCookie.Split('=')[0], FtsCabinetCookie.Split('=')[1]}
                                            });
            using (HttpWebResponse webResponse = (HttpWebResponse)balans_get.GetResponse())
            {
                respData = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
               "Текущий баланс - ".ShowKeyWalue(respData, ConsoleColor.Yellow);      
            }

            var detail_get = WebBase.RequestPost(Const.URL.FTS_SERVER + Const.URL.FTS_BALANCE_DETAIL, new string[][] { }, "",
                                           new string[][] {
                                                   new string[]{FtsCabinetCookie.Split('=')[0], FtsCabinetCookie.Split('=')[1]}
                                            });


            Regex kbk_rgx = new Regex("\"SINCSTRUCT\":\"[\\d]*\"");
            Regex sum_rgx = new Regex("\"NSUMFULL\":[\\d.]*");

            using (HttpWebResponse webResponse = (HttpWebResponse)detail_get.GetResponse())
            {
                respData = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();
                var cl1 = kbk_rgx.Matches(respData);
                var cl2 = sum_rgx.Matches(respData);
                for (int i = 0; i < cl1.Count; i++)
                {
                    "КБК {0} - ".FormatWith(cl1[i].Value.Split(':')[1].Replace("\"", "")).ShowKeyWalue(cl2[i].Value.Split(':')[1] + " р.", ConsoleColor.Green);
                }
            }

            Console.ReadKey();

        }
    }
}
