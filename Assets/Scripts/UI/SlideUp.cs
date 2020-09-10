using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideUp : MonoBehaviour
{
    
    public float y;
    public int c=0;
    public void slide ()
    {
        
        
        StartCoroutine("slideup");
        
    }

    IEnumerator slideup()
    {


        Vector3 startpos= transform.position;
        float elapsedtime=0;
        while(elapsedtime<=0.4)
        {
            elapsedtime+=Time.deltaTime;
            transform.position=Vector3.Lerp(startpos, new Vector3(startpos.x, startpos.y+y*Mathf.Pow(-1,c), startpos.z), elapsedtime/0.4f);
        yield return null;
        }
        c++;
    }
}
