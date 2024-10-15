using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 3f; // Bullet lifetime
    public float speed = 10f; // Bullet speed
    private Renderer bulletRenderer; // Renderer for changing color

    void Start()
    {
        bulletRenderer = GetComponent<Renderer>(); // Get the bullet's Renderer component
        Destroy(gameObject, life); // Destroy the bullet after its lifetime
    }

    // Method to initialize the bullet's properties
    public void Initialize(Color color, Vector3 direction)
    {
        bulletRenderer.material.color = color; // Set the bullet's initial color
        GetComponent<Rigidbody>().velocity = direction * speed; // Set the bullet's velocity
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Orange", "Purple", or "Blue" tag
        if (collision.gameObject.CompareTag("Orange") ||
            collision.gameObject.CompareTag("Purple") ||
            collision.gameObject.CompareTag("Blue"))
        {
            // Get the Renderer of the collided enemy
            Renderer enemyRenderer = collision.gameObject.GetComponent<Renderer>();
            if (enemyRenderer != null)
            {
                // Set the bullet's color to match the enemy's color
                bulletRenderer.material.color = enemyRenderer.material.color;
                Debug.Log($"Bullet color changed to match the {collision.gameObject.tag} enemy.");
            }

            // Destroy the enemy
            Destroy(collision.gameObject); // Example: Destroy the enemy
        }

        // Destroy the bullet upon collision with any object
        Destroy(gameObject);
    }
}
