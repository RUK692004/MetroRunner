using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public TMP_Text bestScoreText;

    void Start()
    {
        int best = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = "Best Score: " + best;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}