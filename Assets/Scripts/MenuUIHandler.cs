using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public static MenuUIHandler Instance;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
    }

    

    public static void SavePlayer(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            return new PlayerData();
        }
    }

    public TMP_InputField nameInputField;

    public void SaveName()
    {
        PlayerData data = new PlayerData();
        data.playerName = nameInputField.text;

        SavePlayer(data);
    }

}
