using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private PlayerData _playerData;
    public int levelSelect = 1;
    private string _pathPlayerData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        _pathPlayerData = Application.persistentDataPath + "/Resources/PlayerData/PlayerData.json";

        // persistentDataPath: C:/Users/DUC/AppData/LocalLow/DefaultCompany/Simple Puzzle Game
        if (!Directory.Exists(Application.persistentDataPath + "/Resources/PlayerData"))
            Directory.CreateDirectory(Application.persistentDataPath + "/Resources/PlayerData");

        //check if not find the file json PlayerData.json, then create new file PlayerData.json
        if (!File.Exists(_pathPlayerData))
        {
            PlayerData _newPlayerData = new PlayerData();
            _newPlayerData.SetDefault();

            string js = JsonUtility.ToJson(_newPlayerData);;
            File.WriteAllText(_pathPlayerData, js);

            while (true)
                if (File.Exists(_pathPlayerData))
                    break;
        }

        string json = File.ReadAllText(_pathPlayerData);
        _playerData = JsonUtility.FromJson<PlayerData>(json);
    }

    public PlayerData GetPlayerData()
    {
        return _playerData;
    }

    public void SavePlayerData(PlayerData playerData)
    {
        _playerData = playerData;
        string json = JsonUtility.ToJson(_playerData);
        File.WriteAllText(_pathPlayerData, json);
    }
}
