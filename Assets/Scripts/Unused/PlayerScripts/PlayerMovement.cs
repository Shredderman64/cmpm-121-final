using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GridManager gridManager;
    public float moveSpeed = 5f;      // Speed of the movement animation
    private bool isMoving = false;    // Tracks if player is currently moving

    private void Update()
    {
        if (!isMoving)  // Only process input if player is not moving
        {
            Vector3 targetPosition = transform.position;
            float tileX = gridManager.GetCoordinate(targetPosition.x);
            float tileY = gridManager.GetCoordinate(targetPosition.z);

            // Get input and calculate the new target position
            bool isUp = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
            bool isDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
            bool isLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
            bool isRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

            if (tileY < gridManager.Rows - 1 && isUp)
                targetPosition += Vector3.forward * gridManager.GetTileSize();       // Move up
            else if (tileY > 0 && isDown)
                targetPosition += Vector3.back * gridManager.GetTileSize();     // Move down
            else if (tileX > 0 && isLeft)
                targetPosition += Vector3.left * gridManager.GetTileSize();     // Move left
            else if (tileX < gridManager.Columns - 1 && isRight)
                targetPosition += Vector3.right * gridManager.GetTileSize();    // Move right

            // If target position has changed, start moving
            if (targetPosition != transform.position)
                StartCoroutine(MoveToPosition(targetPosition));
        }
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        ObjectivesManager.Instance.CompleteObjective(0); // Completes objective 0: Move around with WASD keys
        isMoving = true;

        // Smoothly move the player to the target position
        while ((targetPosition - transform.position).sqrMagnitude > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Snap to target position (to avoid floating-point inaccuracies)
        transform.position = targetPosition;
        isMoving = false;
        
    }
}
