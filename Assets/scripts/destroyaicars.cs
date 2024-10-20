using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyaicars : MonoBehaviour
{
    public string objectsname;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.CompareTag(objectsname))
        {
            //  print($"destroyed {other.transform.parent.name}");
            for(int c=0;c<other.transform.parent.childCount;c++)
            {
                other.transform.parent.GetChild(c).gameObject.SetActive(false);
            }
            Destroy(other.transform.parent.gameObject);
        }
    }
}
