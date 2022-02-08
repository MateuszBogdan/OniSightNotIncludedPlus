using HarmonyLib;
using KMod;
using PeterHan.PLib.Core;
using PeterHan.PLib.Database;
using PeterHan.PLib.Options;

namespace SightNotIncluded
{
    public class SightNotIncludedMod: UserMod2
    {
        public override void OnLoad(Harmony harmony)
        {
            base.OnLoad(harmony);
            PUtil.InitLibrary();
            new PLocalization().Register();
            var options = new POptions();
            options.RegisterOptions(this, typeof(SightNotIncludedConfig));
        }

        [HarmonyPatch(typeof(GridVisibility), "OnSpawn")]
        public static class GridVisibility_OnSpawn
        {
            public static void Prefix(GridVisibility __instance)
            {
                var config = POptions.ReadSettings<SightNotIncludedConfig>() ?? new SightNotIncludedConfig();

                (int radius, float innerRadius) = config.SightRange switch
                {
                    DuplicantSightRange.Minimal => (5, 3.5f),
                    DuplicantSightRange.Small => (8, 6.0f),
                    DuplicantSightRange.Medium => (12, 10.0f),
                    DuplicantSightRange.AlmostOriginal => (15, 12.5f),
                    _ => (18, 16.5f)
                };
                
                __instance.radius = radius;
                __instance.innerRadius = innerRadius;
            }
        }

    }
}