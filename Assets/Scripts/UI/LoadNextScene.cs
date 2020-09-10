using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public string sceneName;
    bool processing=false;
    public int loadcanvasIndex;


    
    public void LoadNext()
    {
        
            IndexSetter.index=loadcanvasIndex-1;
            SceneManager.LoadScene(sceneName);
            processing=false;
        
    }

    void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.Escape) && !processing && SceneManager.GetActiveScene().name!="AllInOne")
            {
                sceneName="AllInOne";
                processing=true;
                LoadNext();
            }
    }
}
