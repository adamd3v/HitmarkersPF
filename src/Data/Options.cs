using MelonLoader;

namespace NEP.Hitmarkers.Data
{
    public static class Options
    {
        public static string FavoriteSkin { get; private set; }
        public static bool EnableHitmarkers { get; private set; } = true;
        public static float HitmarkerSFX { get; private set; }
        public static float HitmarkerPitch { get; private set; }
    }
}