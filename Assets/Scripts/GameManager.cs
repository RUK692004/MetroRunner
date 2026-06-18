using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreManager scoreManager;

    public ObstacleSpawner obstacleSpawner;

    // Initial values
    public float baseObstacleSpeed = 8f;

    public float baseSpawnInterval = 2f;

    void Update()
    {
        if (scoreManager == null ||
            obstacleSpawner == null)
        {
            return;
        }

        int score = scoreManager.GetScore();

        // Increase obstacle speed gradually
        obstacleSpawner.obstacleSpeed =
            Mathf.Min(
                18f,
                baseObstacleSpeed + score * 0.08f
            );

        // Reduce spawn interval gradually
        obstacleSpawner.spawnInterval =
            Mathf.Max(
                0.6f,
                baseSpawnInterval - score * 0.01f
            );
    }
}