using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public AudioSource AS_Music;
    public AudioSource AS_OneShot_Click;
    public AudioSource AS_OneShot;

    public AudioClip AC_mainMusic;
    public AudioClip AC_oneShotClick1;
    public AudioClip AC_oneShotClick2;
    public AudioClip AC_oneShotCombo;
    public AudioClip AC_oneShotWin;
    public AudioClip AC_oneShotLose;


    private void Start()
    {
            PlayMainMusic();
    }

    public void ChangeValueMusic(float value)
    {
        AS_Music.volume = value;
    }

    public void ChangeValueSound(float value)
    {
        AS_OneShot_Click.volume = value;
        AS_OneShot.volume = value;
    }

    public void PlayMainMusic()
    {
        AS_Music.clip = AC_mainMusic;
        AS_Music.loop = true;
        AS_Music.Play();
    }

    public void PlayOneShot_Win()
    {
        AS_OneShot.PlayOneShot(AC_oneShotWin);
    }

    public void PlayOneShot_Lose()
    {
        AS_OneShot.PlayOneShot(AC_oneShotLose);
    }

    public void PlayOneShotCombo()
    {
        AS_OneShot.PlayOneShot(AC_oneShotCombo);
    }

    public void PlayOneShot_Click1()
    {
        AS_OneShot_Click.PlayOneShot(AC_oneShotClick1);
    }

    public void PlayOneShot_Click2()
    {
        AS_OneShot_Click.PlayOneShot(AC_oneShotClick2);
    }

    
}
