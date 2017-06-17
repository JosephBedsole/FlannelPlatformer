using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10;


    [Header("Jumping")]
    public float jumpForce = 1;
    public int maxJumpCount = 2;
    public int jumpCount = 2;

    bool onGround = true;

    private Rigidbody2D body;
    private Animator anim;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        body.velocity = new Vector2( (x * speed), body.velocity.y);

        JumpRoutine();
        Grounded();
    }

    void JumpRoutine()
    {               
        if (Input.GetKeyDown(KeyCode.Z) && onGround == true)
        {
            Debug.Log("I'm Jumping!");
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (jumpCount == 0)
            {
                onGround = false;
            }
            
        }        
    }

    void Grounded()
    {
        if (body.velocity.y == 0)
        {
            onGround = true;
        }
    }

}
