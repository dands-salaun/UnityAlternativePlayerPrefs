using System.IO;
using UnityEditor;
using UnityEngine;

namespace Dands.Utils.Singleton
{
    public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableSingleton<T>
    {
        private static T i;

        public static T Instance
        {
            get
            {
                if (i == null)
                {
                    T[] assets = Resources.LoadAll<T>("");

                    if (assets == null || assets.Length < 1)
                    {
                        i = CreateInstance<T>();

                        string path = "Assets/Resources/";
                        string fileName = typeof(T) + ".asset";

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

#if UNITY_EDITOR
                        AssetDatabase.CreateAsset(i, Path.Combine(path, fileName));
                        AssetDatabase.SaveAssets();
                        AssetDatabase.Refresh();
#endif
                    }
                    else
                    {
                        i = assets[0];
                    }
                }

                return i;
            }
        }
    }
}