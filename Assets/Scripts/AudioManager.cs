using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;

    public AudioClip coinSound;

    public AudioClip gameOverSound;

    public AudioClip buttonClickSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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