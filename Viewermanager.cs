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
        public static int inactivitytimer = 15;

        public static List<Viewer> getCurrentViewers()
        {
            if(CoinAdder.Config != null)
            {
                inactivitytimer = CoinAdder.Config.inactivitytimer;
            }
            List<Viewer> viewer = TwitchInput.locallist;
            List<Viewer> mem = new List<Viewer>();
            foreach(var item in viewer)
            {
                if(item.last_seen.AddMinutes(inactivitytimer) > DateTime.UtcNow)
                {
                    mem.Add(item);
                }
            }
            return mem;
        }


    }
}
