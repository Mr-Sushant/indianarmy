using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slideMedals : MonoBehaviour
{
    int multiplier;
    public int children;
    int index=0;
    public GameObject left;
    public GameObject right;
    public SlideUp[] slide;


    void Start()
    {
        left.SetActive(false);
    }
    public void multiply(int m)
    {
        multiplier=m;
        slideMovement();
        
    }
    void slideMovement()
    {

                if(slide[index].c%2!=0)
                {
                    slide[index].slide();
                }



                if(multiplier==1 && index<children-1)
                {
                    Camera.main.transform.position=new Vector3(Camera.main.transform.position.x+multiplier*5.015f,Camera.main.transform.position.y,Camera.main.transform.position.z);
                    index+= multiplier;
            
                }
                else if (multiplier==-1 && index>0)
                {
                    Camera.main.transform.position=new Vector3(Camera.main.transform.position.x+multiplier*5.015f,Camera.main.transform.position.y,Camera.main.transform.position.z);
                    index+= multiplier;
            
                }

                

                if(index==children-1)
                    right.SetActive(false);
                else if(index==0)
                    left.SetActive(false);
                else
                {
                    left.SetActive(true);
                    right.SetActive(true);
                }
                
                
    }
}
