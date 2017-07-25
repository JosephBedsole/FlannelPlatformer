using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

    public Animator deathWallAnim;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            deathWallAnim.SetTrigger("Move");

            TextController.ShowText("RUN!!!");
            TextController.WaitForInput();
            TextController.ClearText();
        }
    }

}
