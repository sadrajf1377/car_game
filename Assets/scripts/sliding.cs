using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliding : MonoBehaviour
{
    [SerializeField] Rigidbody rg;
    [SerializeField] float posy;
    [SerializeField] GameObject []images;
    [SerializeField]int ind;
    [SerializeField] GameObject frame;
    void Start()
    {
        
        //87.5-24.5
        print(frame.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            ind++;
            if(ind>4)
            {
                ind = 0;
            }
            StartCoroutine(MoveSlider("up"));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ind--;
            if (ind < 0)
            {
                ind = 4;
            }
            StartCoroutine(MoveSlider("down"));
        }

       
    }
    IEnumerator MoveSlider(string s)
    {
        switch (s)
        {
            case "up":
                {
                    print("up");
                    for (; ; )
                    {
                        rg.transform.localPosition += new Vector3(0, 0.1f, 0);
                        if(images[ind].transform.position.y>=frame.transform.position.y)
                        {
                            break;
                        }
                        yield return new WaitForSeconds(0.005f);
                        continue;
                    }
                   
                }
                break;
            case "down":
                {
                    print("down");
                    for (; ; )
                    {
                        rg.transform.localPosition -= new Vector3(0, 0.1f, 0);
                        if (images[ind].transform.position.y <= frame.transform.position.y)
                        {
                            break;
                        }
                        yield return new WaitForSeconds(0.005f);
                        continue;
                    }
                }
                
                break;

        }
       
        yield return null;

    }
}
