
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float speed = 50f;
    
    public float health;
    
    public float startHealth;
    private int enemyBounty = 4;
    private Transform target; //assign waypoint as target
    private int wavepointIndex = 0;
    private float healthRandom;
    
    public WaveSpawner owner; // Record who spawned mec
    public Image healthBar;

    void Start()
    {
        //healthRandom = Random.Range(1f, 2f);
        //startHealth = startHealth + healthRandom;
        //set target to the 1st waypoint
        target = Waypoints.points[0];
        health = startHealth;

        
        
    }

    public void TakeDamage(float amount)
    {
       
       health -= amount;
        healthBar.fillAmount = health / startHealth;
        if ( health <=0)
        {
            WaveSpawner.money += enemyBounty;
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void OnDestroy()
    {
        owner.spawnedEnemies--; // Reduce count cos I died.
    }

    void Update()
    {
        //point current position to target position 
        Vector3 dir = target.position - transform.position;
        //Make enemy move
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //ask enemy to get to the next way point if within 0.2f range
        if(Vector3.Distance(transform.position, target.position)<= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        //waypoint (0=12index total 13) if the waypointindex(12 > 13-1=12) = DESTROY
        if (wavepointIndex >= Waypoints.points.Length-1)
        {
            //destroy the enemy
            Destroy(gameObject);
            WaveSpawner.lives-= 1;
            return;          
        }
        wavepointIndex++; // add increament by 1
        target = Waypoints.points[wavepointIndex];//getting next waypoint index
    }
    
}
