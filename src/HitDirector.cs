using System.Reflection;

using UnityEngine;

namespace NEP.Hitmarkers
{
    public static class HitDirector
    {
        public static System.Action<HitData> OnHit;

        public static void Initialize()
        {
            // OnHit += OnProjectileHit;
        }

        public static bool EvaluateHit(HitData data)
        {
            var hitObject = data.collider.gameObject;

            bool hitEnemy = hitObject.tag == "EnemyHitbox";

            if (hitEnemy)
            {
                return true;
            }

            bool hitProxy = hitObject.GetComponent<HitmarkerProxy>();

            if (hitProxy)
            {
                return true;
            }

            return false;
        }

        public static void OnProjectileHit(HitData data)
        {
            if (EvaluateHit(data))
            {
                HitmarkerManager.SpawnMarker(data.worldHit);
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(Hitbox))]
        [HarmonyLib.HarmonyPatch(nameof(Hitbox.TakeDamage))]
        public static class HitboxTakeDamagePatch
        {
            public static bool Prefix(Hitbox __instance, float damage, float force, Vector3 forward, Transform damageDealer)
            {
                if (__instance._entityManager == null)
                    return true;

                if (__instance._entityManager._entityIsDead)
                    return true;

                HitmarkerManager.SpawnMarker(__instance.transform.position);
                return true;
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(EntityManager))]
        [HarmonyLib.HarmonyPatch(nameof(EntityManager.KillEntity))]
        public static class HitboxOnDeathPatch
        {
            public static void Postfix(EntityManager __instance)
            {
                HitmarkerManager.SpawnMarker(__instance._entityHips.position + Vector3.up * 0.15f, true);
            }
        }

        [HarmonyLib.HarmonyPatch(typeof(PlayerController))]
        [HarmonyLib.HarmonyPatch("Awake")]
        public static class OnPlayerAwake
        {
            public static void Postfix()
            {
                HitmarkerManager.Initialize();
                HitDirector.Initialize();
            }
        }
    }
}
