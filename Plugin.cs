using BepInEx;
using HarmonyLib;

namespace FP2Rebalance
{
    [BepInPlugin("com.micg.plugins.fp2.classic", "FP2Classic", "1.0.0")]
    [BepInProcess("FP2.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public static Harmony HarmonyLink { get; } = new Harmony("com.micg.plugins.fp2.classic");

        private void Awake()
        {
            HarmonyLink.PatchAll(typeof(Start));
        }

        // General
        [HarmonyPatch(typeof(MenuMain), "Start")]
        public class Start
        {
            private static byte savedValue = FPSaveManager.badges[0];

            static void Prefix()
            {
                FPSaveManager.badges[0] = 1;
            }

            static void Postfix()
            {
                FPSaveManager.badges[0] = savedValue;
            }
        }
    }
}