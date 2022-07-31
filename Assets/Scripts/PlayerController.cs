using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 10f;
    public float runFactor = 1.5f;

    private Rigidbody2D rb;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        bool run = Input.GetButton("Fire3");

        if (run)
            rb.velocity = new Vector2(horizontalInput, verticalInput) * speed * runFactor;
        else    
            rb.velocity = new Vector2(horizontalInput, verticalInput) * speed;

        if (run)
            anim.speed = 2;
        else
            anim.speed = 1;

        anim.SetBool("Moving", rb.velocity.magnitude != 0);
    }
}
