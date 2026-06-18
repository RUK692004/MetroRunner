using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [HideInInspector] public float speed;
    [HideInInspector] public float destroyZ;

    void Update()
    {
        // Move obstacle toward the player along world Z, regardless of this object's own rotation
        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        // Destroy obstacle when it's behind the player
        if (transform.position.z < destroyZ)
        {
            Destroy(gameObject);
        }
    }
}