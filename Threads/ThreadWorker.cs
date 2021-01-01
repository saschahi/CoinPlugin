using System.Collections.Generic;
using System.Threading;

namespace CoinPlugin
{
    public static class ThreadWorker
    {
        public static bool runThread = true;
        public static bool stayConnected = true;
        public static bool sendDebugMSG = false;
        public static bool complete;
        static List<Thread> threads = new List<Thread>();

        public static void StartThread()
        {
            if (!runThread) return;

            if (threads.Count > 0)
            {
                foreach (Thread thread in threads)
                {
                    thread.Abort();
                    if (!thread.IsAlive)
                    {
                        threads = threads.FindAll((s) => s != thread);
                    }
                }
            }


            Thread clientThread = new Thread((wrapper) => new CoinGiveoutThread().Initialize())
            {
                Name = "Project-T Coingiveout Thread",
                IsBackground = true
            };

            threads.Add(clientThread);

            clientThread.Start();
        }
    }
}