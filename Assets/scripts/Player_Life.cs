using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    //checking vertical offset threshold for top collision jump = player kills enemy
    public float topCollisionThreshold = 0.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 hit = collision.contacts[0].normal;
            float hitAngle = Vector3.Angle(hit, Vector3.up);
            float verticalDifference = transform.position.y - collision.transform.position.y;

            // Log collision details to understand the nature of the collision
            Debug.Log($"Collision normal: {hit}, Angle: {hitAngle}, Vertical Difference: {verticalDifference}");

            if (Mathf.Abs(hitAngle) < 90 && verticalDifference > topCollisionThreshold)
            {
                Debug.Log("Player killed the enemy by jumping on top.");
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log("Player died due to side collision with enemy.");
                Die();
            }
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
