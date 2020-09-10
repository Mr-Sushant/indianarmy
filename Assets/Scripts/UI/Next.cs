using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public int nextpage;
    public int currentCanvas;
    public static int c=0;
    bool esc;
    public ShowAtStart show;
    
    public float endposY;
    public void transition()
    {
            show.ChangeNext(nextpage, currentCanvas, endposY);
            
            
    }

    void FixedUpdate() 
    {
        
        if( Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().name=="AllInOne")
            {
                if(c==0)
                {
                    c+=1;
                    
                    change();
                }
            }
        }


    void change()
    {
            int index2=1;
            switch(IndexSetter.index)
                {
                    case 1: Application.Quit(); //select page
                    break;

                    case 2: index2=1;  //army 
                    break;

                    case 3: index2=2; //locatelist
                    break;

                    case 6:
                    case 7:
                    case 8: index2=1;
                    break;
                }
                print(index2+" "+ IndexSetter.index);
                show.ChangeNext(index2+1, IndexSetter.index+1 , 2800);

        
    }
}
