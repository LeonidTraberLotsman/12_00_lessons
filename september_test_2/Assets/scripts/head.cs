using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{
    public Transform PlayerBody;
    float xRotation = 0;

    public float MouseSensivity = 1;

    void Start()
    {
       
    }
   
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*MouseSensivity;
        float mouseY = Input.GetAxis("Mouse Y")*MouseSensivity;

        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        PlayerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward,out hit))
            {
                Debug.Log(hit.transform.name);
                damage_getter dg = hit.transform.GetComponent<damage_getter>();

                if (dg != null)
                {
                    dg.GetDamage(5);
                }

                Rigidbody body = hit.transform.GetComponent<Rigidbody>();

                if (body != null)
                {
                    body.AddForce(transform.forward*500);
                }
            }
        }

    }
}
