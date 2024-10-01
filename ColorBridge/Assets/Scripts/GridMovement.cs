using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float distance = 1.0f;
    // private Vector2 targetPosition;

    public float minX = 0f, minY = 0f;
    public float maxX = 10f, maxY = 10f;
    public List<GameObject> objectsToMove;

    void Start()
    {
        // targetPosition = transform.position;
    }

    void Update()
    {
        // if ((Vector2)transform.position == targetPosition)
        // {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                int checkpoint = 0;
                foreach (GameObject obj in objectsToMove){
                    Vector3 currentPosition = obj.transform.position;
                    Vector3 nextPosition = currentPosition + Vector3.up * distance;
                    if (nextPosition.y <= maxY) {}
                    else{ checkpoint=1;}
                }
                if(checkpoint==0){
                    foreach (GameObject obj in objectsToMove){
                    obj.transform.Translate(Vector2.up * distance);}
                    // Vector2 newPosition = targetPosition + Vector2.up * distance;
                    // targetPosition = newPosition;
                // if (newPosition.y <= maxY) targetPosition = newPosition;
                }
                
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                int checkpoint = 0;
                foreach (GameObject obj in objectsToMove){
                    Vector3 currentPosition = obj.transform.position;
                    Vector3 nextPosition = currentPosition + Vector3.down * distance;
                    if (nextPosition.y >= minY) {}
                    else{ checkpoint=1;}
                }
                if(checkpoint==0){
                    foreach (GameObject obj in objectsToMove){
                        obj.transform.Translate(Vector2.down * distance);}
                    // Vector2 newPosition = targetPosition + Vector2.down * distance;
                    // targetPosition = newPosition;
                }
                // Vector2 newPosition = targetPosition + Vector2.down * distance;
                // if (newPosition.y >= minY) targetPosition = newPosition;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                int checkpoint = 0;
                foreach (GameObject obj in objectsToMove){
                    Vector3 currentPosition = obj.transform.position;
                    Vector3 nextPosition = currentPosition + Vector3.left * distance;
                    if (nextPosition.x >= minX) {}
                    else{ checkpoint=1;}
                }
                if(checkpoint==0){
                    foreach (GameObject obj in objectsToMove){
                    obj.transform.Translate(Vector2.left * distance);}
                    // Vector2 newPosition = targetPosition + Vector2.left * distance;
                    // targetPosition = newPosition;
                }

                // Vector2 newPosition = targetPosition + Vector2.left * distance;
                // if (newPosition.x >= minX) targetPosition = newPosition;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                int checkpoint = 0;
                foreach (GameObject obj in objectsToMove){
                    Vector3 currentPosition = obj.transform.position;
                    Vector3 nextPosition = currentPosition + Vector3.right * distance;
                    if (nextPosition.x <= maxX) {}
                    else{ checkpoint=1;}
                }
                if(checkpoint==0){
                    foreach (GameObject obj in objectsToMove){
                    obj.transform.Translate(Vector2.right * distance);}
                    // Vector2 newPosition = targetPosition + Vector2.right * distance;
                    // targetPosition = newPosition;
                }
                // Vector2 newPosition = targetPosition + Vector2.right * distance;
                // if (newPosition.x <= maxX) targetPosition = newPosition;
            }
        // }
        // transform.position = Vector2.MoveTowards(transform.position, targetPosition, distance * 10);
    }
}
