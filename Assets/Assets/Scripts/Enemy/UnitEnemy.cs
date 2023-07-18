using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEnemy : MonoBehaviour
{
    [Range(1f, 50f)]
    public float moveSpeed;

    [Range(10, 100)]
    public int maxHealth;

    [Header("Money Worth")]
    public int moneyWorth;

    [HideInInspector] public Transform target;
    [HideInInspector] public int wavePointIndex = 0;
    [HideInInspector] public bool isDestroyed = false;
}
