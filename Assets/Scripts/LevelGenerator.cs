using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public GameObject coinPrefab;

    public Transform player;

    public ScoreManager scoreManager;

    private float timer;

    private float spawnInterval = 2f;

    private float obstacleSpeed = 8f;

    void Update()
    {
        if (player == null ||
            scoreManager == null)
            return;

        UpdateDifficulty();

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnChunk();

            timer = 0f;
        }
    }

    void UpdateDifficulty()
    {
        int score =
            scoreManager.GetScore();

        // Beginner (0-30)
        if (score < 30)
        {
            obstacleSpeed = 8f;

            spawnInterval = 2f;
        }

        // Intermediate (30-80)
        else if (score < 80)
        {
            obstacleSpeed = 11f;

            spawnInterval = 1.5f;
        }

        // Advanced (80-150)
        else if (score < 150)
        {
            obstacleSpeed = 14f;

            spawnInterval = 1.1f;
        }

        // Very Advanced (150+)
        else
        {
            obstacleSpeed = 17f;

            spawnInterval = 0.8f;
        }
    }

    void SpawnChunk()
    {
        float zPos =
            player.position.z + 30f;

        int score =
            scoreManager.GetScore();

        // Beginner
        if (score < 30)
        {
            int lane =
                Random.Range(0, 3);

            CreateObstacle(
                LaneToX(lane),
                zPos
            );

            CreateCoin(
                LaneToX(
                    (lane + 1) % 3
                ),
                zPos
            );

            return;
        }

        // Intermediate
        if (score < 80)
        {
            int pattern =
                Random.Range(0, 3);

            switch (pattern)
            {
                case 0:

                    CreateObstacle(-3f, zPos);

                    CreateObstacle(0f, zPos);

                    CreateCoin(3f, zPos);

                    break;

                case 1:

                    CreateObstacle(0f, zPos);

                    CreateObstacle(3f, zPos);

                    CreateCoin(-3f, zPos);

                    break;

                case 2:

                    CreateObstacle(-3f, zPos);

                    CreateObstacle(3f, zPos);

                    CreateCoin(0f, zPos);

                    break;
            }

            return;
        }

        // Advanced
        if (score < 150)
        {
            int pattern =
                Random.Range(0, 4);

            switch (pattern)
            {
                case 0:

                    CreateObstacle(-3f, zPos);

                    CreateObstacle(0f, zPos);

                    CreateCoin(3f, zPos);

                    break;

                case 1:

                    CreateObstacle(0f, zPos);

                    CreateObstacle(3f, zPos);

                    CreateCoin(-3f, zPos);

                    break;

                case 2:

                    CreateObstacle(-3f, zPos);

                    CreateObstacle(3f, zPos);

                    CreateCoin(0f, zPos);

                    break;

                case 3:

                    CreateObstacle(0f, zPos);

                    CreateCoin(-3f, zPos);

                    CreateCoin(3f, zPos);

                    break;
            }

            return;
        }

        // Very Advanced (150+)

        int hardPattern =
            Random.Range(0, 3);

        switch (hardPattern)
        {
            case 0:

                CreateObstacle(-3f, zPos);

                CreateObstacle(0f, zPos);

                CreateCoin(3f, zPos);

                break;

            case 1:

                CreateObstacle(0f, zPos);

                CreateObstacle(3f, zPos);

                CreateCoin(-3f, zPos);

                break;

            case 2:

                CreateObstacle(-3f, zPos);

                CreateObstacle(3f, zPos);

                CreateCoin(0f, zPos);

                break;
        }
    }

    float LaneToX(int lane)
    {
        return (lane - 1) * 3f;
    }

    void CreateObstacle(
    float laneX,
    float zPos
)
    {
        if (obstaclePrefabs == null ||
            obstaclePrefabs.Length == 0)
        {
            Debug.LogWarning(
                "No obstacle prefabs assigned!"
            );

            return;
        }

        int randomIndex =
            Random.Range(
                0,
                obstaclePrefabs.Length
            );

        GameObject obstacle =
            Instantiate(
                obstaclePrefabs[randomIndex],
                Vector3.zero,
                Quaternion.identity
            );

        // Auto-adjust height based on obstacle size
        Renderer rend =
            obstacle.GetComponent<Renderer>();

        float yPos = 0.5f;

        if (rend != null)
        {
            yPos =
                rend.bounds.size.y / 2f;
        }

        obstacle.transform.position =
            new Vector3(
                laneX,
                yPos,
                zPos
            );

        obstacle.tag = "Obstacle";

        ObstacleMovement movement =
            obstacle.GetComponent<
                ObstacleMovement>();

        if (movement == null)
        {
            movement =
                obstacle.AddComponent<
                    ObstacleMovement>();
        }

        movement.speed =
            obstacleSpeed;

        movement.destroyZ =
            player.position.z - 10f;
    }

    void CreateCoin(
        float laneX,
        float zPos
    )
    {
        Instantiate(
            coinPrefab,
            new Vector3(
                laneX,
                1f,
                zPos
            ),
            Quaternion.identity
        );
    }
}