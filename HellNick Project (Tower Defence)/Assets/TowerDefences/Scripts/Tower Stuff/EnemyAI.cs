using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float moveHorizontal = 10f; // Horizontal movement variable
    public float moveVertical = 10f; // Vertical movement variable

    public Vector3 moveDirection;

    // Controlling the player
    void Control()
    {
        float z = 0;
        if (Input.GetButton("Up"))
        {
            z += moveHorizontal;
        }
        if (Input.GetButton("Down"))
        {
            z -= moveHorizontal;
        }

        float x = 0;
        if (Input.GetButton("Left"))
        {
            x -= moveVertical;
        }
        if (Input.GetButton("Right"))
        {
            x += moveVertical;
        }

        GetComponent<Rigidbody>().AddForce(x, 0, z);
    }


	// Update is called once per frame
	void Update ()
    {
        Control(); // Control method is called
	}
}
