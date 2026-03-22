using System.IO;
using TMPro;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Analytics.IAnalytic;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string currentPlayerName;
    public string topPlayerName;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    public void SaveName(TMP_InputField inputField)
    {
        Debug.Log(inputField.text);
        DataManager.Instance.currentPlayerName = inputField.text;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string currentPlayerName;
        public string topPlayerName;
        public int highScore;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.currentPlayerName = currentPlayerName;
        data.topPlayerName = topPlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            currentPlayerName = data.currentPlayerName;
            topPlayerName = data.topPlayerName;
            highScore = data.highScore;
            
        }
    }
}
