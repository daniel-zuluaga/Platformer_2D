using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Date Player")]  
    public float moveSpeed;
    public float forceJump;

    [Header("Components")]
    public Rigidbody2D rb2D;

    void Start()
    {
        
    }

    void Update()
    {
        rb2D.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, forceJump);
        }
    }
}
