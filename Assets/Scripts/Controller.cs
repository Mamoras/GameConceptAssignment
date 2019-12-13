using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer renderer;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();

    }


    private void FixedUpdate()
    {

        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }


        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(2, rb.velocity.y);
            if(isGrounded)
                animator.Play("Player_Run");
            renderer.flipX = false;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(5, rb.velocity.y);
            }
        }        
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-2, rb.velocity.y);
            if(isGrounded)
                animator.Play("Player_Run");
            renderer.flipX = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(-5, rb.velocity.y);
            }
        }
        else
        {
            if(isGrounded)
                animator.Play("Player_Idle");
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey("space") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 5);
            animator.Play("Player_Jump");
        }

    }

}
