using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPlacement : MonoBehaviour
{
    private void Update()
    {
       /* if (!PlaceContent.isActive)
        {
            return;
        }
        else
        {*/
            Rotate();
            PinchToZoom();
            MoveUpDown();
        
    }
    public void Rotate()
    {
        Touch touch;
        touch = Input.GetTouch(0);

        if (Input.touchCount == 1 && touch.phase == TouchPhase.Moved)
        {
            transform.Rotate(Vector3.up * -10f * Time.deltaTime * touch.deltaPosition.x, Space.Self);
        }
    }

    public void MoveUpDown()
    {
        Touch touch;
        touch = Input.GetTouch(0);
        if (Input.touchCount == 1 && touch.phase == TouchPhase.Moved)
        {
            Vector3 position = Vector3.up * 0.02f * Time.deltaTime * touch.deltaPosition.y;
            transform.Translate(position, Space.Self);
        }
    }

    public void PinchToZoom()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = touchDeltaMag - prevTouchDeltaMag;

            float pinchAmount = deltaMagnitudeDiff * 0.02f * Time.deltaTime;

            transform.localScale += new Vector3(pinchAmount, pinchAmount, pinchAmount);
        }
    }
}
