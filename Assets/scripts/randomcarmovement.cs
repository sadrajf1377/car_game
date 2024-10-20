using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomcarmovement : MonoBehaviour
{
    float speed;
    [SerializeField] MeshRenderer[] bodyparts;
    float posy;
    [SerializeField] Transform checkpos;
    [SerializeField] LayerMask lyr;
    [SerializeField] WheelCollider whl;
    WheelHit hit;
    Dictionary<string, int> dict1;
    BoxCollider bxc,bxc1;
    RaycastHit rayhit;
    
    void Start()
    {
        
        speed = UnityEngine.Random.Range(1.5f, 5.7f);
     
        StartCoroutine(activategravity());
       bxc= GameObject.FindGameObjectWithTag("car").transform.GetChild(0).GetComponent<BoxCollider>();
        bxc1 = new List<Transform>(transform.GetComponentsInChildren<Transform>()).Find(x => x.GetComponent<BoxCollider>() != null).GetComponent<BoxCollider>();
        for(int k=0;k<transform.childCount;k++)
        {
            if(transform.GetChild(k).GetComponent<MeshRenderer>())
            {
                for(int i=0; i< transform.GetChild(k).GetComponent<MeshRenderer>().materials.Length;i++)
                {
                    try
                    {
                        transform.GetChild(k).GetComponent<MeshRenderer>().materials[i].shader = GameObject.FindGameObjectWithTag("car").transform.GetChild(0).
                             transform.GetChild(k).GetComponent<MeshRenderer>().materials[0].shader;
                    }
                    catch { //do notihng
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y,5);

    // Physics.IgnoreCollision(bxc1,bxc);
    }
    IEnumerator activategravity()
    {

        GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX;
        yield return new WaitUntil(() => Physics.Raycast(checkpos.position, -checkpos.up,out rayhit)&&rayhit.transform.gameObject.layer==5);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;

         
            
            yield return new WaitUntil(() => whl.GetGroundHit(out hit) && hit.collider.gameObject.layer == 5);
        GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionY| RigidbodyConstraints.FreezeRotationX;




    }
    void checkfordestroying()
    {
        
            if (transform.position.y != posy)
            {
                Destroy(gameObject);
                
            }
            posy = transform.position.y;
        
    }
    
    
}
