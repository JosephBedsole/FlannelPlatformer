using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float waitTime = 3;
    public float speed = 5;
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
}
