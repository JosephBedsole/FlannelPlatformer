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

    bool dead = false;

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
        CameraFollow();

    }

    void JumpRoutine()
    {               
        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            Debug.Log("I'm Jumping!");
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            --jumpCount;
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
            jumpCount = maxJumpCount;
        }
    }

    void CameraFollow()
    {
        Vector3 offsetZ = new Vector3(0, 0, -10);

        Vector2 offset = new Vector2 (3, 0);
        Vector2 negativeoffset = new Vector2(-3, 0);
        
        Camera.main.transform.position = body.transform.position + offsetZ;

        /*if (body.velocity.x <= 0)
        {
            Camera.main.transform.position = mathf.Lerp(body.transform.position + offsetZ, offset, Time.deltaTime);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D c)
    { // Enemy Trigger Events
        if (c.gameObject.tag == "Enemy")
        {
            GameManager.instance.gameOver.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        // Object Trigger Events
        if (c.gameObject.tag == "Coin")
        {
            Inventory.instance.CurrencyUp(2);
        }

    }
}
