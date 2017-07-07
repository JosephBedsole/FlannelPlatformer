using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public string scene;

    public string buttonToPress = "Jump";

    public float wait = 1;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Input.GetButtonDown(buttonToPress) && (Time.time - startTime) > wait)
        {
            Debug.Log("LoadingTheScene");
            AudioManager.instance.StartCoroutine("ChangeMusicBack");
            SceneManager.LoadScene(scene);
        }
    }
}
