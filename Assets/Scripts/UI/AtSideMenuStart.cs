using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AtSideMenuStart : MonoBehaviour
{
    public Vector3 endpos;
    public float duration;
    public GameObject sideMenu;
    public Color red;
    public Color original;
    public Text[] text;
    public ShowAtStart show = null;

    
    void origcolor(int index) //change others to orig color
    {
        for(int i=0;i<text.Length;i++)
        {
            if(i!=index)
            text[i].color=original;
        }
    }

    
    public void currentindex(int index) //get corresponding text in red color
    {
        switch(index)
        {
            case 2: text[0].color=red; origcolor(0); 
                    if(SceneManager.GetActiveScene().name=="AllInOne")
                    show.disableRestCanvas(2-1);
            break;

            case 3: text[1].color=red; origcolor(1);
                    if(SceneManager.GetActiveScene().name=="AllInOne")
                    show.disableRestCanvas(3-1);
            break;
            
            case 4: text[1].color=red; origcolor(1);
                    
            break;

            case 7: text[2].color=red; origcolor(2); 
                    if(SceneManager.GetActiveScene().name=="AllInOne")
                    show.disableRestCanvas(7-1);
            break;

            case 8: text[3].color=red; origcolor(3); 
                    if(SceneManager.GetActiveScene().name=="AllInOne")
                    show.disableRestCanvas(8-1);
            break;

            case 9: origcolor(4);
                    if(SceneManager.GetActiveScene().name=="AllInOne")
                    show.disableRestCanvas(9-1); 
                    break;


        }
    }

    public void StartSlide(int index)
    {
        currentindex(index);
        StartCoroutine("slide");
    }


    public IEnumerator slide()
    {
        Vector3 startpos=transform.position;
        endpos.y=transform.position.y;
        endpos.x=transform.parent.position.x;
        float elapsedtime=0;
        while(elapsedtime<=duration)
        {
            elapsedtime+=Time.deltaTime;
            transform.position=Vector3.Lerp(startpos, endpos, elapsedtime/duration);

        yield return null;
        }
    }   
}
