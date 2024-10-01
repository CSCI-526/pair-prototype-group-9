using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorOnOverlap : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Color originalColor;

    // Store references to the prefabs we're fully overlapping with
    private HashSet<GameObject> fullyOverlappingPrefabs = new HashSet<GameObject>();

    public string targetTag; // The tag of the prefabs we want to overlap with (SetB if this is SetA)

    void Start()
    {
        // Get the SpriteRenderer component of this prefab
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;  // Store the initial color
            Debug.Log(gameObject.name + " initialized with original color: " + originalColor);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag)) // Check if the overlapping prefab belongs to the target set
        {
            if (IsFullyOverlapping(other))
            {
                fullyOverlappingPrefabs.Add(other.gameObject);
                UpdateColor();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            if (IsFullyOverlapping(other))
            {
                fullyOverlappingPrefabs.Add(other.gameObject);
            }
            else
            {
                fullyOverlappingPrefabs.Remove(other.gameObject);
            }
            UpdateColor();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            fullyOverlappingPrefabs.Remove(other.gameObject);
            UpdateColor();
        }
    }

    bool IsFullyOverlapping(Collider2D other)
    {
        Bounds thisBounds = GetComponent<Collider2D>().bounds;
        Bounds otherBounds = other.bounds;

        // Check if this prefab's bounds fully contain the other prefab's bounds and vice versa
        bool fullyOverlapping = thisBounds.Contains(otherBounds.min) && thisBounds.Contains(otherBounds.max);
        bool reverseOverlapping = otherBounds.Contains(thisBounds.min) && otherBounds.Contains(thisBounds.max);

        return fullyOverlapping && reverseOverlapping;
    }

    void UpdateColor()
    {
        if (fullyOverlappingPrefabs.Count > 0)
        {
            spriteRenderer.color = new Color(0.49f, 0.0f, 1.0f, 1.0f);
        }
        else
        {
            spriteRenderer.color = originalColor;
        }
    }
}
