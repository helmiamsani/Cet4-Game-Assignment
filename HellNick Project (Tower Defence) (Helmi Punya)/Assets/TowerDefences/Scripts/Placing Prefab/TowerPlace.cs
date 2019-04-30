using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour {

    public bool noTower = true; // true since no tower sitting on the tops

    // placing the tower
    public Vector3 PlacingTheTower()
    {
        return transform.position; // getting the position of each tops
    }
}
