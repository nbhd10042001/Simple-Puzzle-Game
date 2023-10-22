using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class UIManager : MonoBehaviour
{
    private PlayerData _playerData;
    public List<LevelManager> listLvMng = new List<LevelManager>();

    private void Awake()
    {
        _playerData = PlayerManager.Instance.GetPlayerData();
    }

    private void Start()
    {
        for (int i = 0; i < _playerData.listLevel.Length; i++)
        {
            for (int j = 0; j < listLvMng.Count; j++)
            {
                if (listLvMng[j].levelData.level == _playerData.listLevel[i])
                {
                    listLvMng[j].SetLevelActive(_playerData.listActiveLevel[i]);
                }
            }
        }
    }

    public void btnBackPressed()
    {
        AudioManager.Instance.PlayOneShot_Click1();
        SceneManager.LoadScene("Home");
    }
}
