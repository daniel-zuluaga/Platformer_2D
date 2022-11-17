using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    public float moveSpeed;

    public Transform leftPoint, rightPoint;

    private bool movingRight = false;

    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Animator anim;
    public BoxCollider2D coll2D;

    public float moveTime, waitTime;
    private float moveCount, waitCount;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            if (movingRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

                sprite.flipX = true;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

                sprite.flipX = false;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

            if (moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * 1f, waitTime * 2f);
            }

            anim.SetBool("isMoving", true);
        }
        else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            rb.velocity = new Vector2(0f, rb.velocity.y);

            if (waitCount <= 0)
            {
                moveCount = Random.Range(moveCount * 12f, waitTime * 4f);
            }

            anim.SetBool("isMoving", false);
        }
    }
}
