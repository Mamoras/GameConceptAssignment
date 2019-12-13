using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();

    }


    private void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(2, 0);
        }        
        else if(Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-2, 0);
        }
    }

}
