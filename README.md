#APlayerPrefs

This Unity library is designed to replace the standard Unity PlayerPrefs.

The main difference is that it saves all records in JSON format to a file in Application.persistentDataPath. For this, the [JSON.Net](https://assetstore.unity.com/packages/tools/input-management/json-net-for-unity-11347 "JSON.Net") resource, available for free at the asset store, was used.

This makes it much easier to store your save games data in places like the Steam Cloud services, iCloud, Google Play or your own backend etc ..

The Library also adds some functionality such as extra record types and more refined / flexible data access.

Tested on Windows and Android.


##Installation
Grab the latest unity package from the [releases](https://github.com/dands-salaun/APlayerPrefs/releases "releases") tab of this repo and import it into your project.


##Save File Name

At the top of the script FileBasedPrefs.cs you can specify what name you would like your save file to have in the string `SAVE_FILE_NAME`.


##Usage

###Set

```csharp
APlayerPrefs.SetString(string key, string value);
APlayerPrefs.SetInt(string key, int value);
APlayerPrefs.SetFloat(string key, float value);
APlayerPrefs.SetDouble(string key, double value);
APlayerPrefs.SetLong(string key, long value);
APlayerPrefs.SetBool(string key, string value);
APlayerPrefs.SaveObject<T>(string key, T value);
```
###Get
```csharp
APlayerPrefs.GetString(string key);
APlayerPrefs.GetInt(string key);
APlayerPrefs.GetFloat(string key);
APlayerPrefs.GetDuble(string key);
APlayerPrefs.GetLong(string key);
APlayerPrefs.GetBool(string key);
APlayerPrefs.GetObject<T>(string key);

```

###Utils

```csharp
APlayerPrefs.Save();
APlayerPrefs.HasKey(string key);
APlayerPrefs.DeleteAll();
APlayerPrefs.Deletekey();

```



##Manual File writing
At the top of FileBasedPrefs.cs is a bool named `AUTO_SAVE`;

If set to true (the default setting), it will save the data for the time interval defined in `DELAY_SAVE`.

If set to false, then it will only save the data to file when you call `APlayerPrefs.Save();`

This means that the save data is stored in memory until you specifically tell it to write the file. This is much faster and causes no performance issues.
