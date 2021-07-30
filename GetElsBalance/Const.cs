using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetElsBalance
{
    class Const
    {
        public struct APP
        {
            public const string VERSION = "0.01";
        }

        public struct URL
        {
            public const string CONTENT_TYPE = "application/x-www-form-urlencoded";
            public const string USER_AGENT = "Mozilla/4.0 (compatible; Win32; WinHttp.WinHttpRequest.5)";

            public static string FTS_HOST = "edata.customs.ru";

            public static string FTS_SERVER = "https://edata.customs.ru";
            public static string FTS_AUTH = "/FtsPersonalCabinetWeb2017/Service/AuthenticateUserName";
            public static string FTS_BALANCE = "/FtsPersonalCabinetWeb2017/UniversalDatabase/GetScalar?scopeName=FtsDataSets&scalarName=ELSBalanceSUMREST";
            public static string FTS_BALANCE_DETAIL = "/FtsPersonalCabinetWeb2017/UniversalDatabase/GetItems?scopeName=FtsDataSets&listName=DataSetAccountBalance&format=JSON&start=0";

            public readonly static string AUTH_DATA = "userName={0}&password={1}";

            public readonly static string AUTH_OK = "\"IsAuthenticated\":true";

        }

        public struct AUTH
        {
            public static string NAME = "test";
            public static string PASSWORD = "test"; 
        }
    }
}
