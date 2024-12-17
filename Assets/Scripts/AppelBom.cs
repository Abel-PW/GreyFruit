using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppelBom : MonoBehaviour
{
    [Header("Bomb Settings")]
    public GameObject bombPrefab;       // Bomb prefab
    public Transform ThrowPoint;        // Point where bomb spawns
    public float throwForce = 10f;      // Force to throw the bomb

    private Vector2 throwDirection;     // Direction to throw the bomb

    void Update()
    {
        // Check for the Q key press
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ThrowBomb();
        }
    }

    void ThrowBomb()
    {
        // Determine the direction based on player facing
        float direction = transform.localScale.x; // Use scale to detect facing direction (+1 = right, -1 = left)

        // Adjust the bomb's spawn position and force direction
        throwDirection = new Vector2(direction, 0).normalized;

        // Instantiate the bomb at the throw point
        GameObject bomb = Instantiate(bombPrefab, ThrowPoint.position, Quaternion.identity);

        // Access the Rigidbody2D of the bomb
        Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Apply a throw force in the correct direction
            rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogWarning("No Rigidbody2D found on bombPrefab!");
        }
    }
}
