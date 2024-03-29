using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float JumpForce = 7f;
    private bool isJumping;
    
    private Rigidbody2D rb;

    [SerializeField] Transform feet;
    [SerializeField] LayerMask groundLayers;

    [SerializeField] Animator Animations;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    void Update()
    {
        Jump();
        if(!IsGrounded()) Animations.SetBool("Isjumping", true);
        else if(IsGrounded()) Animations.SetBool("Isjumping", false);
    }

    void Jump()
    {        
        if(Input.GetButtonDown("Jump") && IsGrounded() && !isJumping && rb.velocity.y < 10f)
        {
            rb.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);         
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 10f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 1.5f);
        }
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        return groundCheck != null;
    }

}
