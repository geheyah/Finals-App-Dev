using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] enemyWayPoints;

    private void Awake()
    {
        enemyWayPoints = new Transform[transform.childCount];
        for(int i = 0; i < enemyWayPoints.Length; i++)
        {
            enemyWayPoints[i] = transform.GetChild(i);
        }
    }
}
