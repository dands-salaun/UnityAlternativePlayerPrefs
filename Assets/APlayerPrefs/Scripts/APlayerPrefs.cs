using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
namespace Dands.APlayerPrefs
{
    public static class APlayerPrefs
    {
        private const string SAVE_FILE_NAME = "playerPrefs";

        private static Dictionary<string, string> _playerPrefs;

        public static void Setup()
        {
            _playerPrefs = new Dictionary<string, string>();

            LoadData();
        }

        private static void LoadData()
        {
            var data = SaveSystem.Load<Dictionary<string, string>>(SAVE_FILE_NAME);
            if (data == null || data.Count == 0)
            {
                Debug.LogWarning("There's no data to load from disk");
                return;
            }

            _playerPrefs = data;

        }

        private static void SaveData()
        {
            SaveSystem.Save(_playerPrefs, SAVE_FILE_NAME);
        }

        private static void SetDictionary(string key, string value)
        {
            string keyUpper = key.ToUpper();

            if (HasKey(keyUpper))
            {
                if (_playerPrefs[keyUpper] != value)
                {
                    _playerPrefs[keyUpper] = value;
                }
            }
            else
            {
                _playerPrefs.Add(keyUpper, value);
            }
            
            SaveData();
        }

        private static string GetDictionary(string key)
        {
            string keyUpper = key.ToUpper();
            var value = _playerPrefs.ContainsKey(keyUpper) ? _playerPrefs[keyUpper] : "";
            return value;
        }
        private static bool HasKey(string key)
        {
            string keyUpper = key.ToUpper();
            return _playerPrefs.ContainsKey(keyUpper);
        }

        public static void SetInt(string key, int value)
        {
            SetDictionary(key, value.ToString());
        }

        public static void SetFloat(string key, float value)
        {
            SetDictionary(key, value.ToString());
        }

        public static void SetString(string key, string value)
        {
            SetDictionary(key, value);
        }


        public static void SetBool(string key, bool value)
        {
            SetDictionary(key, value.ToString());
        }


        public static void SetDouble(string key, double value)
        {
            SetDictionary(key, value.ToString());
        }


        public static void SetLong(string key, long value)
        {
            SetDictionary(key, value.ToString());
        }

        public static void SaveObject(string key, object value)
        {
            //var json = JsonUtility.ToJson(value);
            var json = JsonConvert.SerializeObject(value);
            SetString(key, json);
        }

        public static string GetString(string key)
        {
            return GetDictionary(key);
        }

        public static int GetInt(string key)
        {
            var value = GetDictionary(key);
            try
            {
                return int.Parse(value);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public static float GetFloat(string key)
        {
            var value = GetDictionary(key);
            try
            {
                return float.Parse(value);
            }
            catch (Exception e)
            {
                return 0f;
            }
        }

        public static long GetLong(string key)
        {
            var value = GetDictionary(key);
            try
            {
                return long.Parse(value);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public static double GetDouble(string key)
        {
            var value = GetDictionary(key);
            try
            {
                return double.Parse(value);
            }
            catch (Exception e)
            {
                return 0f;
            }
        }

        public static bool GetBool(string key)
        {
            var value = GetDictionary(key);
            try
            {
                return bool.Parse(value);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static T GetObject<T>(string key)
        {
            var load = GetString(key);
            //T json = JsonUtility.FromJson<T>(load);
            T json = JsonConvert.DeserializeObject<T>(load);
            return string.IsNullOrWhiteSpace(load) ? default : json;
        }

        public static void ClearData()
        {
            _playerPrefs = new Dictionary<string, string>();

            SaveData();
        }

        public static void DeleteKey(string key)
        {
            string keyUpper = key.ToUpper();
            if (HasKey(keyUpper))
            {
                _playerPrefs.Remove(keyUpper);
            }
        }
    }
}


