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

    public GameObject blackScreen;

    [Header("Text")]
    [Space(10)]
    public Text title;
    public Text pickUpItem;
    public Text pressToUse;
    public Text FinishLine;
    public Text gameOver;
    public Text returnToMenu;
    public Text playAgain;
    public Text currency;

    private void Start()
    {
        currency.font.material.mainTexture.filterMode = FilterMode.Point;
    }

    void Update()
    {
        currency.text = "x " + Inventory.instance.currency;
    }

    IEnumerator GameOverRoutine()
    {

        yield return new WaitForEndOfFrame();
    }
}
