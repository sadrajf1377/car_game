
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movement : MonoBehaviour
{
    Rigidbody rg;
    int value;
    [SerializeField] Transform _camera;
    float cameradistance,randomcarposdis1;
    
    [SerializeField] Transform[] randomcarposes;
    [SerializeField] GameObject[] randomcars;
    float speed=5;
    public static bool ghostmode;
 
    [SerializeField] GameObject cube;
   
    [SerializeField] gears currentgear;
    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
        rg.velocity = transform.forward *5;
        ghostmode = true;
        
    }
    void Start()
    {
       
        cameradistance = transform.position.z - _camera.position.z;
    

        new List<Transform>(randomcarposes).ForEach(delegate (Transform tr) { tr.localScale = new Vector3(tr.position.z - transform.position.z, 1, 1); });
         StartCoroutine(creatarandomcar());
        currentgear = gears.g1;
     
    }

    // Update is called once per frame
    void Update()
    {
        if (speed <=30)
        {
            speed += 0.5f * Time.deltaTime;
        }
        else if(speed>90)
        {
            speed =90;
        }
       

            rg.velocity =new Vector3( transform.forward.x,0,transform.forward.z) * (Input.GetKey(KeyCode.Space)?speed/2:speed)+new Vector3(0,rg.velocity.y,0);
        if(currentgear==gears.g1&&speed>20) { currentgear = gears.g2; }
        if (currentgear == gears.g2 && speed > 40) { currentgear = gears.g3; }
        if (currentgear == gears.g3 && speed > 60) { currentgear = gears.g4; }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, value*25, 0), Time.deltaTime * 1);
        _camera.position = new Vector3(_camera.position.x, _camera.position.y, transform.position.z-cameradistance);
      
        new List<Transform>(randomcarposes).ForEach(delegate (Transform tr) { tr.position = new Vector3(tr.position.x, tr.position.y,transform.position.z+tr.localScale.x ); });
       
    }
    public void setvalue(int k)
    {
        value = k;
        
    }
    IEnumerator creatarandomcar()
    {
        for (; ; )
        {
            int ind1, ind2;

            ind1 = UnityEngine.Random.Range(0, randomcars.Length);
            ind2 = UnityEngine.Random.Range(0, 4);
            
            GameObject g = Instantiate(randomcars[ind1], randomcarposes[ind2].position, randomcarposes[ind2].rotation);
            g.GetComponent<randomcarmovement>().enabled = true;
            g.GetComponent<Rigidbody>().isKinematic = false;

            float delaytime = UnityEngine.Random.Range(1f,1.5f);
            yield return new WaitForSeconds(delaytime);
            continue;
        }
       

    }
    void createrandomcars()
    {
        Instantiate(cube, transform.position+new Vector3(0,5,0), transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if (other.transform.parent.tag == ("aicar"))
        {
            this.enabled = false;
            other.transform.parent.GetComponent<randomcarmovement>().enabled = false;
            rg.velocity = Vector3.zero;
            other.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.tag = "Untagged";
            var force_dir = other.transform.position - transform.position;
            rg.AddForce(force_dir*speed*-600);
            other.GetComponent<Rigidbody>().AddForce(force_dir * speed*600);
            
            
            
            
        }
    }
    enum gears
    {R,g1,g2,g3,g4,g5 }


}
