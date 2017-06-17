using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [Header("Text")]
    [Space(10)]
    public Text title;
    public Text pickUpItem;
    public Text pressToUse;
}
