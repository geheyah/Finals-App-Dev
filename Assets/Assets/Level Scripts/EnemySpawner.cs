using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("Events")]
    public static UnityEvent onEnemyDestory = new UnityEvent();

    [Header("Spawn Point")]
    public Transform enemySpawnPoint;

    [Header("Total Spawn on Wave")]
    [SerializeField] private int enemiesSpawn;
    [Header("Spawn per Second")]
    [SerializeField] private float spawnPerSec;
    [Header("Time before Next Wave")]
    [Range(1f, 5f)]
    [SerializeField] private float nextWaveIn;
    [Header("Scaling Factor")]
    [Range(0.1f , 1f)]
    [SerializeField] private float difficultyFactor;

    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    private int currentWave = 1;
    private float timeSincelastSpawn;
    private int aliveEnemies;
    private int enemiesLeftForSpawn;
    private bool isSpawning = false;

    private void Awake()
    {
        onEnemyDestory.AddListener(DestroyedEnemy);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning)
        {
            return;
        }

        timeSincelastSpawn += Time.deltaTime;

        if(timeSincelastSpawn >= (1f / spawnPerSec) && enemiesLeftForSpawn > 0) 
        {
            SpawnEnemy();
            enemiesLeftForSpawn--;
            aliveEnemies++;
            timeSincelastSpawn = 0f;
        }

        if(aliveEnemies == 0 && enemiesLeftForSpawn == 0)
        {
            EndWave();
        }
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(nextWaveIn);
        isSpawning = true;
        enemiesLeftForSpawn = EnemyPerWave();

    }

    private int EnemyPerWave()
    {
        return Mathf.RoundToInt(enemiesSpawn * Mathf.Pow(currentWave, difficultyFactor));
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefabs[0], enemySpawnPoint.position, Quaternion.identity);
    }

    public void DestroyedEnemy()
    {
        aliveEnemies--;
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSincelastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }




}
