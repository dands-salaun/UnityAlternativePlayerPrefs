using System;
using UnityEngine;
using Dands.APlayerPrefs;
[Serializable]
public class Character
{
    public string name;
    public float health;
    public int stamina;
}
public class DemoAPlayerPrefs : MonoBehaviour
{
    private void Awake()
    {
        APlayerPrefs.Setup();
    }

    private void Start()
    {
        APlayerPrefs.SetInt("Age", 31);
        APlayerPrefs.SetString("Name", "Fernando");
        APlayerPrefs.SetFloat("Stature", 1.6f);
        APlayerPrefs.SetDouble("Width", 0.5);
        APlayerPrefs.SetLong("days", 1);
        APlayerPrefs.SetBool("studant", false);
        
        Character character = new Character();
        character.name = "Angelina";
        character.health = 50f;
        character.stamina = 10;
        
        APlayerPrefs.SaveObject("data_character", character);
        
        Invoke("PrintValues", 2f);
        
    }

    private void PrintValues()
    {
        Debug.Log("Key " + "Name - " + "Value: " + APlayerPrefs.GetString("NAME"));
        Debug.Log("Key " + "Age - " + "Value: " + APlayerPrefs.GetInt("AGE"));
        Debug.Log("Key " + "Stature - " + "Value: " + APlayerPrefs.GetFloat("Stature"));
        Debug.Log("Key " + "Width - " + "Value: " + APlayerPrefs.GetDouble("Width"));
        Debug.Log("Key " + "days - " + "Value: " + APlayerPrefs.GetLong("DAYS"));
        Debug.Log("Key " + "studant - " + "Value: " + APlayerPrefs.GetBool("studant"));
        
        Debug.Log("--------- CHARACTER ------");
        Character loadCharacter = APlayerPrefs.GetObject<Character>("data_character");
        Debug.Log(loadCharacter.name);
        Debug.Log(loadCharacter.health);
        Debug.Log(loadCharacter.stamina);
        
        // Deleting key name
        APlayerPrefs.DeleteKey("Name");
        

    }
}
