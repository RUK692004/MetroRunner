using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public Transform player;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI bestScoreText;

    private int score;

    private int bestScore;

    private bool isGameOver = false;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);

        UpdateBestScoreUI();
    }

    void Update()
    {
        if (isGameOver)
            return;

        score = Mathf.FloorToInt(player.position.z);

        scoreText.text = "SCORE : " + score;

        if (score > bestScore)
        {
            bestScore = score;

            PlayerPrefs.SetInt(
                "BestScore",
                bestScore
            );

            PlayerPrefs.Save();

            UpdateBestScoreUI();
        }
    }

    void UpdateBestScoreUI()
    {
        bestScoreText.text =
            "BEST : " + bestScore;
    }

    public void StopScore()
    {
        isGameOver = true;
    }
    public int GetScore()
    {
        return score;
    }
}