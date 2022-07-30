using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 10f;

    public float limitY = 4f;
    public float limitYNeg;
    public float limitX = 6f;

    public Transform masterCharacter;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontalInput, verticalInput) * speed;

        if (transform.position.y < limitYNeg + masterCharacter.position.y)
            rb.position = new Vector2(rb.position.x, masterCharacter.position.y + limitYNeg);

        if (transform.position.y < limitYNeg + masterCharacter.position.y && verticalInput < 0) { }
            rb.velocity = rb.velocity * Vector2.right;
   
        if (transform.position.y > limitY + masterCharacter.position.y && verticalInput > 0)
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
        Gizmos.DrawWireCube(new Vector3(0, limitYNeg, 0), Vector3.one);
    }
}
