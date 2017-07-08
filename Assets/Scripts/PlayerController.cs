using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10;
    public float x;

    [Header("Jumping")]
    public float jumpForce = 1;
    public int maxJumpCount = 2;
    public int jumpCount = 2;
    public GameObject playerWeapon;
    public ParticleSystem deathParticle;
    public SceneTransition callGameOver;

    bool facingRight = true;
    bool onGround = true;
    bool invincible = false;
    bool dead = false;

    private Rigidbody2D body;
    private Animator anim;
    private HealthController health;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<HealthController>();
        health.onHealthChanged += AnimateHealth;

        //AudioManager.CrossfadeMusic(AudioManager.instance.music2, 1);
        AudioManager.instance.StartCoroutine("ChangeMusic2");
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        body.velocity = new Vector2( (x * speed), body.velocity.y);
        JumpRoutine();
        Grounded();
        CameraFollow();

        float xSpeed = body.velocity.magnitude;
        if(onGround) // Move the CharacterFlip function out of the if(statement) and change the statement to (onGround && jumpCount < maxJumpCount);
        {
            anim.SetFloat("XVelocity", xSpeed);
            CharacterFlip(x);
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            playerWeapon.transform.position = body.transform.position;
            anim.SetTrigger("Attack");
            StartCoroutine("AttackRoutine");
            
        }
    }

    void AnimateHealth(float health, float prevHealth, float maxHealth)
    {
        if (health <= 0 && prevHealth > 0)
        {
            // anim.SetTrigger("Dying");
            // AudioManager.CrossfadeMusic(AudioManager.instance.music3, 1);

            DeathCheck();
            gameObject.SetActive(false);
        }
        else if (health < prevHealth && prevHealth > 0)
        {
            // anim.SetTrigger("TookHit");
        }
    }

    void JumpRoutine()
    {               
        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            Debug.Log("I'm Jumping!");
            AudioManager.PlayVariedEffect("Jump");
            anim.SetTrigger("Jump");
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            --jumpCount;
            if (jumpCount == 0)
            {
                onGround = false;
            }        
        }        
    }

    public void WalkSound()
    {
        Debug.Log("Step");
        AudioManager.PlayVariedEffect("footsteps");
    }

    void DeathCheck()
    {
        GameManager.instance.gameOver.gameObject.SetActive(true);
        AudioManager.instance.StartCoroutine("ChangeMusic3");
        ParticleSystem dParticle = Instantiate(deathParticle);
        dParticle.Stop();
        dParticle.transform.position = transform.position;
        dParticle.Play();
        Debug.Log("Blaaaaaaah");
    }

    void CharacterFlip(float x)
    {
        if (x > 0 && !facingRight)
        {
            facingRight = !facingRight;

            transform.right = Vector3.right;
        }
        else if (x < 0 && facingRight)
        {
            facingRight = !facingRight;

            transform.right = -Vector3.right;
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

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Ground")
        {
            AudioManager.PlayVariedEffect("HitGround");
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    { // Enemy Trigger Events
        if (c.gameObject.tag == "Enemy")
        {
            if (!invincible)
            {
                StartCoroutine("InvincibilityFrames");
                health.TakeDamage(2);
                AudioManager.PlayEffect("GotHit");
            }
        }

        if (c.gameObject.tag == "Spikes")
        {
            if (!invincible)
            {
                StartCoroutine("InvincibilityFrames");
                health.TakeDamage(2);
                AudioManager.PlayEffect("GotHit");
            }
        }

        if (c.gameObject.tag == "EnemyProjectile")
        {
            if (!invincible)
            {
                StartCoroutine("InvincibilityFrames");
                health.TakeDamage(2);
                AudioManager.PlayEffect("GotHit");
            }
        }

        // Object Trigger Events
        if (c.gameObject.tag == "Coin")
        {
            Inventory.instance.CurrencyUp(2);
            AudioManager.PlayEffect("Pick-up Coin");
        }
        
        if (c.gameObject.tag == "FinishLine")
        {
            GameManager.instance.FinishLine.gameObject.SetActive(true);
        }

        if (c.gameObject.tag == "FallDeath")
        {
            DeathCheck();
            gameObject.SetActive(false);
        }

    }

    IEnumerator InvincibilityFrames()
    {
        invincible = true;
        // Blinking animation Play()
        yield return new WaitForSeconds(1);
        // Blinking animation Stop()
        invincible = false;
    }

    IEnumerator AttackRoutine()
    {
        playerWeapon.gameObject.SetActive(true);
        yield return new WaitForSeconds(.2f);
        playerWeapon.gameObject.SetActive(false);
    }
}
