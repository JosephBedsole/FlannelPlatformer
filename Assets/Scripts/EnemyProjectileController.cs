using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour {

    public float waitTime;
    public GameObject bullet;
    public string projectile;
    public Animator anim;

	
	void Start ()
    {
        StartCoroutine("ShootProjectile", waitTime);
        anim = GetComponent<Animator>();
	}

	void Update ()
    {
		
	}

    IEnumerator ShootProjectile(float waitTime)
    {
        while (enabled)
        {
            anim.SetTrigger("Shoot");
            yield return new WaitForSeconds(waitTime);
            GameObject thisbullet = Instantiate(bullet);
            // GameObject thisbullet = Spawner.Spawn(projectile);
            thisbullet.transform.position = transform.position;
            yield return new WaitForSeconds(waitTime);
        }
        
    }
}
