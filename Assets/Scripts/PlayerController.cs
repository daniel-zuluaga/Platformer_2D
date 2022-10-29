using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Date Player")]  
    public float moveSpeed;
    public float forceJump;
    public bool canDoubleJump;

    [Header("Components")]
    public Rigidbody2D rb2D;
    public Animator anim;
    public SpriteRenderer sprite;

    [Header("Grounded")]

    private bool isGrounded;
    public Transform GroundCheckpoint;
    public LayerMask groundMask;

    void Start()
    {
        
    }

    void Update()
    {
        rb2D.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb2D.velocity.y);

        isGrounded = Physics2D.OverlapCircle(GroundCheckpoint.position, .05f, groundMask);

        if (isGrounded)
        {
            canDoubleJump = true; 
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, forceJump); 
            }
            else
            {
                if (canDoubleJump)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, forceJump);
                    canDoubleJump = false;
                }
            }
        }

        if(rb2D.velocity.x < 0)
        {
            sprite.flipX = true;
        }else if(rb2D.velocity.x > 0)
        {
            sprite.flipX = false;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(rb2D.velocity.x));
        anim.SetBool("isGrounded", isGrounded); 
    }
}
