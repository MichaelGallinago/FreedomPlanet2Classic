using System.Reflection;

namespace FP2Rebalance
{
    public class Patcher
    {
        public static FieldInfo GetPlayerField(string name) => typeof(FPPlayer).GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);

        public static void SetPlayerValue(string name, object value, object player = null) => GetPlayerField(name).SetValue(player, value);

        public static object GetPlayerValue(string name, object player = null) => GetPlayerField(name).GetValue(player);

        public static FPPlayer GetPlayer => FPStage.currentStage.GetPlayerInstance_FPPlayer();
    }
}
