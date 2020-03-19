using System;
using System.Collections;
using System.Collections.Generic;
using Dands.Utils.StaticCoroutines;
using Newtonsoft.Json;
using UnityEngine;

namespace Dands.APlayerPrefs
{
    public static class APlayerPrefs
    {
        private const bool AUTO_SAVE = true;
        private const float TIME_AUTO_SAVE = 1f;
        private static WaitForSeconds DELAY_SAVE;
        private const string SAVE_FILE_NAME = "playerPrefs";

        private static Dictionary<string, string> _playerPrefs;
        private static bool _needsSaving;
        
        /// <summary>
        /// Use in any MonoBehaviour
        /// </summary>
        public static void Setup()
        {
            _playerPrefs = new Dictionary<string, string>();
            DELAY_SAVE = new WaitForSeconds(TIME_AUTO_SAVE);

            Load();

            if (AUTO_SAVE)
            {
                StaticCoroutine.DoCoroutine(AutoSave());
            }
        }

        #region Public Get, Set and util

        #region Set
        /// <summary>
        /// Save INT data, identified with a key
        /// </summary>
        /// <param name="key">The key to identify the data with</param>
        /// <param name="value">The data to save</param>
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
            var json = JsonConvert.SerializeObject(value);
            SetString(key, json);
        }


        #endregion

        #region Get

        public static string GetString(string key)
        {
            return GetDictionary(key);
        }
        
        /// <summary>
        /// Load INT data, identified by key
        /// </summary>
        /// <param name="key">The key the data is identified with</param>
        /// <returns>The loaded INT value</returns>
        public static int GetInt(string key)
        {
            var value = GetDictionary(key);
            try
            {
                return int.Parse(value);
            }
            catch (Exception e)
            {
                Debug.LogWarning("Error when converting to int... using default value" + e);
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
                Debug.LogWarning("Error when converting to float... using default value" + e);
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
                Debug.LogWarning("Error when converting to long... using default value" + e);
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
                Debug.LogWarning("Error when converting to double... using default value" + e);
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
                Debug.LogWarning("Error when converting to bool... using default value" + e);
                return false;
            }
        }

        public static T GetObject<T>(string key)
        {
            var load = GetString(key);
            T json = JsonConvert.DeserializeObject<T>(load);
            return string.IsNullOrWhiteSpace(load) ? default : json;
        }

        #endregion

        #region Util
        /// <summary>
        /// Public method to manualy save APlayerPrefs
        /// </summary>
        public static void Save()
        {
            SaveData();
        }
    
        /// <summary>
        /// Check if saved data exists identified by this key
        /// </summary>
        private static bool HasKey(string key)
        {
            string keyUpper = key.ToUpper();
            return _playerPrefs.ContainsKey(keyUpper);
        }
        
        /// <summary>
        /// Delete all the saved data in GameValues. Be very very careful with this!
        /// </summary>
        public static void DeleteAll()
        {
            _playerPrefs = new Dictionary<string, string>();

            SaveData();
        }

        /// <summary>
        /// Delete the data saved at this key, if there is any
        /// </summary>
        /// <param name="key"></param>
        public static void DeleteKey(string key)
        {
            string keyUpper = key.ToUpper();
            if (HasKey(keyUpper))
            {
                _playerPrefs.Remove(keyUpper);
                _needsSaving = true;
            }
        }

        #endregion

        #endregion

        #region Read and write

        private static void Load()
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
            _needsSaving = false;
        }
        
        private static IEnumerator AutoSave()
        {
            Debug.Log("AutoSave");
            
            if (_needsSaving)
            {
                SaveData();
            }

            yield return DELAY_SAVE;
            
            StaticCoroutine.DoCoroutine(AutoSave());
        }

        #endregion

        #region Auxiliary methods

        private static void SetDictionary(string key, string value)
        {
            string keyUpper = key.ToUpper();

            if (HasKey(keyUpper))
            {
                if (_playerPrefs[keyUpper] != value)
                {
                    _playerPrefs[keyUpper] = value;
                    _needsSaving = true;
                }
            }
            else
            {
                _playerPrefs.Add(keyUpper, value);
                _needsSaving = true;
            }
        }

        private static string GetDictionary(string key)
        {
            string keyUpper = key.ToUpper();
            var value = _playerPrefs.ContainsKey(keyUpper) ? _playerPrefs[keyUpper] : "";
            return value;
        }
        #endregion
    }
}


