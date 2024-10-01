using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float distance = 1.0f;
    private Vector2 targetPosition;
    public LayerMask tileLayer;
    public TextMeshProUGUI endText;

    public float minX = 0f, minY = 0f;
    public float maxX = 10f, maxY = 10f;

    void Start()
    {
        targetPosition = transform.position;
        endText.gameObject.SetActive(false);
    }

    void Update()
    {
        if ((Vector2)transform.position == targetPosition)
        {
            Vector2 newPosition = targetPosition;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                newPosition += Vector2.up * distance;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                newPosition += Vector2.down * distance;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                newPosition += Vector2.left * distance;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                newPosition += Vector2.right * distance;
            }

            if (newPosition.x >= minX && newPosition.x <= maxX &&
                newPosition.y >= minY && newPosition.y <= maxY &&
                IsValidTile(newPosition))
            {
                targetPosition = newPosition;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, distance * 10);
            }
        }
    }

    bool IsValidTile(Vector2 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero, 0.1f, tileLayer);

        if (hit.collider != null)
        {
            SpriteRenderer tileRenderer = hit.collider.GetComponent<SpriteRenderer>();

            if (tileRenderer != null)
            {
                Color tileColor = tileRenderer.color;
                if (tileColor == Color.green || tileColor == Color.yellow || tileColor == new Color(0.49f, 0.0f, 1.0f, 1.0f))
                {
                    if (tileColor == Color.green && endText != null)
                    {
                        endText.gameObject.SetActive(true);
                    }
                    return true;
                }
            }
        }
        return false;
    }
}
