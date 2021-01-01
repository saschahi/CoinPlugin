using System.Collections.Generic;
using ProjectT;

namespace CoinPlugin
{
    class TwitchInput : TwitchHandler
    {
        //this works just like modding for tModLoader normally

        public override void MessageHandler(Viewer viewer, string message, int bits)
        {
            CoinAdder.Bithandler(viewer, bits);
        }

        static public List<Viewer> locallist = new List<Viewer>();

        public override void onViewerListUpdate(List<Viewer> ListOfAllViewers)
        {
            locallist = ListOfAllViewers;
        }

        public override void onCommunitySubscription(Viewer viewer, string tier)
        {
            //I'm not actually sure what this is yet. If you figure it out tell me.
        }

        public override void onBeingHosted(string Hoster, int AmountofViewers)
        {
            //BEWARE. this only gets the name of the hoster. NOT AN INSTANCE OF A VIEWER. 
            //A Viewer will be created once the hoster writes in chat like everyone else.

            //name says it all
        }

        public override void onConnected()
        {
            //gets called when the Bot Connects to Twitch
            CoinGiveoutThread.isConnected = true;
        }

        public override void onConnectionError()
        {
            //name says it all
            CoinGiveoutThread.isConnected = false;
        }

        public override void onDisconnected()
        {
            //Gets called when the Bot Disconnects from twitch
            CoinGiveoutThread.isConnected = false;
        }

        public override void onGiftedSubscription(Viewer viewer, string tier)
        {
            CoinAdder.Subhandler(viewer, tier);
        }

        public override void onIncorrectLogin()
        {
            //gets called when the bot can't connect with the Twitch chat due to wrong Login credentials (botname + oauth code)
        }

        public override void onNewSubscriber(Viewer viewer, string tier)
        {
            CoinAdder.Subhandler(viewer, tier);
        }


        public override void onReSubscriber(Viewer viewer, string tier)
        {
            CoinAdder.Subhandler(viewer, tier);
        }

        public override void WhisperMessageHandler(Viewer viewer, string message)
        {
            //gets called when the bot gets whispered to
        }
    }
}
