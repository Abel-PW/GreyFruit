using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    // Detect collision with the player and handle player death
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerDeath(collision.gameObject);
        }
    }

    // Handle the player's death
    private void PlayerDeath(GameObject player)
    {
        // Example: Destroy the player GameObject
        Destroy(player);

        // Additional actions can be added here, such as triggering a game over screen
        Debug.Log("Player has died!");
    }
}
