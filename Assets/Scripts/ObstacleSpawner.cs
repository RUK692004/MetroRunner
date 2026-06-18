using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float obstacleSpeed = 8f;

    private float[] lanes = { -3f, 0f, 3f };

    public Transform player;

    void Start()
    {
        if (player == null)
        {
            GameObject found = GameObject.FindGameObjectWithTag("Player");

            if (found != null)
            {
                player = found.transform;
            }
            else
            {
                Debug.LogError("Player not found!");
                return;
            }
        }

        InvokeRepeating(nameof(SpawnObstacle), 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        if (player == null)
            return;

        Debug.Log("Obstacle Spawned");

        float laneX = lanes[Random.Range(0, lanes.Length)];

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
            movement = obstacle.AddComponent<ObstacleMovement>();
        }

        movement.speed = obstacleSpeed;

        movement.destroyZ = player.position.z - 10f;
    }

    // Stops creating new obstacles
    public void StopSpawning()
    {
        CancelInvoke(nameof(SpawnObstacle));
    }
}