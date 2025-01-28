using UnityEngine;

public class AppelBom : MonoBehaviour
{
    public GameObject bombPrefab; // The bomb prefab
    public Transform throwPoint;  // Throw point (child of the player)
    public float throwForce = 10f; // Force applied to the bomb
    private bool isFacingRight = true; // Use this to track player's direction

    void Update()
    {
        // Detect Q key press
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ThrowBomb();
        }
    }

    void ThrowBomb()
    {
        if (bombPrefab == null || throwPoint == null)
        {
            Debug.LogError("BombPrefab or ThrowPoint is not assigned!");
            return;
        }

        // Instantiate the bomb at the ThrowPoint's position
        GameObject bomb = Instantiate(bombPrefab, throwPoint.position, Quaternion.identity);

        // Get the Rigidbody2D of the bomb
        Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Apply force to throw the bomb in the facing direction
            float direction = isFacingRight ? 1f : -1f; // 1 for right, -1 for left
            Vector2 throwDirection = new Vector2(direction, 0.5f).normalized; // Slightly upwards
            rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
        }
    }

    // Optional: Update facing direction from your movement code
    public void UpdateFacingDirection(bool facingRight)
    {
        isFacingRight = facingRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyDeath(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Terrain") && this.gameObject.CompareTag("Bom"))
        {
            DestroyBom(this.gameObject); // Destroy the bomb instead of the terrain
        }
    }
    private void DestroyBom(GameObject Bom)
    {
        Destroy(Bom);
    }
    private void EnemyDeath(GameObject Enemy)
    {
        Destroy(Enemy);
    }
}
