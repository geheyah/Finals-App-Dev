using Kino;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private float spawnPerSecMultipleEnemeis;
    [Header("Time before Next Wave")]
    [Range(4f, 6f)]
    [SerializeField] private float startWaveIn;

    [HideInInspector]
    [SerializeField] private float nextWaveIn;

    [Header("Scaling Factor")]
    [Range(0.1f , 1f)]
    [SerializeField] private float difficultyFactor;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI waveLevel;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject[] enemyPrefabs;

    private int currentWave = 0;
    private float timeSincelastSpawn;
    private int aliveEnemies;
    private float enemiesPerS;
    private int enemiesLeftForSpawn;
    private bool isSpawning = false;

    private void Awake()
    {
        onEnemyDestory.AddListener(DestroyedEnemy);
    }

    private void OnGUI()
    {
        waveLevel.text = currentWave.ToString();
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        Timer();

        if (!isSpawning)
        {
            return;
        }

        timeSincelastSpawn += Time.deltaTime;

        if(timeSincelastSpawn >= (1f / enemiesPerS) && enemiesLeftForSpawn > 0) 
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

    private void Timer()
    {
        if(nextWaveIn > 0)
        {
            nextWaveIn -= Time.deltaTime;

        }
        else
        {
            nextWaveIn = 0;
        }
        DisplayTime(nextWaveIn);
    }

    private void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0}",seconds);

    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(nextWaveIn);
        isSpawning = true;
        enemiesLeftForSpawn = EnemyPerWave();
        enemiesPerS = EnemyPerSecond();

    }

    private int EnemyPerWave()
    {
        return Mathf.RoundToInt(enemiesSpawn * Mathf.Pow(currentWave, difficultyFactor));
    }

    private float EnemyPerSecond()
    {
        return Mathf.Clamp(spawnPerSec * Mathf.Pow(currentWave, 
            difficultyFactor),0,spawnPerSecMultipleEnemeis);
    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[index], enemySpawnPoint.position, Quaternion.identity);
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
        nextWaveIn = startWaveIn;
        StartCoroutine(StartWave());
    }
}
