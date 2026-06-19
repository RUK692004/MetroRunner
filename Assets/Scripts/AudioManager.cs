using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    public AudioSource audioSource;        // for SFX
    public AudioSource musicSource;        // NEW for background music

    [Header("SFX")]
    public AudioClip coinSound;
    public AudioClip gameOverSound;
    public AudioClip buttonClickSound;

    [Header("Music")]
    public AudioClip backgroundMusic;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);   // IMPORTANT
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        PlayMusic();
    }

    // 🎵 Background music
    public void PlayMusic()
    {
        if (backgroundMusic == null) return;

        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = 0.4f; // soothing level
        musicSource.Play();
    }

    // 🎧 SFX
    public void PlayCoin()
    {
        audioSource.PlayOneShot(coinSound);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOverSound);
    }

    public void PlayButton()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
}