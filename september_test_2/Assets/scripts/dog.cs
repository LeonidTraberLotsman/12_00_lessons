using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dog : damage_getter 
{

    NavMeshAgent agent;

    public List<Transform> points;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //StartCoroutine(Move(new Vector3(Random.Range(1,5),0,Random.Range(5,10))));
        //StartCoroutine(Patrol());
        StartCoroutine(Catch_player());
        //points.Add());


    }

    IEnumerator Catch_player( )
    {
        
        while (true)
        {
            agent.destination =  player.transform.position;
            yield return null;
        }
    }

    IEnumerator Move(Vector3 point)
    {
        agent.destination = point;
        while (Vector3.Distance(transform.position, point) > 2)
        {
            yield return null;
        }
    }

    IEnumerator Patrol() {
        foreach (Transform point in points)
        {
            yield return Move(point.position);
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
