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
            return;

        int score =
            scoreManager.GetScore();

        // Beginner
        if (score < 30)
        {
            obstacleSpawner.obstacleSpeed = 8f;

            obstacleSpawner.spawnInterval = 1.8f;
        }

        // Intermediate
        else if (score < 60)
        {
            obstacleSpawner.obstacleSpeed = 11f;

            obstacleSpawner.spawnInterval = 1.4f;
        }

        // Advanced
        else if (score < 90)
        {
            obstacleSpawner.obstacleSpeed = 14f;

            obstacleSpawner.spawnInterval = 1.0f;
        }

        // Very Advanced
        else
        {
            obstacleSpawner.obstacleSpeed = 17f;

            obstacleSpawner.spawnInterval = 0.7f;
        }
    }
}