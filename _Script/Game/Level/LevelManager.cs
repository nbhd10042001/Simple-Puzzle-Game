using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public LevelData levelData;
    public Text txtLevel;
    private Image _image;
    public bool _isActive;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        txtLevel.text = $"{levelData.level}";
    }

    public void SetLevelActive(bool isActive)
    {
        _isActive = isActive;
        if (!_isActive)
            _image.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        else
            _image.color = new Color(1f, 1f, 1f, 1f);
    }

    public void BtnLevelPressed()
    {
        AudioManager.Instance.PlayOneShot_Click1();
        if (!_isActive) return;

        PlayerManager.Instance.levelSelect = levelData.level;
        SceneManager.LoadScene("Game");
    }
}
