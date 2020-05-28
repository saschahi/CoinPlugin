using IL.Terraria;
using ProjectT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinPlugin
{
    public static class CoinAdder
    {
        public static CoinGainConfig Config = new CoinGainConfig();
        public static void Bithandler(Viewer viewer, int bits)
        {
            if (Config.CoinsPerBits > 0)
            {
                double coins = bits * Config.CoinsPerBits;
                if (Config.globalBits)
                {
                    foreach (var item in Viewermanager.getCurrentViewers())
                    {
                        Calls.addcoins(viewer, coins);
                    }
                }
                Calls.addcoins(viewer, coins);
            }
        }

        public static void Subhandler(Viewer viewer, string tier)
        {
            double coins = 0;
            switch(tier)
            {
                case "Prime":
                    coins = Config.CoinsPerPrime;
                    break;

                case "Tier1":
                    coins = Config.CoinsPerT1;
                    break;

                case "Tier2":
                    coins = Config.CoinsPerT2;
                    break;

                case "Tier3":
                    coins = Config.CoinsPerT3;
                    break;

                default:
                    coins = 0;
                    break;
            }
            if(coins > 0)
            {
                if(Config.globalSubs)
                {
                    foreach(var item in Viewermanager.getCurrentViewers())
                    {
                        Calls.addcoins(item, coins);
                    }
                }
                Calls.addcoins(viewer, coins);
            }
        }

    }
}
