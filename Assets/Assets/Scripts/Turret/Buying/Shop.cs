using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI moneyUI;

    private void OnGUI()
    {
        moneyUI.text = CurrencyManager.CM.startingMoney.ToString();

    }

    private void SetTurret()
    {

    }
}
