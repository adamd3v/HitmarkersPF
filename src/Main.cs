using MelonLoader;

using UnityEngine;

using NEP.Hitmarkers.Data;

namespace NEP.Hitmarkers
{
    public static class BuildInfo
    {
        public const string Name = "Hitmarkers"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Simple hitmarkers mod."; // Description for the Mod.  (Set as null if none)
        public const string Author = "Not Enough Photons"; // Author of the Mod.  (MUST BE SET)
        public const string Company = "Not Enough Photons"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "2.10.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = "https://thunderstore.io/c/bonelab/p/NotEnoughPhotons/Hitmarkers/"; // Download Link for the Mod.  (Set as null if none)
    }
    
    public class Main : MelonMod
    {
        public static MelonLogger.Instance Logger;

        public override void OnInitializeMelon()
        {
            Logger = new MelonLogger.Instance("Hitmarkers");

            UnityExplorer.ExplorerStandalone.CreateInstance();

            DataManager.Initialize();
        }

        public void OnGameStart()
        {
        }
    }
}