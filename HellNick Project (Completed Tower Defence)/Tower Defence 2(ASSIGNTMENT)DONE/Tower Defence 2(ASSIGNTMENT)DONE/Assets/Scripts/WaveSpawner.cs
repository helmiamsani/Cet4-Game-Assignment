
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

using System.Linq;

[System.Serializable]
public struct Wave
{
    public int enemyCount;
    public float spawnRate;
    public float enemyHealth;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Enemy enemy;
    public GameObject enemyPrefab;//Assign spawn enemy prefab
    public Transform spawnPoint;//spawn pos
    public int waveIndex = 0;
    public static int money;
    public static int lives;
    public float timeBetweenWaves = 0f;//spawn interval
    public GameObject deadPanel;
    public GameObject wavePanel;
    private float countdown = 0f;//initial countdown timer
    
    public int maxMoney = 300;
    public int minMoney= 0;
    //private List<Enemy> spawnedEnemies = new List<Enemy>();
    public int spawnedEnemies = 0;
    public bool canSpawnEnemies = true;
    public int waveStop = 4;
    [Header("text")]
    public Text numEnemies;
    public Text _money;
    public Text _lives;
    public Text waveCoundownText;//create countdown text
    public void Start()
    {
        //countdown = timeBetweenWaves;
        Debug.Log("Wave Incoming SIR!");
        StartNextWave();
        money = 60;
        lives = 5;
        
        
    }

    void StartNextWave()
    {
        
        Wave currentWave = waves[waveIndex];
        StartCoroutine(SpawnEnemies(currentWave.enemyCount, currentWave.spawnRate));
        
        
       
    }

    void Update()
    {
        //spawnedEnemies = spawnedEnemies.Where(item => item != null).ToList();
        //if(spawnedEnemies.Count == 0)
        //{
        //    // Wave is over!
        //}
        
        
        if (spawnedEnemies == 0)
        {
            
            print("NO MORE ENEMIES!!!");
            if(canSpawnEnemies)
            {
                
                print("You can now spawn Enemies!");
                StartNextWave();
                countdown = timeBetweenWaves;
            }
        }

        countdown += Time.deltaTime;//countdown decreasing +1sec overtime
        //Display Countdown number as string
        waveCoundownText.text = Mathf.Round(countdown).ToString();
        numEnemies.text = spawnedEnemies.ToString();
        _money.text = money.ToString();
        _lives.text = lives.ToString();
        if(lives<=0)
        {
            deadPanel.SetActive(true);
            Time.timeScale = 0f;
            

        }
        money = Mathf.Clamp(money, minMoney, maxMoney);
    }
    
    IEnumerator SpawnEnemies(int amount, float spawnRate)
    {
        
        canSpawnEnemies = false;
        wavePanel.SetActive(false);
        for (int i = 0; i < amount; i++)
        {
            SpawnEnemy();
            //wait 0.5 sec before calling the function
            yield return new WaitForSeconds(spawnRate);
        }
        waveIndex++;
        wavePanel.SetActive(true);
        yield return new WaitForSeconds(waveStop);//Stop between Waves

        canSpawnEnemies = true;
    }

    void SpawnEnemy()
    {
        // Spawn enemy clone from enemyPrefab
        GameObject clone = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        // Get enemy script from clone
        Enemy enemy = clone.GetComponent<Enemy>();
        // Add enemy script to list
        //spawnedEnemies.Add(enemy);
        enemy.startHealth = waves[waveIndex].enemyHealth;
       
       

        enemy.owner = this; // Tell the Enemy that I own it. 
        spawnedEnemies++; // I've spawned one more enemy!

    }
}
