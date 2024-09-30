using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float distance = 1.0f;
    private Vector2 targetPosition;

    public float minX = 0f, minY = 0f;
    public float maxX = 10f, maxY = 10f;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if ((Vector2)transform.position == targetPosition)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Vector2 newPosition = targetPosition + Vector2.up * distance;
                if (newPosition.y <= maxY) targetPosition = newPosition;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Vector2 newPosition = targetPosition + Vector2.down * distance;
                if (newPosition.y >= minY) targetPosition = newPosition;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Vector2 newPosition = targetPosition + Vector2.left * distance;
                if (newPosition.x >= minX) targetPosition = newPosition;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector2 newPosition = targetPosition + Vector2.right * distance;
                if (newPosition.x <= maxX) targetPosition = newPosition;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, distance * 10);
    }
}
