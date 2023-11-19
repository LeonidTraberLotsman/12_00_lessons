using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spawner : MonoBehaviour
{

    public GameObject prefab;

    void SpawnOne()
    {
        GameObject new_one = Instantiate(prefab);
        new_one.transform.position = transform.position + new Vector3(Random.RandomRange(-20f, 20f), 0, Random.RandomRange(-20f, 20f));
        StartCoroutine(Move(new_one));

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
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void Start()
    {
        StartCoroutine(MassiveSpawn());
    }

}
