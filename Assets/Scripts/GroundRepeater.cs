using UnityEngine;

public class GroundRepeater : MonoBehaviour
{
    public Transform player;

    private float groundLength;

    void Start()
    {
        // Calculate actual ground length automatically
        groundLength = transform.localScale.z * 10f;
    }

    void Update()
    {
        if (player == null)
            return;

        if (player.position.z > transform.position.z + groundLength)
        {
            transform.position += Vector3.forward * groundLength * 3;
        }
    }
}