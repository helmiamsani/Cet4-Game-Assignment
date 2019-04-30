using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour {

    public float speed = 10f; // Speed of projectile
    private Rigidbody rigid;

    void Awake()
    {
        // Get refernce to Rigidbody
        rigid = GetComponent<Rigidbody>();
    }

    // Fire this projectile in a given direction
    public void Fire(Vector3 direction)
    {
        // Add force in the given direction by speed
        rigid.AddForce(direction * speed, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
            Destroy(gameObject);
    }
}
