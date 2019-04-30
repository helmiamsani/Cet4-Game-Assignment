using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Enemy Speed
    public float speed = 10f;
    // Making new position of a target
    private Transform target;

    // Wavepoint Indexes
    private int wavepointIndex = 0; 

    void Start()

    {
        // Assigning target into waypoints
        target = Waypoints.points[0];
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (AllManager.Lives <= 0)
        {
            return;
        }

        //point current position to target position 
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position)<= 0.2f)
        {
            GetNextWaypoint();

        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length-1)
        {
            DecreasingLives();
            return;
          
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void DecreasingLives()
    {
        AllManager.Lives--;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullets"))
        {
            Destroy(gameObject);
            AllManager.Money += 2;
        } 
    }

}
