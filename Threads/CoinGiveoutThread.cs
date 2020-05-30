using ProjectT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoinPlugin
{
    class CoinGiveoutThread
    {
        public CoinGiveoutThread()
        {

        }

        public static bool isConnected = false;
        public static bool sendmessage = false;

        public void Initialize()
        {
            DateTime lastgiveout = DateTime.UtcNow;
            wait: Thread.Sleep(10000);
            if (isConnected)
            {
                if(CoinAdder.Config != null)
                {
                    sendmessage = CoinAdder.Config.sendMessage;
                }
                if (lastgiveout.AddMinutes(CoinAdder.Config.MinutesToCoins) < DateTime.UtcNow)
                {
                    lastgiveout = DateTime.UtcNow;
                    foreach (var item in Viewermanager.getCurrentViewers())
                    {
                        Calls.addcoins(item, CoinAdder.Config.CoinsPerMinute);
                    }
                    if (sendmessage)
                    {
                        Calls.sendmessage("successfully sent " + CoinAdder.Config.CoinsPerMinute + " coins out");
                    }
                }
            }
            if (ThreadWorker.runThread)
                goto wait;
        }
    }
}
