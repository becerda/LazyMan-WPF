using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyManWPF.Models
{

    class GameWatchInfo
    {
        public string CDN { get; set; }
        public string Quality { get; set; }
        public string URL { get; set; }
        public string date { get; set; }

        public GameWatchInfo(string cdn, string quality, string date, string mediaID)
        {
            CDN = cdn;
            Quality = quality;
            string m3u8URL = "nhl.freegamez.ga";
            /*try
            {
                
            }catch ()*/
        }
    }
}
