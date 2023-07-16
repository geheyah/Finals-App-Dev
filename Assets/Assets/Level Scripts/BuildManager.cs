using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager buildManager;

    [Header("Turrets")]
    [SerializeField] private GameObject[] turretPrefabs;

    private int selectedTurret = 0;

    private void Awake()
    {
        buildManager = this;
    }

    public GameObject SelectedTurret()
    {
        return turretPrefabs[selectedTurret];
    }
}
