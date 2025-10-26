using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 10.0f;

    void FixedUpdate()
    {
        Transform enemyTransform = gameObject.transform;
        float step = speed * Time.deltaTime;
        if (playerTransform != null)
        {
            enemyTransform.position = Vector3.MoveTowards(enemyTransform.position,
                                                          playerTransform.position,
                                                          step);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I have collieded!");
        GameObject collidedGameObject = collision.gameObject;
        if (collidedGameObject.tag == "Player")
        {
            // Do game over
            Destroy(collidedGameObject);
            Destroy(gameObject);
        }

        else if (collidedGameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
