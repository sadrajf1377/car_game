using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectionmenufunctions : MonoBehaviour
{
    [SerializeField] Transform menubar;
    [SerializeField] GameObject uppbutton, downbutton;
    [SerializeField] List<GameObject> cars;
    int count=0;
   

    public void scroll(string s)
    {
        //move the bar for 70 units
        //uppbutton.GetComponent<UnityEngine.UI.RawImage>().raycastTarget = menubar.localPosition.y+70 < 140;
       // downbutton.GetComponent<UnityEngine.UI.RawImage>().raycastTarget=menubar.localPosition.y-70 > 0;
        StartCoroutine(scrollienumrator(s));
        
    }
    IEnumerator scrollienumrator(string s)
    {
        switch (s)
        {
            case "up":
                {
                    count++;
                    cars.ForEach(delegate (GameObject g) { g.SetActive(cars.IndexOf(g) == count); });

                    for (int i = 0; i < 10; i++)
                    {
                        menubar.localPosition += new Vector3(0, 7, 0);
                        yield return new WaitForSeconds(0.025f);
                    }
                    
                }
                break;

            case "down":
                {
                    count--;
                    cars.ForEach(delegate (GameObject g) { g.SetActive(cars.IndexOf(g) == count); });
                    for (int i = 0; i < 10; i++)
                    {
                        menubar.localPosition -= new Vector3(0, 7, 0);
                        yield return new WaitForSeconds(0.025f);
                    }
                }
               
                break;

        }
    }
}
