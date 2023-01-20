using BepInEx;
using HarmonyLib;

namespace FP2Rebalance
{
    [BepInPlugin("com.micg.plugins.fp2.classic", "FP2Classic", "1.0.1")]
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
                ResetBadgeValue(1);
            }

            static void Postfix()
            {
                ResetBadgeValue(savedValue);
            }

            static void ResetBadgeValue(byte value)
            {
                if (FPSaveManager.badges[63] == 0 && !FPSaveManager.demoMode)
                {
                    FPSaveManager.badges[0] = value;
                }
            }
        }
    }
}