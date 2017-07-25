using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRight : MonoBehaviour {

    public float speed = 5;

    public Animator anim;

    public ParticleSystem poofParticles;

    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        body.velocity = Vector2.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ParticleSystem pParticle = Instantiate(poofParticles);
            pParticle.Stop();
            pParticle.transform.position = transform.position;
            pParticle.Play();
            gameObject.SetActive(false);
        }
    }
}
