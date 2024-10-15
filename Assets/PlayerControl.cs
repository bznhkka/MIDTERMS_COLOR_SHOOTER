using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Transform bulletSpawnPoint; // Bullet spawn point
    public float bulletSpeed = 10f;

    private ColorSwitcher colorSwitcher; // Reference to the ColorSwitcher script

    void Start()
    {
        colorSwitcher = GetComponent<ColorSwitcher>(); // Get the ColorSwitcher component
    }

    void Update()
    {
        // Fire bullet on left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        // Get the appropriate bullet prefab from the ColorSwitcher
        GameObject bulletPrefab = colorSwitcher.GetBulletPrefab();

        // Instantiate the bullet
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
}
