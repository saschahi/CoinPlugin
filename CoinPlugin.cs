using ProjectT;
using System.Collections.Generic;
using System.Threading;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace CoinPlugin
{
	public class CoinPlugin : Mod
	{
	    static TwitchInput input = new TwitchInput();
		public static Mod ProjectT;

		public override void Load()
		{
			ProjectT = ModLoader.GetMod("ProjectT");
			input = new TwitchInput();
			ThreadWorker.runThread = true;
			ThreadWorker.StartThread();
		}

		public override void Unload()
		{
			ThreadWorker.runThread = false;
			ProjectT = null;
			input = null;
		}
		public override void PostAddRecipes()
		{
			CoinAdder.Config = ModContent.GetInstance<CoinGainConfig>();
		}

		/*public static List<Viewer> getViewerList()
		{
			return input.locallist;
		}*/
	}
}