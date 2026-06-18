using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float laneDistance = 2f;
    public float laneSwitchSpeed = 10f;
    public float forwardSpeed = 8f;

    private int currentLane = 0;

    private const int MIN_LANE = -1;
    private const int MAX_LANE = 1;

    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Stop movement if game is over
        if (isGameOver)
            return;

        // Move forward continuously
        transform.Translate(
            Vector3.forward * forwardSpeed * Time.deltaTime
        );

        // Move left
        if (Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.A))
        {
            if (currentLane > MIN_LANE)
            {
                currentLane--;
            }
        }

        // Move right
        if (Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.D))
        {
            if (currentLane < MAX_LANE)
            {
                currentLane++;
            }
        }

        // Target lane position
        float targetX = currentLane * laneDistance;

        // Move only on X axis
        Vector3 pos = transform.position;

        pos.x = Mathf.MoveTowards(
            pos.x,
            targetX,
            laneSwitchSpeed * Time.deltaTime
        );

        transform.position = pos;
    }   

    private void OnTriggerEnter(Collider other)
    {
        // Prevent multiple Game Over calls
        if (isGameOver)
            return;

        if (other.CompareTag("Obstacle"))
        {
            isGameOver = true;

            Debug.Log("Game Over!");

            ObstacleSpawner spawner = FindAnyObjectByType<ObstacleSpawner>(); ;

            if (spawner != null)
            {
                spawner.StopSpawning();
            }

            // Freeze the whole game
            Time.timeScale = 0f;
        }
    }
}