using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed = 5;
    public bool shootLeft = true;

    public Animator anim;

    private Rigidbody2D body;


    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (shootLeft)
        {
            body.velocity = Vector2.left * speed;
        }
        else
        {
            body.velocity = Vector2.right * speed;
        }
    }

}
