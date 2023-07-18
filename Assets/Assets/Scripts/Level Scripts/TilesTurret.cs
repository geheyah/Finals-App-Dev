using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TilesTurret : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color hoverColor;
    [SerializeField] private TextMeshProUGUI announceToPlayerUI;

    private GameObject turrets;
    private Color startColor;

    private void Start()
    {
        startColor = spriteRenderer.color;
    }

    private void OnMouseEnter()
    {
        spriteRenderer.color = hoverColor;
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = startColor;
    }

    private void OnMouseDown()
    {
        if(turrets != null)
        {
            return;
        }

        Tower turretBuild = BuildManager.buildManager.SelectedTurret();

        if (turretBuild.cost > CurrencyManager.CM.startingMoney)
        {
            announceToPlayerUI.text = "Not Enough Money";
            return;
        }

        CurrencyManager.CM.MinusMoney(turretBuild.cost);

        turrets = Instantiate(turretBuild.prefabs, transform.position, Quaternion.identity);
    }



}
