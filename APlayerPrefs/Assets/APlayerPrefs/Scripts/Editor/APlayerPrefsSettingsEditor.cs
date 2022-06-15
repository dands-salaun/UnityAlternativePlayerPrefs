using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(APlayerPrefsSettings))]
public class APlayerPrefsSettingsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        APlayerPrefsSettings settings = (APlayerPrefsSettings) target;
        
        base.OnInspectorGUI();

        if (settings.GetAutoSave())
        {
            EditorGUILayout.BeginHorizontal();
            //EditorGUILayout.LabelField("Time to auto save", GUILayout.Width(118), GUILayout.ExpandWidth(true));
            GUILayout.Label("Time to auto save", GUILayout.ExpandWidth(true));
            settings.SetTimeAutoSave(EditorGUILayout.FloatField(settings.GetTimeToAutoSave()));;
            EditorGUILayout.EndHorizontal();
        }
        
        serializedObject.Update();
    }
    
    [MenuItem("APlayerPrefs/Settings", priority = 0)]
    public static void OpenSettings()
    {
        Selection.activeObject = APlayerPrefsSettings.Instance;
    }
}
