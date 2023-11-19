using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bodyMove : MonoBehaviour
{
    Rigidbody body;
    public int speed_modificator = 1;

    public int hp = 30;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void GetDamage(int dam)
    {
        hp = hp - dam;
        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(transform.forward*speed_modificator);
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(-transform.forward * speed_modificator);
        }

        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(transform.right * speed_modificator);
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(-transform.right * speed_modificator);
        }
    }
}
