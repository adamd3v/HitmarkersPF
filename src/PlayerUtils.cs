using UnityEngine;

namespace NEP.Hitmarkers
{
    public static class PlayerUtils
    {
        public static GameObject Player => PlayerLook.Instance._playerCam.gameObject;
    }
}
