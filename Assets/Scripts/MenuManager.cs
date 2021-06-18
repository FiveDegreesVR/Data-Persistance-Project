using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;

    public InputField nameInput;

    public string playerName;

    private void Awake()
    {
        if (Instance != null) //creates singleton: only one instance can exist
        {
            Destroy(gameObject);
            return;
        }
        Instance = this; // declares this is the current instance of main manager object, can call MainManager.instance from any script
        DontDestroyOnLoad(gameObject); // game object attached to this script does not delete when scene changes

        //loadName();
        nameInput.text = playerName;
    }

    private void SetName()
    {
        playerName = nameInput.text;
        //saveName();
    }


    public void StartGame()
    {
        SetName();

        if (playerName.Equals(null))
        {
            playerName = "None";
        }


        SceneManager.LoadScene(1);
    }

    /*
    public void saveName()
    {
        data = new SaveData();
        data.name = name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            name = data.name;
        }
    }
    */
}
