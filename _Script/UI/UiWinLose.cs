using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class UiWinLose : MonoBehaviour
{
    public GameObject UiWinLoseGO;
    public Image imageWinLose;
    public Image imageBestScore;
    public Sprite spGameOver;
    public Sprite spGameWin;
    public Sprite spNewBestScore;
    public Sprite spNull;
    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtHighScore;

    private GameplayManager _gpManager;
    private PlayerData _playerData;

    private void Awake()
    {
        _gpManager = GetComponent<GameplayManager>();
        _playerData = PlayerManager.Instance.GetPlayerData();
    }

    public void GameWin(bool isWin)
    {
        int level = PlayerManager.Instance.levelSelect;
        UiWinLoseGO.SetActive(true);
        txtScore.text = $"Score: {_gpManager.GetScore()}";
        txtHighScore.text = $"Best Score\n{_playerData.scoreLevels[level - 1]}";

        if (isWin)
        {
            AudioManager.Instance.PlayOneShot_Win();
            imageWinLose.sprite = spGameWin;

            // active next level
            _playerData.listActiveLevel[level] = true;
        }
        else
        {
            AudioManager.Instance.PlayOneShot_Lose();
            imageWinLose.sprite = spGameOver;
        }

        // if you have new best score
        if (_gpManager.GetScore() > _playerData.scoreLevels[level - 1])
        {
            imageBestScore.sprite = spNewBestScore;
            txtScore.text = $"Score: {_gpManager.GetScore()}";
            txtHighScore.text = $"Best Score\n{_gpManager.GetScore()}";
            //save high score
            _playerData.scoreLevels[level - 1] = _gpManager.GetScore();
        }
        else
            imageBestScore.sprite = spNull;

        PlayerManager.Instance.SavePlayerData(_playerData);
        
    }


    // function button pressed
    public void BtnBackToLevelSelectPressed()
    {
        AudioManager.Instance.PlayOneShot_Click1();
        SceneManager.LoadScene("Level");
    }

    public void BtnTryAgainPressed()
    {
        AudioManager.Instance.PlayOneShot_Click1();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
