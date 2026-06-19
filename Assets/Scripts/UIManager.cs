using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // IMPORTANT: freeze game when dead
    }

    public void RestartGame()
    {
        AudioManager.Instance.PlayButton();

        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    // 🚪 NEW: Quit button support
    public void QuitGame()
    {
        AudioManager.Instance.PlayButton();

        Time.timeScale = 1f; // safety reset
        Application.Quit();

        // NOTE: Works only in build, not in editor
    }
}