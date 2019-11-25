using LazyManWPF.Objects;
using LazyManWPF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyManWPF.Models
{

    class GameWatchInfo
    {
        private string url;

        public string CDN { get; set; }
        public string Quality { get; set; }
        public string URL 
        { 
            get 
            {
                if (url.Contains("exp="))
                {
                    int exploc = url.IndexOf("exp=");
                    long expires = Int32.Parse(url.Substring(exploc + 4, url.IndexOf("~", exploc)));

                    DateTime baseDate = new DateTime(1970, 1, 1);
                    long k = baseDate.Ticks;
                    
                    if (expires < k / 1000)
                    {
                        return "n/a";
                    }
                }
                return url;
            }

            set
            {
                url = value;
            }
        }
        public string Date { get; set; }
        public string MediaID { get; set; }


        public GameWatchInfo() { }

        public GameWatchInfo(string cdn, string quality, string date, string mediaID)
        {
            CDN = cdn;
            Quality = quality;
            Date = date;
            MediaID = mediaID;

            GetContent();
        }

        private void GetContent()
        {
            string m3u8URL = "nhl.freegamez.ga";

            if (!Props.IP.Equals(""))
            {
                m3u8URL = Props.IP;
            }
            URL =  Web.GetContent("http://" + m3u8URL + "/m3u8/" + Date + "/" + MediaID + CDN);
        }

        public bool SetURL(string mediaID, String league)
        {
            string m3u8URL = "nhl.freegamez.ga";
            MediaID = mediaID;
            if (!Props.IP.Equals(""))
            {
                m3u8URL = Props.IP;
            }
            /*if (league.Equals("NHL"))
            {
                if (DateTime.Today != Convert.ToDateTime(Date))
                {
                    if(Web.testURL("http://"+ m3u8URL + "/m3u8/" + Date + "/" + MediaID + "akc"))
                    {
                        try
                        {
                            URL =  Web.GetContent("http://" + m3u8URL + "/m3u8/" + Date + "/" + MediaID + "akc");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            URL = Web.GetContent("http://" + m3u8URL + "/m3u8/" + Date + "/" + MediaID);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                else
                {
                    try
                    {
                        URL = Web.GetContent("http://" + m3u8URL + "/m3u8/" + Date + "/" + mediaID + CDN);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            else
            {
                if (DateTime.Today != Convert.ToDateTime(Date))
                {
                    if (Web.testURL("http://" + m3u8URL + "/mlb/m3u8/" + Date + "/" + MediaID + "akc"))
                    {
                        try
                        {
                            url = Web.GetContent("http://" + m3u8URL + "/mlb/m3u8/" + Date + "/" + mediaID + "akc");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                else
                {
                    try
                    {
                        url = Web.GetContent("http://" + m3u8URL + "/mlb/m3u8/" + Date + "/" + mediaID + CDN);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

            }*/

            if(DateTime.Today != Convert.ToDateTime(Date))
            {
                try
                {
                    URL = Web.GetContent("http://" + m3u8URL + "/getM3U8.php?league=" + league + "&date=" + Date + "&id=" + mediaID + "&cdn=akc");
                    // TODO - log
                    //System.out.println("http://" + m3u8URL + "/getM3U8.php?league=" + league + "&date=" + Date + "&id=" + mediaID + "&cdn=akc"); 
                    return !URL.Contains("Not");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                try
                {
                    URL = Web.GetContent("http://" + m3u8URL + "/getM3U8.php?league=" + league + "&date=" + Date + "&id=" + mediaID + "&cdn=" + CDN);
                    return !URL.Contains("Not");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }
    }
}
