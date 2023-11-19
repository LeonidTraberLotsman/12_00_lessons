using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spawner : MonoBehaviour
{

    public GameObject prefab;

    public Transform player;

    void SpawnOne()
    {
        GameObject new_one = Instantiate(prefab);
        new_one.transform.position = transform.position + new Vector3(Random.RandomRange(-20f, 20f), 0, Random.RandomRange(-20f, 20f));

        new_one.GetComponent<dog>().player = player;
        //StartCoroutine(Move(new_one));
        // hello man< I am glat that you can read it
    }

    IEnumerator Move(GameObject one)
    { 

            NavMeshAgent agent = one.GetComponent<NavMeshAgent>();

        for (int i = 0; i < 3; i++)
        {
            Vector3 point = new Vector3(Random.RandomRange(-20f, 20f), 0, Random.RandomRange(-20f, 20f));
            agent.destination = point;
            while (Vector3.Distance(point, one.transform.position) > 2)
            {
                yield return new WaitForSeconds(1);
            }
        }
        Destroy(one);
    }
    IEnumerator MassiveSpawn()
    {
        while (true)
        {
            SpawnOne();
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Start()
    {
        StartCoroutine(MassiveSpawn());
    }

}
