using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAtStart : MonoBehaviour
{
    public GameObject[] select;
    public AtSideMenuStart sideMenu;
    int nextPageSortOrder;
    int nextpage;
    int currentcanvas;
    float duration=1f;
    float endpos;


    void Start() {

        for(int i=0;i<select.Length;i++)
        {
            if(i==IndexSetter.index)
            {
                select[i].SetActive(true);
            
            } 
            else
            select[i].SetActive(false);
        }

        sideMenu.currentindex(IndexSetter.index+1);

    }

    public void disableRestCanvas(int index)
    {
        for(int i=0;i<select.Length;i++)
        {
            if(i!=index && i!=5)            
                {   select[i].SetActive(false);
                    IndexSetter.index=index;
                    
                }
        }
    }



    public void ChangeNext(int nextpageNumber, int currentcanvasNumber,float end)
    {

        nextpage=nextpageNumber;
        currentcanvas=currentcanvasNumber;
        endpos=end;
        

        int currentSortOrder = select[currentcanvas-1].GetComponent<Canvas>().sortingOrder;
        nextPageSortOrder = select[nextpage-1].GetComponent<Canvas>().sortingOrder;
        
        select[nextpage-1].SetActive(true);
        select[nextpage-1].GetComponent<Canvas>().sortingOrder=currentSortOrder-1;
    
        select[nextpage-1].transform.GetChild(0).gameObject.transform.position=select[currentcanvas-1].transform.GetChild(0).gameObject.transform.position;
        
        StartCoroutine("DoTransition");
        
        
    }

    


    IEnumerator DoTransition()
    {
        float elapsedtime=0;
        Vector3 startpos = select[currentcanvas-1].transform.GetChild(0).gameObject.transform.position;
        

        while(elapsedtime<=duration)
        {
            elapsedtime+=Time.deltaTime;
            select[currentcanvas-1].transform.GetChild(0).gameObject.transform.position=Vector3.Lerp(startpos, new Vector3(endpos, startpos.y, startpos.z), elapsedtime/duration);

            yield return null;
        }
            
            select[currentcanvas-1].SetActive(false);
            if(nextpage-1!=4)
            IndexSetter.index=nextpage-1;
            Next.c=0;
            select[nextpage-1].GetComponent<Canvas>().sortingOrder= nextPageSortOrder;
            select[currentcanvas-1].transform.GetChild(0).gameObject.transform.position=select[nextpage-1].transform.GetChild(0).gameObject.transform.position;

        
    }
}
