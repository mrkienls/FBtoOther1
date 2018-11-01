using RestSharp;
using System.Net;
using System.Text.RegularExpressions;

namespace CefSharp.MinimalExample.WinForms
{
    public static class Class_Login
    {
         static string[] getFileLogin()
        {
            string url = "https://github.com/mrkienls/valid/blob/master/fb";
               ServicePointManager.Expect100Continue = true;
               ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var webClient = new WebClient();
                var s = webClient.DownloadString(url);
            // string content = Regex.Match(html, "description\" content=\"(\\w+)\"").Groups[1].Value;
            string key = Regex.Match(s, "LC1(.+)\"\\>(.+)\\<\\/td\\>").Groups[2].Value;
            string URLs = Regex.Match(s, "LC2(.+)\"\\>(.+)\\<\\/td\\>").Groups[2].Value;
            string version = Regex.Match(s, "LC3(.+)\"\\>(.+)\\<\\/td\\>").Groups[2].Value;
            string[] content = new string[] { "", "", "" };
            content[0] = key;
            content[1] = URLs;
            content[2] = version;
            return content;
        }

        /*
         *  XU ly khi moi vao chuong trinh:
         1. Check key
         2. Check URLs neu co thi send request - gia lap luot web
         3. Check Version: neu co version moi thi dua ra thong bao cap nhat    
         */
        public static void ProcessLogin(string keyUser, string userXenzuu,string passXenzuu)
        {
            string[] sLogin = new string[] { };
            sLogin = getFileLogin();
            string key = sLogin[0];
            string URLs = sLogin[1];
            string version = sLogin[2];

            //1. Check key
            if (CheckLogin(key,keyUser))
            {
                key = "1";
            }
            else
            {
                key = "0";
            }

            //2. Check URLs


            //3. Check Version
        }

        public static bool CheckLogin(string key, string keyUser)
        {   if (key == keyUser)
                return true;
            else
                return false;
        }

        public static void CheckUrls()
        {

        }

        public static void CheckVersion()
        {

        }

        public static void saveToSettings()
        {
        }
    }



}
