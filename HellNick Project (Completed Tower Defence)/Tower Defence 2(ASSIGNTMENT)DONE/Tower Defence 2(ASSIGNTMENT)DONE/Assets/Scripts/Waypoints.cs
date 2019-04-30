
using UnityEngine;

public class Waypoints : MonoBehaviour
{

    public static Transform[] points;

    void Awake()
    {
        // Read/checking all the waypoints index before void start
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);

        }
    }


}
