using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    private int score;
    private bool gameOver = false;

    void Update()
    {
        if (gameOver)
            return;

        // Score based on distance travelled
        score = Mathf.FloorToInt(player.position.z);

        scoreText.text = "SCORE : " + score;
    }

    public void StopScore()
    {
        gameOver = true;
    }
}