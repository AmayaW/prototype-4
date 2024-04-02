using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 
    private Vector3 targetPosition;
 
    private Transform currentPoint; 
    public float speed; 
    
    // Start is called before the first frame update
    void Start()
    {  
        targetPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the enemy has reached the target position
        if (transform.position == targetPosition)
        {
            // Switch the target position between point A and point B
            if (targetPosition == pointA.position)
            {
                targetPosition = pointB.position;
            }
            else
            {
                targetPosition = pointA.position;
            }
        }
    }
}
