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
    [SerializeField] private EnemySpawner enemySpawner;

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
        BuildTurret();
    }

    private void BuildTurret()
    {
        if (turrets != null)
        {
            return;
        }

        Tower turretBuild = BuildManager.buildManager.SelectedTurret();

        if (turretBuild.cost > CurrencyManager.CM.startingMoney)
        {
            StartCoroutine(NotifToPlayer());
            return;
        }

        CurrencyManager.CM.MinusMoney(turretBuild.cost);

        turrets = Instantiate(turretBuild.prefabs, transform.position, Quaternion.identity);
    }

    IEnumerator NotifToPlayer()
    {
        announceToPlayerUI.text = "Not Enough Money";
        yield return new WaitForSeconds(1.5f);
        announceToPlayerUI.text = " ";
    }



}
