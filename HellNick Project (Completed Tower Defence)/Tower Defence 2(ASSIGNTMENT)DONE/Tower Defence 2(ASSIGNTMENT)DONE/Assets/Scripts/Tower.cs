using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform target; //Target position

    [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float range = 15f; // Tower range

    [Header("Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public int damageOverTime = 4;

    [Header("Unity Setup Field")]
    public string enemyTag = "Enemy"; // enemy Tag
    public float rotateSpeed = 10f; //cannon rotate speed
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;


    void Start()
    {
        //calling the UpdateTarget 0f=start at beginning,0.5f= 2 times in 1 sec
        InvokeRepeating("UpdateTarget", 0f, 0.5f);  
    }
    void UpdateTarget()
    {
        //store GameObject arrays as enemies and find the enemytags(plural)
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;// set it to infinite range
        GameObject nearestEnemy = null;
        
        foreach (GameObject enemy in enemies)//find our gameobject arrays tagged enemies
        {
            //find distance between local pos and target pos.
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;//set the nearest enemy
            }                  
        }
        //if our enemy is not null and within within range
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;//assign as our enemy
        }
        else
        {
            //reset to find new enemy
            target = null;
        }
    }

    void Update()

    {   // if we found no enemy then we dont do anything
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }
            return;
            
        }
        LockOnTarget();
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1f / fireRate;

            }
            fireCountdown -= Time.deltaTime;

        }
        

    }

    void LockOnTarget()
    { // get a vector(arrow) that point to our target (direction)
        Vector3 dir = target.position - transform.position;
        //assign look direction as quarternion(how do we want to look)at target
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Using lep to smooth the movement(our local position, lookrotation(direction), time * speed) as uelerangles
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        //set our rotation at Y axis only.
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    void Shoot ()
    {

        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
                
    }
    void Laser()
    {
        target.GetComponent<Enemy>().TakeDamage(damageOverTime * Time.deltaTime);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }
    void OnDrawGizmosSelected() // Draw Range on selected object 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
 