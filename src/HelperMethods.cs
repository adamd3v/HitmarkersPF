using System.IO;
using System.Reflection;
using System.Linq;
using UnityEngine;

namespace NEP.Hitmarkers
{
    internal static class HelperMethods
    {
        /// <summary>
        /// Loads an embedded assetbundle
        /// </summary>
        public static AssetBundle LoadEmbeddedAssetBundle(Assembly assembly, string name)
        {
            string[] manifestResources = assembly.GetManifestResourceNames();
            AssetBundle bundle = null;

            if (manifestResources.Contains(name))
            {
                using (Stream str = assembly.GetManifestResourceStream(name))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        str.CopyTo(memoryStream);
                        byte[] resource = memoryStream.ToArray();

                        bundle = AssetBundle.LoadFromMemory(resource);
                    }
                }
            }

            return bundle;
        }
    }
}
