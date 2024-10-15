using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    // Materials for each color
    public Material orangeMaterial;
    public Material purpleMaterial;
    public Material blueMaterial;

    // Bullet prefabs for different colors
    public GameObject orangeBulletPrefab;
    public GameObject purpleBulletPrefab;
    public GameObject blueBulletPrefab;

    private Renderer playerRenderer; // Renderer for the player
    private string currentColorTag; // Track the current color tag

    void Start()
    {
        playerRenderer = GetComponent<Renderer>(); // Get the player's Renderer component
        ChangeColor(); // Set an initial random color
    }

    void Update()
    {
        // Change color when the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        // Randomly pick one of the three colors
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex)
        {
            case 0:
                SetColor(orangeMaterial, "Orange");
                break;
            case 1:
                SetColor(purpleMaterial, "Purple");
                break;
            case 2:
                SetColor(blueMaterial, "Blue");
                break;
        }
    }

    void SetColor(Material material, string tag)
    {
        // Set the player's material to the chosen color
        playerRenderer.material = material;
        // Update the player's tag to match the chosen color
        gameObject.tag = tag;
        // Update the current color tag
        currentColorTag = tag;
    }

    // Get the corresponding bullet prefab based on the current color
    public GameObject GetBulletPrefab()
    {
        switch (currentColorTag)
        {
            case "Orange":
                return orangeBulletPrefab;
            case "Purple":
                return purpleBulletPrefab;
            case "Blue":
                return blueBulletPrefab;
            default:
                return orangeBulletPrefab; // Default to orange
        }
    }
}
