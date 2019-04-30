using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static Transform[] points; // Position of waypoints

    void Awake()
    {
        // assigning new positioning into waypoints
        points = new Transform[transform.childCount]; // childcount is same thing as length
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);

        }
    }


}
