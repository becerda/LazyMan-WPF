using LazyManWPF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LazyManWPF.Objects
{
    class Web
    {

        static readonly HttpClient client = new HttpClient();

        public static string GetContent(string url)
        {
            string c = "";

            try
            {
                WebClient wc = new WebClient();
                c = wc.DownloadString(url);
            }
            catch(Exception e)
            {
                MessageBox.Show("Exception Caught in Web.GetContent(" + url + "): " + e.Message, "HttpRequestExeption Caught", MessageBoxButton.OK);
                Environment.Exit(-1);
            }

            return c;
        }

        public static Boolean testURL(string url)
        {
            Uri uri;
            return Uri.TryCreate(url, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }

        public static bool testM3U8(string url)
        {
            HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(url);
            hwr.Method = "HEAD";
            hwr.UserAgent = "Mozilla/5.0 Gecko Firefox";
            CookieContainer cc = new CookieContainer();
            cc.SetCookies(new Uri(url), "mediaAuth=\"" + Encryption.GetSaltString() + "\"");
            hwr.CookieContainer = cc;
            HttpWebResponse response = (HttpWebResponse)hwr.GetResponse();

            return response.StatusCode == HttpStatusCode.OK;
        }

    }
}
