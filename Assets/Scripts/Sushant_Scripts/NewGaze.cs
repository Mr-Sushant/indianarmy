using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewGaze : MonoBehaviour
{
    List<SphereBehaviour> infos = new List<SphereBehaviour>();

    private void Start()
    {
        infos = FindObjectsOfType<SphereBehaviour>().ToList();

    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("hasInfo"))
            {
                OpenInfo(go.GetComponent<SphereBehaviour>());
            }
        }
        else
            CloseAll();
    }

    void OpenInfo(SphereBehaviour desiredInfo)
    {
        foreach (SphereBehaviour info in infos)
        {
            if (info == desiredInfo)
            {
                info.OpenInfo();
            }
            else
                info.CloseInfo();
        }
    }

    void CloseAll()
    {
        foreach (SphereBehaviour info in infos)
            info.CloseInfo();
    }
}
