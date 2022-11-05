using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

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

    [Header("Knockback")]
    public float KnockBackLength, KnockBackForce;
    private float KnockBackCounter;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {

        if(KnockBackCounter <= 0)
        {
            Move();
            Jump();
        }
        else
        {
            KnockBackCounter -= Time.deltaTime;
            if (!sprite.flipX)
            {
                rb2D.velocity = new Vector2(-KnockBackForce, rb2D.velocity.y); 
            }
            else
            {
                rb2D.velocity = new Vector2(KnockBackForce, rb2D.velocity.y);
            }
        }
        
    }

    public void Move()
    {
        rb2D.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb2D.velocity.y);

        if (rb2D.velocity.x < 0)
        {
            sprite.flipX = true;
        }
        else if (rb2D.velocity.x > 0)
        {
            sprite.flipX = false;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(rb2D.velocity.x));
    }

    public void Jump()
    {
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


        anim.SetBool("isGrounded", isGrounded);
    }

    public void KnockBack()
    {
        KnockBackCounter = KnockBackLength;
        rb2D.velocity = new Vector2(0f, KnockBackForce);
    }
}
