using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float playerspeed = 9f;
    public float JumpForce = 5;
    public Transform feet;

    public bool isJumping;

    private Rigidbody2D rb;

    public LayerMask groundLayers;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {   
        Jump();

        //var movement = Input.GetAxis("Horizontal");
        //gameObject.transform.position += new Vector3(movement * Time.deltaTime * playerspeed, 0);

        gameObject.transform.position += new Vector3(Time.deltaTime * playerspeed, 0);

        isJumping = false;

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        return groundCheck != null;
    }

}
