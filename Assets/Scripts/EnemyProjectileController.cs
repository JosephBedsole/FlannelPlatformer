using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour {

    public float waitTime;
    public GameObject bullet;
	
	void Start ()
    {
        StartCoroutine("ShootProjectile", waitTime);
	}

	void Update ()
    {
		
	}

    IEnumerator ShootProjectile(float waitTime)
    {
        while (enabled)
        {
            GameObject thisbullet = Instantiate(bullet);
            thisbullet.transform.position = transform.position;
            yield return new WaitForSeconds(waitTime);
        }
        
    }
}
