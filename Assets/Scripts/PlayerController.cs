using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    public float playerSpeed;
    float xInput = 0.0f;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();                    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x < Screen.width/2)
            {
                xInput = -1.0f;
            }
            else
            {
                xInput = 1.0f;
            }
        }
        else
        {
            xInput = 0.0f;
        }

        rb.AddForce(transform.right * playerSpeed * xInput);
    }

    void FlipPlayer()
    {
        if(rb.velocity.x <0)
        {
            sprite.flipX =true;
        }
        else if(rb.velocity.x >0)
        {
            sprite.flipX = false;
        }
    }
}
