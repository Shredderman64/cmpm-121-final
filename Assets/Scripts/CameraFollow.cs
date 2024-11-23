using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;            // The player’s transform to follow
    public Vector3 offset = new Vector3(0, 10, -10); // Offset to keep the camera at a distance
    public float smoothSpeed = 0.125f;  // Smooth factor for camera movement

    private void LateUpdate()
    {
        if (player != null)
        {
            // Desired camera position based on player position and offset
            Vector3 desiredPosition = player.position + offset;
            
            // Smoothly interpolate between the current and desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            
            // Update the camera position
            transform.position = smoothedPosition;
            
            // Optionally, keep the camera looking at the player (if needed for angled views)
            transform.LookAt(player.position);
        }
    }
}
