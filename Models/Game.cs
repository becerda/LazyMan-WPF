using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyManWPF.Models
{
    class Game : GameStream
    {
        public string Home { get; set; }
        public string Away { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string GameState { get; set; }
        public string TimeRemaining { get; set; }
        public string AwayFull { get; set; }
        public string HomeFull { get; set; }
        public string ActualStart { get; set; }
        public int Id { get; set; }
    }
}
