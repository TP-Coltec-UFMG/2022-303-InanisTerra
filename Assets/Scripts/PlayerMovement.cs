using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{

    //private float playerspeed = 9f;
    public float JumpForce = 5;
    public Transform feet;
    private bool isJumping;
    private bool isAttacking;
    private Rigidbody2D rb;
    public LayerMask groundLayers;
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
        if(IsGrounded()) Animations.SetBool("Isjumping", false);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded() && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        else {
            isJumping = false;
        }
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        return groundCheck != null;
    }

}
