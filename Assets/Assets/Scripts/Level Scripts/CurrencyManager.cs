using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [Header("Game Manager")]
    [SerializeField] GameManager gameManager;

    public static CurrencyManager CM;
    [Range(100,500)]
    public int startingMoney;

    [Range(999,9999)]
    public int winningCondition; //This part is only for Temporary to Complet the Level

    private void Awake()
    {
        CM = this;
    }

    public void AddMoney(int ammount)
    {
        startingMoney += ammount;

        if(startingMoney >= winningCondition)
        {
            gameManager.CompleteLevel();
        }
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
