using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMarkers : MonoBehaviour
{
    
    void Update()
    {
        gameObject.transform.Rotate(0, -0.7f, 0, Space.World);
    }
}
