using System.Diagnostics;
using UnityEditor;
using UnityEngine;

namespace Dands.APlayerPrefs
{
    public class APlayerPrefsEditor : Editor
    {
        [MenuItem("APlayerPrefs/Clear")]
        public static void ClearData()
        {
            APlayerPrefs.DeleteAll();
        }

        [MenuItem("APlayerPrefs/Open save location")]
        public static void OpenSaveLocation()
        {
            Process.Start(Application.persistentDataPath);
        }
    }
}