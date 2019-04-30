using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManagerFries : MonoBehaviour
{
    [Header("Bullets Attributes")]

    public GameObject Bullets; // Prefab to spawn when shooting
    public int bullet;
    public float timeBetweenProjectile; // delay time between the projectile spawn 
    public float countdown = 0; // the countdown
    public GameObject firePoint;
    public Transform bulletsParent;

    [Header("Enemy Attributes")]

    private Transform Enemy; // enemy object
    public string enemyTag = "Enemy";
    //public Transform partToRotate;
    public float turnSpeed = 2f;

    void Start()
    {
        InvokeRepeating("UpdateEnemy", 0f, .3f);
    }

    // Searching the enemy (From Brackeys)
    void UpdateEnemy()
    {
        // Finding all of the enemies in this array
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        // Setting this to infinity because the enemy is not within the shooting range 
        float shortestDistance = Mathf.Infinity;
        // Setting to null since the enemy is not within the shooting range
        GameObject nearestEnemy = null;

        // For each enemies that is inside the enemies array
        foreach (GameObject enemy in enemies)
        {
            // The distance between the enemy and the tower
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            // If the distance between the enemy and tower is less than the shortestdistance (distance to enemy will always be less than the shortest distance since it's infinity).
            if (distanceToEnemy < shortestDistance)
            {
                // Getting the shortestDistance of the enemy
                shortestDistance = distanceToEnemy;
                // Nearest enemy will be turn into enemy
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= FriesTowerRange.range)
        {
            Enemy = nearestEnemy.transform;
        }

        else
        {
            Enemy = null;
        }
    }

    void Update()
    {
        if (Enemy == null)
        {
            return;
        }

       // rotatingTower();

        // if the countdown less than 0
        if (countdown <= 0)
        {
            Shoot();
            // the countdown is made to the time between projectile
            countdown = timeBetweenProjectile;
        }
        // the countdown decreases itself
        countdown -= Time.deltaTime;
    }

    #region Shoot
    // Shoots a projectile in a set direction
    void Shoot()
    {
        // Spawn projectile at position of the tower
        GameObject projectile = Instantiate(Bullets, firePoint.transform.position, firePoint.transform.rotation, bulletsParent);

        // Get Rigidbody from ProjectileShooting
        ProjectileShooting bullet = projectile.GetComponent<ProjectileShooting>();

        // Shooting the bullet / projectile forward
        bullet.Fire(transform.forward);
    }
    #endregion

    // rotate the top of tower 
    public void rotatingTower()
    {
        // creating a new position so that it is able to look at the enemy position
        Vector3 enemyPosition = new Vector3(Enemy.transform.position.x, Enemy.transform.position.y, Enemy.transform.position.z);

        // Looking at or automatically rotates to the position of assign object (mroPosition/enemy position)
        transform.LookAt(enemyPosition);
    }
}
