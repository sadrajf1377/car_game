using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class createordestroy : MonoBehaviour
{
    GameObject  bridgeprefab;
    [SerializeField] creatanddestroy Createanddestroy;
    [SerializeField] Transform creatpos;
    void Awake()
    {
      bridgeprefab= Array.ConvertAll(Resources.LoadAll("bridge",typeof(GameObject)),asset => (GameObject) asset)[0];
    }

    enum creatanddestroy
    {
        create,
        destroy
    }
    private void OnTriggerEnter(Collider other)
    {
        try
        {
            if (other.transform.parent.tag == ("car") && other.GetType() == typeof(BoxCollider) && !other.isTrigger)
            {
                switch (Createanddestroy)
                {
                    case creatanddestroy.create:
                        {
                            print("entered");
                            Instantiate(bridgeprefab, creatpos.position, creatpos.rotation);

                        }
                        break;
                    case creatanddestroy.destroy:
                        {
                            print("exited");
                            for (int c = 0; c < transform.parent.childCount; c++)
                            {
                                transform.parent.GetChild(c).gameObject.SetActive(false);
                            }
                            Destroy(transform.parent.gameObject);
                        }
                        break;
                }

            }
        }
        catch { }
    }


}
