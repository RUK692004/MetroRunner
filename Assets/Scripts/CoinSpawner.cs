using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public Transform player;

    public float spawnInterval = 3f;

    private float timer = 0f;

    private float[] lanes = { -3f, 0f, 3f };

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
        }
    }

    void Update()
    {
        if (player == null)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCoin();

            timer = 0f;
        }
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
    void SpawnCoin()
    {
        float startZ =
            player.position.z + 25f;

        int pattern =
            Random.Range(0, 4);

        switch (pattern)
        {
            // Straight line
            case 0:

                for (int i = 0; i < 3; i++)
                {
                    CreateCoin(
                        0f,
                        startZ + i * 3f
                    );
                }

                break;

            // Zigzag
            case 1:

                CreateCoin(-3f, startZ);

                CreateCoin(0f, startZ + 3f);

                CreateCoin(3f, startZ + 6f);

                break;

            // All lanes
            case 2:

                CreateCoin(-3f, startZ);

                CreateCoin(0f, startZ);

                CreateCoin(3f, startZ);

                break;

            // Side lanes only
            case 3:

                CreateCoin(-3f, startZ);

                CreateCoin(3f, startZ);

                break;
        }
    }
}