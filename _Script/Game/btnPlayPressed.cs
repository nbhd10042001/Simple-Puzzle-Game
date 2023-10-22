using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class btnPlayPressed : MonoBehaviour
{
    public GameObject SettingUIGO;
    public Slider sliderMusic;
    public Slider sliderSound;


    public void OnChangeValueMusic()
    {
        AudioManager.Instance.ChangeValueMusic(sliderMusic.value);
    }

    public void OnChangeValueSound()
    {
        AudioManager.Instance.ChangeValueSound(sliderSound.value);
    }

    public void ButtonPlayPressed()
    {
        AudioManager.Instance.PlayOneShot_Click1();
        SceneManager.LoadScene("Level");
    }

    public void ButtonBackPressed()
    {
        AudioManager.Instance.PlayOneShot_Click1();
        SettingUIGO.SetActive(false);
    }

    public void ButtonSettingPressed()
    {
        AudioManager.Instance.PlayOneShot_Click1();
        SettingUIGO.SetActive(true);
    }
}
