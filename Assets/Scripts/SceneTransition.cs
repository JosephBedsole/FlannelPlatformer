using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    [Header("Return To Title")]
    public string scene;
    public string buttonToPress = "Jump";

    [Header("Return To Title")]
    public string currentScene;
    public string buttonToMash = "Fire1";

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
            if (scene == "1 Forest Level")
            {
                AudioManager.instance.StartCoroutine("ChangeMusic2");
            }
            SceneManager.LoadScene(scene);
        }

        if (Input.GetButtonDown(buttonToMash) && (Time.time - startTime) > wait)
        {
            Debug.Log("LoadingTheScene");
            AudioManager.instance.StartCoroutine("ChangeMusic2");
            SceneManager.LoadScene(currentScene);
        }
    }
}
