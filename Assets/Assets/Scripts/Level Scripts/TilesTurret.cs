using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesTurret : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color hoverColor;
    //[SerializeField] private Color buildColor;

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

        GameObject turretBuild = BuildManager.buildManager.SelectedTurret();
        turrets = Instantiate(turretBuild, transform.position, Quaternion.identity);
    }



}
