using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0f; // 0 = instant follow (old behavior), e.g. 5-10 for smooth follow

    private Vector3 offset;

    void Start()
    {
        // Auto-recover if the Inspector field was left empty
        if (player == null)
        {
            GameObject found = GameObject.FindGameObjectWithTag("Player");
            if (found != null)
            {
                player = found.transform;
                Debug.LogWarning("CameraFollow: Player reference was empty, auto-assigned via 'Player' tag.");
            }
        }

        if (player == null)
        {
            Debug.LogError("CameraFollow: Player reference is not assigned in the Inspector and no GameObject tagged 'Player' was found!");
            enabled = false;
            return;
        }

        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player == null)
            return;

        Vector3 targetPosition = player.position + offset;

        if (smoothSpeed > 0f)
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        else
            transform.position = targetPosition;
    }
}