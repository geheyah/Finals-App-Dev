using UnityEngine;
using System.Collections;
using UnityEditor;

public class Turret : MonoBehaviour 
{
    [Header("Needed Objects")]
    [SerializeField] private LayerMask enemyMask;

    [Header("Range")]
    [SerializeField] private float turretRange;
    [Header("Rotate Speed")]
    [SerializeField] private float turretRotationSpeed;
    [Header("Spawn Bullet")]
    [SerializeField] private Transform spawnBullet;
    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;

    [Header("Use Bullets (default)")]
    public float fireRate;
    private float fireCountdown;

    private Transform target;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        AimAtTarget();
        if (!TargetNotInRange())
        {
            target = null;
        }
        else
        {
            fireCountdown += Time.deltaTime;
            if(fireCountdown >= 1f / fireRate)
            {
                Shoot();
                fireCountdown = 0;
            }
        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, turretRange,
            (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private void AimAtTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y,
            target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,
            turretRotationSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private bool TargetNotInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= turretRange;
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, turretRange);
    }
}
