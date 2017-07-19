using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionCollider : MonoBehaviour {

    public string scene;

    [Header("Dialogue")]
    public string dialogue1;
    public string dialogue2;
    public string dialogue3;
    public string dialogue4;
    public string dialogue5;

    bool finished = false;

    private void Start()
    {
        finished = false;
    }

    private void Update()
    {
        if (finished && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(scene);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "FinishLine")
        {
            finished = true;
            Debug.Log("I'm talking!");
            TextController.ShowText("Press E to travel to the next area!");
            TextController.WaitForInput();
        }

        if (c.gameObject.tag == "GreenNPC")
        {
            TextController.TypeText("Yo... are you just gonna stare or are you gonna buy somthing?");
            TextController.WaitForInput();
            TextController.ClearText();
            TextController.TypeText("Are you being paid to sit here and look at me?");
            TextController.WaitForInput();
            TextController.ClearText();
            TextController.ShowText("Go Away!");
            TextController.WaitForInput();
        }

        // Sign Text

        if (c.gameObject.tag == "SignOne")
        {
            TextController.ShowText("Choose Left or Right.");
            TextController.WaitForInput();
            TextController.ClearText();
            TextController.TypeText("Better choose wisely...");
            TextController.WaitForInput();
        }

        if (c.gameObject.tag == "SignTwo")
        {
            TextController.ShowText("Choose one.");
            TextController.WaitForInput();
            TextController.ClearText();
            TextController.TypeText("Good luck! :)");
            TextController.WaitForInput();
        }

        if (c.gameObject.tag == "SignThree")
        {
            TextController.ShowText("You're gonna die for sure!");
            TextController.WaitForInput();
            TextController.ClearText();
            TextController.TypeText("...");
            TextController.WaitForInput();
        }

        if (c.gameObject.tag == "TrollSign")
        {
            TextController.ShowText("Bwahahahaha!");
            TextController.WaitForInput();
            TextController.ClearText();
            TextController.TypeText("Got ya!");
            TextController.WaitForInput();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TextController.ClearText();
    }

}
