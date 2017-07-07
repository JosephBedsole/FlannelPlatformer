using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float waitTime = 3;
    public float speed = 5;

    public ParticleSystem deathExplosion;
    private Rigidbody2D body;

	void Start () {
        body = GetComponent<Rigidbody2D>();
        StartCoroutine("PatrolRoutine");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator PatrolRoutine()
    {
        while (enabled)
        {
            body.velocity = Vector2.left * speed;
            yield return new WaitForSeconds(waitTime);
            body.velocity = Vector2.right * speed;
            yield return new WaitForSeconds(waitTime);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "playerWeapon")
        {
            AudioManager.PlayVariedEffect("GotHit");

            ParticleSystem dExplosion = Instantiate(deathExplosion);
            dExplosion.Stop();
            dExplosion.transform.position = transform.position;
            dExplosion.Play();
            gameObject.SetActive(false);
        }
    }
}
