using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public float spawnInterval = 2f;

    public float obstacleSpeed = 8f;

    private float[] lanes = { -3f, 0f, 3f };

    public Transform player;

    private float timer = 0f;

    private bool isSpawning = true;

    void Start()
    {
        if (player == null)
        {
            GameObject found =
                GameObject.FindGameObjectWithTag("Player");

            if (found != null)
            {
                player = found.transform;
            }
            else
            {
                Debug.LogError("Player not found!");
            }
        }
    }

    void Update()
    {
        if (!isSpawning || player == null)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();

            timer = 0f;
        }
    }

    void CreateObstacle(float laneX)
    {
        float zPos = player.position.z + 30f;

        GameObject obstacle = Instantiate(
            obstaclePrefab,
            new Vector3(laneX, 0.5f, zPos),
            Quaternion.identity
        );

        obstacle.tag = "Obstacle";

        ObstacleMovement movement =
            obstacle.GetComponent<ObstacleMovement>();

        if (movement == null)
        {
            movement =
                obstacle.AddComponent<ObstacleMovement>();
        }

        movement.speed = obstacleSpeed;

        movement.destroyZ =
            player.position.z - 10f;
    }
    void SpawnObstacle()
    {
        int obstacleCount = 1;

        if (player == null)
            return;

        int score =
            FindAnyObjectByType<ScoreManager>().GetScore();

        // Increase difficulty based on score
        if (score > 150)
            obstacleCount = 3;
        else if (score > 60)
            obstacleCount = 2;

        // Always keep at least one lane free
        int freeLane = Random.Range(0, lanes.Length);

        for (int i = 0; i < lanes.Length; i++)
        {
            if (obstacleCount == 1)
            {
                i = Random.Range(0, lanes.Length);
            }

            if (i == freeLane)
                continue;

            CreateObstacle(lanes[i]);

            obstacleCount--;

            if (obstacleCount <= 0)
                break;
        }
    }

    // Stops creating new obstacles
    public void StopSpawning()
    {
        isSpawning = false;
    }
}