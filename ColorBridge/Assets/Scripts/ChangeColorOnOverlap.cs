using UnityEngine;

public class ChangeColorOnOverlap : MonoBehaviour
{
    public Color overlapColor = Color.magenta;  // Purple color
    private Color originalColor;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2D;

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;  // Store the initial color
            Debug.Log(gameObject.name + " initialized with original color: " + originalColor);
        }
        else
        {
            Debug.LogError(gameObject.name + " has no SpriteRenderer component!");
        }

        if (collider2D == null)
        {
            Debug.LogError(gameObject.name + " has no Collider2D component!");
        }
    }

    // Called when the prefabs start overlapping (2D trigger)
    void OnTriggerStay2D(Collider2D other)
    {
        // Check if the other object has the 'Prefab' tag
        if (other.gameObject.CompareTag("Prefab"))
        {
            SpriteRenderer otherSpriteRenderer = other.GetComponent<SpriteRenderer>();

            // Check if the other object has a SpriteRenderer
            if (otherSpriteRenderer != null)
            {
                // Ensure they have different original colors
                if (otherSpriteRenderer.color != originalColor)
                {
                    // Check if the sprites are fully overlapping (bounds containment)
                    if (IsFullyOverlapping(other))
                    {
                        Debug.Log(gameObject.name + " fully overlaps with " + other.gameObject.name + " and has a different original color.");
                        ChangeToOverlapColor();
                    }
                    else
                    {
                        ChangeToOriginalColor();  // Revert to original color if not fully overlapping
                    }
                }
                else
                {
                    Debug.Log(gameObject.name + " and " + other.gameObject.name + " have the same original color. No color change.");
                    ChangeToOriginalColor();  // Revert to original color if colors are the same
                }
            }
        }
    }

    // Called when the prefabs stop overlapping (2D trigger)
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Prefab"))
        {
            Debug.Log(gameObject.name + " stopped overlapping with " + other.gameObject.name);
            ChangeToOriginalColor();
        }
    }

    // Check if two colliders are fully overlapping by comparing bounds
    private bool IsFullyOverlapping(Collider2D other)
    {
        Bounds thisBounds = collider2D.bounds;
        Bounds otherBounds = other.bounds;

        // Check if the bounds of the current sprite are fully contained within the other sprite's bounds
        return otherBounds.Contains(thisBounds.min) && otherBounds.Contains(thisBounds.max);
    }

    // Change the color to the overlap color
    private void ChangeToOverlapColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = overlapColor;
            Debug.Log(gameObject.name + " color changed to: " + overlapColor);
        }
    }

    // Revert the color to the original one
    private void ChangeToOriginalColor()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
            Debug.Log(gameObject.name + " color reverted to: " + originalColor);
        }
    }
}
