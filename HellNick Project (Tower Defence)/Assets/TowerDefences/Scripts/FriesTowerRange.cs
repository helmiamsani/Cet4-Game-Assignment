using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriesTowerRange : MonoBehaviour {

    public static float range = 2.35f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
