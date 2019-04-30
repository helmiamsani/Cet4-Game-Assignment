
using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 0;

    private int waveIndex = 0;   



    public void Start()
        {     
        
        }



    void Update()
    {
        if(AllManager.Lives <= 0)
        {
            return;
        }
        
        //Refer to countdown if countdown hit 0
        if (countdown <=0f)
        {
            // Starting coroutine spawn so have a delay to call up the function(add "StartCourutine" when using IEnuerator)
            StartCoroutine(SpawnWave());

            // Set countdown to timebetweenwaves when it hits 0 so it refesh to timebetweenwave value
            countdown = timeBetweenWaves;
        }
        // Set counttime to go down per sec to timedeltatime
        countdown -= Time.deltaTime;
        // UI to display countdown when spawning enemies
        //waveCoundownText.text = Mathf.Round(countdown).ToString();
    }

    // IEnumerator function so we can use "Yield return new"
    IEnumerator SpawnWave()
    {
        // Set waveindex to increase by 1 each time
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            // Spawn Enemy
            SpawnEnemy();
            // Put a delay of SpawnEnemy function of 0.5 sec then call the function
            yield return new WaitForSeconds(0.5f);

        }
    }

    void SpawnEnemy()
    {
        // Creating an object based on its position
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

    }

}
