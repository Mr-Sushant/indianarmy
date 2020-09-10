using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndZoom : MonoBehaviour
{
    
    
    float dist=0;
    float rate=70f;
    float final,var=0;
    // Update is called once per frame
    void FixedUpdate()
    {

        
            if(Input.touchCount>1){ 
                dist=var;
                var=Vector3.Distance(Input.GetTouch(0).position,Input.GetTouch(1).position);
                
                
                

                    if(dist<var && dist!=0){
                    final=rate*Time.deltaTime+ transform.localScale.x;
                    }
                    else  final=-rate*Time.deltaTime+ transform.localScale.x;
                

                    if(final>40)
                    final=40;
                    else if(final<20)
                    final=20;
                    transform.localScale=new Vector3(final, final, final);
                
            }
            else if(Input.touchCount>0) //rotation
        {
            
        
            transform.Rotate( new Vector3(0, -Input.GetTouch(0).deltaPosition.x, 0), Space.World);}

            else {gameObject.transform.Rotate(0,-0.3f,0, Space.World); dist=0; }
        
        

        
    }
}
