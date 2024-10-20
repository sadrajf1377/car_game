using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopthegame : MonoBehaviour
{
    // Start is called before the first frame update
    struct s
    {
        public int a { set; get; }
        public float c;
        
    }
    public  class infos
    {
        public static int k;
    }

    private void OnTriggerEnter(Collider other)
    {
        s s1= new s();
        s1.a = 4;
        
        if (other.transform.parent.tag == "aicar")
        {
            transform.parent.GetComponent<movement>().enabled = false;
            transform.parent.GetComponent<Rigidbody>().freezeRotation = false;
            other.transform.parent.GetComponent<randomcarmovement>().enabled = false;
            other.transform.parent.GetComponent<Rigidbody>().freezeRotation = false;
            print("crashed");
        }
    }
  
     

}
