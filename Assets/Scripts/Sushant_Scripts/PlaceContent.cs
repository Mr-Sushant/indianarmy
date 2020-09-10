using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaceContent : MonoBehaviour
{

    public ARRaycastManager raycastManager;
    public GraphicRaycaster raycaster;
    public GameObject txt;
    public GameObject newTxt;
    public ARPlaneManager planeManager;
    public ARPointCloudManager pointCloudManager;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && !IsClickOverUI())
        {

            List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.mousePosition, hitPoints, TrackableType.Planes);

            if (hitPoints.Count > 0)
            {
                txt.SetActive(false);
                Pose pose = hitPoints[0].pose;
                transform.rotation = pose.rotation;
                transform.position = pose.position;
                VisualizePlanes(false);
                VisualizePoints(false);
                newTxt.SetActive(true);
            }
        }
    }

    bool IsClickOverUI()
    {
        //dont place content if pointer is over ui element
        PointerEventData data = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        raycaster.Raycast(data, results);
        return results.Count > 0;
    }

    void VisualizePlanes(bool active)
    {
        planeManager.enabled = active;
        foreach (ARPlane plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(active);
        }
    }

    void VisualizePoints(bool active)
    {
        pointCloudManager.enabled = active;
        foreach (ARPointCloud pointCLoud in pointCloudManager.trackables)
        {
            pointCLoud.gameObject.SetActive(active);
        }
    }
}
