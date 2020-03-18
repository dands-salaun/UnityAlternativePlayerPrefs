using System.Diagnostics;
using UnityEditor;
using UnityEngine;

namespace Dands.APlayerPrefs
{
    public class APlayerPrefsEditor : Editor
    {
        [MenuItem("Dands/APlayerPrefs/Clear")]
        public static void ClearData()
        {
            APlayerPrefs.ClearData();
        }

        [MenuItem("Dands/APlayerPrefs/Open save location")]
        public static void OpenSaveLocation()
        {
            Process.Start(Application.persistentDataPath);
        }
    }
}