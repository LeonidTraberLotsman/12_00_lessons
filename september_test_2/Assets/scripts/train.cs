using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train : MonoBehaviour
{

    public List<Transform> points = new List<Transform>(); 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Patrol());
    }
    IEnumerator Patrol()
    {
        int station = 0;
        while (true)
        {
            yield return Move(transform.position, points[station].position, 60);
            station = station + 1;
        }
    }

    IEnumerator Move(Vector3 A,Vector3 B, int t)
    {
        Vector3 S = B - A;
        Vector3 v = S / t;
        for (int i = 0; i < t; i++)
        {
            transform.position = A + v * i;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
