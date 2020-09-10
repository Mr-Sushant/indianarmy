using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlacePortal : MonoBehaviour
{

    private GameObject spawnedObject;

    [SerializeField]
    public GameObject spwanedModel;

    private void Awake()
    {
        Renderer[] rs = spwanedModel.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;
    }

    private void Update()
    {

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            spawnedObject = Instantiate(spwanedModel, spwanedModel.transform.position, spwanedModel.transform.rotation);

            Renderer[] rs = spawnedObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rs)
                r.enabled = true;

            Destroy(spwanedModel);
           
        }
    }

    
}
