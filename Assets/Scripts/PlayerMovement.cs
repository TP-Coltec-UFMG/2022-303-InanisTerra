using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    public float JumpForce = 7f;
    private bool isJumping;
    
    private Rigidbody2D rb;
    
    public Transform feet;
    public LayerMask groundLayers;
    
    [SerializeField] private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;

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
        if(Input.GetButtonDown("Jump")){
            jumpBufferCounter = jumpBufferTime;
        } else {
            jumpBufferCounter -= Time.deltaTime;
        }
        
        if(jumpBufferCounter > 0f && IsGrounded() && !isJumping)
        {
            rb.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);

            jumpBufferCounter = 0f;            
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
