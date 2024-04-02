 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAgro : MonoBehaviour
{
    [SerializeField] Transform player; 
    [SerializeField] float agroRange; 
    [SerializeField] float moveSpeed; 
    Rigidbody2D rb2d; 

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroRange)
        {
            // code to chase player
            ChasePlayer(); 
        }
        else{
            // stop chasing player
            StopChasingPlayer();
        }
    }

    private void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            // enemy is to the left of player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
        } else if(transform.position.x > player.position.x)
        {
            // enemy is to right side of player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    private void StopChasingPlayer()
    {

    }
}
