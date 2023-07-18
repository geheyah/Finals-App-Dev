using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager buildManager;

    [Header("Turrets")]
    [SerializeField] private Tower[] towers;

    private int selectedTurret = 0;

    private void Awake()
    {
        buildManager = this;
    }

    public Tower SelectedTurret()
    {
        return towers[selectedTurret];
    }

    public void SelectedTurrer(int _selctedTurret)
    {
        selectedTurret = _selctedTurret;
    }
}
