using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carselected : MonoBehaviour
{
    float speed;
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-2, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
      //  speed = 0;
    }
}
