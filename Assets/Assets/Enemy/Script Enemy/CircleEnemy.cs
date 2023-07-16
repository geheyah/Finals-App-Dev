using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemy : UnitEnemy
{
    private void Start()
    {
        target = Waypoints.enemyWayPoints[0];
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(moveSpeed * Time.deltaTime * dir.normalized, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavePointIndex >= Waypoints.enemyWayPoints.Length - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        target = Waypoints.enemyWayPoints[wavePointIndex];
    }

    public void EndPath()
    {
        EnemySpawner.onEnemyDestory.Invoke();
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        maxHealth -= damage;
        if(maxHealth <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            EnemyDestory();
        }
    }

    void EnemyDestory()
    {
        EnemySpawner.onEnemyDestory.Invoke();
        Destroy(gameObject);
    }

}
