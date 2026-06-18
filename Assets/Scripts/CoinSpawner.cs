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

    void SpawnCoin()
    {
        float laneX =
            lanes[Random.Range(0, lanes.Length)];

        float zPos =
            player.position.z + 25f;

        Instantiate(
            coinPrefab,
            new Vector3(laneX, 1f, zPos),
            Quaternion.identity
        );
    }
}