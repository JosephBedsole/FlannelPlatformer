using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public static Inventory instance;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public int currency = 0;

    public void CurrencyUp(int amount)
    {
        currency += amount;
    }

}
