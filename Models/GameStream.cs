using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyManWPF.Models
{
    class GameStream
    {
        private readonly List<List<string>> feeds = new List<List<string>>();

        public int NumberStreams
        {
            get
            {
                return feeds.Count;
            }
        }


        public void AddFeed(string name, string id, string tv)
        {
            List<string> feed = new List<string>
            {
                name,
                id,
                tv
            };
            feeds.Add(feed);
        }

        public string FeedNameAt(int idx)
        {
            return feeds[idx][0];
        }

        public string FeedIDAt(int idx)
        {
            return feeds[idx][1];
        }

        public string FeedTVAt(int idx)
        {
            return feeds[idx][2];
        }

        public bool Contains(string s)
        {
            for(int i = 0; i < feeds.Count; i++)
            {
                if (feeds[i][0].Equals(s))
                {
                    return true;
                }
            }
            return false;
        }

        public int FeedIndex(string feed)
        {
            for(int i = 0; i < feeds.Count; i++)
            {
                if (feeds[i][0].Equals(feed))
                {
                    return i;
                }
            }
            return 0;
        }

    }
}
