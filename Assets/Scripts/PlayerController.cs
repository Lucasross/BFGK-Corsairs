using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 10f;

    public float limitY = 4f;
    public float limitX = 6f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
  
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");       
        horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput, verticalInput) * speed ;

        if (transform.position.y < -limitY && verticalInput < 0)
            rb.velocity = rb.velocity * Vector2.right;
       
        if (transform.position.y > limitY && verticalInput > 0)
            rb.velocity = rb.velocity * Vector2.right;
        
        if (transform.position.x < -limitX && horizontalInput < 0)
            rb.velocity = rb.velocity * Vector2.up;
        
        if (transform.position.x > limitX && horizontalInput > 0)
            rb.velocity = rb.velocity * Vector2.up;  
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(new Vector3(limitX, 0, 0), Vector3.one);
        Gizmos.DrawWireCube(new Vector3(-limitX, 0, 0), Vector3.one);

        Gizmos.DrawWireCube(new Vector3(0, limitY, 0), Vector3.one);
        Gizmos.DrawWireCube(new Vector3(0, -limitY, 0), Vector3.one);
    }
}
