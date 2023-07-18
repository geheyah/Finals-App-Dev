using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager CM;
    [Range(100,500)]
    public int startingMoney;

    private void Awake()
    {
        CM = this;
    }

    public void AddMoney(int ammount)
    {
        startingMoney += ammount;
    }

    public bool MinusMoney(int ammount)
    {
        if(ammount <= startingMoney)
        {
            startingMoney -= ammount;
            return true;
        }
        else
        {
            Debug.Log("Not Enoug Money");
            return false;
        }
    }
}
