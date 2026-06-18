using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

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

        int randomIndex =
            Random.Range(0, obstaclePrefabs.Length);

        GameObject obstacle = Instantiate(
            obstaclePrefabs[randomIndex],
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

    void CreateObstacle(
    float laneX,
    float zPos
)
    {
        int randomIndex =
        Random.Range(
            0,
            obstaclePrefabs.Length
        );

        GameObject obstacle =
            Instantiate(
                obstaclePrefabs[randomIndex],
                new Vector3(
                    laneX,
                    0.5f,
                    zPos
                ),
                Quaternion.identity
            );

        obstacle.tag = "Obstacle";

        ObstacleMovement movement =
            obstacle.GetComponent<ObstacleMovement>();

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
    void SpawnObstacle()
    {
        if (player == null)
            return;

        float zPos = player.position.z + 30f;

        int pattern =
            Random.Range(0, 4);

        switch (pattern)
        {
            // Left + Middle blocked
            case 0:

                CreateObstacle(-3f, zPos);

                CreateObstacle(0f, zPos);

                break;

            // Middle + Right blocked
            case 1:

                CreateObstacle(0f, zPos);

                CreateObstacle(3f, zPos);

                break;

            // Left + Right blocked
            case 2:

                CreateObstacle(-3f, zPos);

                CreateObstacle(3f, zPos);

                break;

            // Middle only
            case 3:

                CreateObstacle(0f, zPos);

                break;
        }
    }

    // Stops creating new obstacles
    public void StopSpawning()
    {
        isSpawning = false;
    }
}