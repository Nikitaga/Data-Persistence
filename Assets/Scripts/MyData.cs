using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MyData : MonoBehaviour
{
    public static MyData Instance;

    public string playerName;
    public int highScore;
    public string bestPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string bestPlayer;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.bestPlayer = bestPlayer;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            bestPlayer = data.bestPlayer;
        }
        else
        {
            highScore = 0;
            bestPlayer = "No One";
        }
    }
}
