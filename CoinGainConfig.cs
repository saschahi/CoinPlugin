using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CoinPlugin
{
    public class CoinGainConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Coins per giveout")]
        [Tooltip("Here you decide how many Coins should automatically be given out")]
        [Range(0, 9999999)]
        [DefaultValue(0)]
        public int CoinsPerMinute { get; set; }

        [Label("Giveout delay in Minutes")]
        [Tooltip("Here you decide the delay between automatic Coin-Giveouts")]
        [Slider]
        [Range(1,30)]
        [DefaultValue(5)]
        public int MinutesToCoins { get; set; }

        [Label("Bits Party Mode")]
        [Tooltip("If true, every current Viewer will the coins configured below and the donater gets double")]
        [DefaultValue(false)]
        public bool globalBits { get; set; }

        [Label("Coins per Bit")]
        [Tooltip("0 to disable")]
        [Range(0, 9999999)]
        [DefaultValue(0)]
        public int CoinsPerBits { get; set; }

        [Label("Sub Party Mode")]
        [Tooltip("If true, every current Viewer will the coins configured below and the sub gets double")]
        [DefaultValue(false)]
        public bool globalSubs { get; set; }

        [Label("Coins per Prime Sub")]
        [Tooltip("0 to disable")]
        [Range(0, 9999999)]
        [DefaultValue(0)]
        public int CoinsPerPrime { get; set; }

        [Label("Coins per Tier 1 Sub")]
        [Tooltip("0 to disable")]
        [Range(0, 9999999)]
        [DefaultValue(0)]
        public int CoinsPerT1 { get; set; }

        [Label("Coins per Tier 2 Sub")]
        [Tooltip("0 to disable")]
        [Range(0, 9999999)]
        [DefaultValue(0)]
        public int CoinsPerT2 { get; set; }

        [Label("Coins per Tier 3 Sub")]
        [Tooltip("0 to disable")]
        [Range(0, 9999999)]
        [DefaultValue(0)]
        public int CoinsPerT3 { get; set; }

        public override void OnLoaded()
        {
            CoinAdder.Config = ModContent.GetInstance<CoinGainConfig>();
        }
        public override void OnChanged()
        {
            CoinAdder.Config = ModContent.GetInstance<CoinGainConfig>();
        }
    }
}
