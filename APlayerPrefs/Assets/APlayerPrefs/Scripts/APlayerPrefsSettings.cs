using Dands.Utils.Singleton;
using UnityEngine;

public class APlayerPrefsSettings : ScriptableSingleton<APlayerPrefsSettings>
{
    [Header("Path")]
    [SerializeField] private string saveFileName = "playerPrefs";
    
    [Header("Auto Save")]
    [SerializeField] protected bool autoSave = true;
    private float timeToAutoSave = 1f;

    public bool GetAutoSave()
    {
        return autoSave;
    }

    public float GetTimeToAutoSave()
    {
        return timeToAutoSave;
    }

    public void SetTimeAutoSave(float time)
    {
        timeToAutoSave = time;
    }

    public string GetNameFile()
    {
        return saveFileName;
    }
}
