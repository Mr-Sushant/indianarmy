using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InfoBehaviour : MonoBehaviour
{

    [SerializeField]
    Transform SectionInfo;
    [SerializeField]
    GameObject State;

    [SerializeField]
    Material newMaterial, oldMaterial;
    [SerializeField]
    GameObject maha;
    Vector3 desiredScale = Vector3.zero;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SectionInfo.localScale = Vector3.Lerp(SectionInfo.localScale, desiredScale, Time.deltaTime * 6f);
       // FlagPrefab.localScale = Vector3.Lerp(FlagPrefab.localScale, flagScale, Time.deltaTime * 6f);
    }

    public void OpenInfo()
    {
        if (gameObject.name != "Plane")
        {
            State.GetComponent<MeshRenderer>().material = newMaterial;
            desiredScale = Vector3.one;
        }
        else
        {
            maha.GetComponent<MeshRenderer>().material = newMaterial;
            desiredScale = Vector3.one;
        }
       
    }

    public void CloseInfo()
    {
        if (gameObject.name != "Plane")
        {
            State.GetComponent<MeshRenderer>().material = oldMaterial;
            desiredScale = Vector3.zero;
        }

        else
        {
            maha.GetComponent<MeshRenderer>().material = oldMaterial;
            desiredScale = Vector3.zero;
        }

    }
}
