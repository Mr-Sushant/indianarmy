using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SphereBehaviour : MonoBehaviour
{

    [SerializeField]
    Transform SectionInfo;
    [SerializeField]
    GameObject State;
    [SerializeField]
    GameObject sphere;

    [SerializeField]
    Material newMaterial, oldMaterial, newSphere,oldSphere;
    
    Vector3 desiredScale = Vector3.zero;


    void Update()
    {
        SectionInfo.localScale = Vector3.Lerp(SectionInfo.localScale,desiredScale,Time.deltaTime * 6f);
        
    }

    public void OpenInfo()
    {
        desiredScale = Vector3.one;

        State.GetComponent<MeshRenderer>().material = newMaterial;
            //sphere.GetComponent<MeshRenderer>().material = newSphere;
    }

    public void CloseInfo()
    {
        desiredScale = Vector3.zero;

        State.GetComponent<MeshRenderer>().material = oldMaterial;
            //sphere.GetComponent<MeshRenderer>().material = oldSphere;
    }
}
