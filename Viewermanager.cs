using ProjectT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinPlugin
{
    public static class Viewermanager
    {
        public static List<Viewer> getCurrentViewers()
        {
            List<Viewer> viewer = TwitchInput.locallist;
            List<Viewer> mem = new List<Viewer>();
            foreach(var item in viewer)
            {
                if(item.last_seen.AddMinutes(15) > DateTime.UtcNow)
                {
                    mem.Add(item);
                }
            }
            return mem;
        }
    }
}
