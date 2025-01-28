using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Movement speed of the enemy
    public float detectionDistance = 1.0f; // Distance to detect obstacles
    public LayerMask obstacleLayer; // Layer to detect obstacles

    private bool movingRight = false; // Indicates the current direction of movement

    void Update()
    {
        // Move the enemy in the current direction
        transform.Translate(Vector2.right * speed * Time.deltaTime * (movingRight ? 1 : -1));

        // Check for obstacles
        if (IsObstacleAhead())
        {
            TurnAround();
        }
    }

    
    // Checks if there is an obstacle ahead using Raycast
    private bool IsObstacleAhead()
    {
        // Define the direction of the ray based on movement direction
        Vector2 direction = movingRight ? Vector2.right : Vector2.left;

        // Perform a raycast to detect obstacles
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionDistance, obstacleLayer);

        // Debugging the raycast in the Scene view
        Debug.DrawRay(transform.position, direction * detectionDistance, Color.red);

        // Return true if the raycast hit an obstacle
        return hit.collider != null;
    }

    // Switch the movement direction
    private void TurnAround()
    {
        

        movingRight = !movingRight;

        // Flip the sprite horizontally if a SpriteRenderer is attached
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
