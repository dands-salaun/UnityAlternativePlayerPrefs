using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace Dands.APlayerPrefs
{
    public static class SaveSystem
    {
        public static void Save<T>(T data, string path)
        {
            var savePath = Path.Combine(Application.persistentDataPath, path);
            //string json = JsonUtility.ToJson(data);
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(savePath, json);
            Debug.Log("File saved");
        }

        public static T Load<T>(string path)
        {
            Debug.Log("File load");
            var savePath = Path.Combine(Application.persistentDataPath, path);
            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                //T loadData = JsonUtility.FromJson<T>(json);
                T loadData = JsonConvert.DeserializeObject<T>(json);
                return loadData;
            }

            return default;

        }
    }
}
