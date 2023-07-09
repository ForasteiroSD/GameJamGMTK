using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverVertical : MonoBehaviour
{
    private Vector3 mousePositionOffset;
    private Vector3 mover;
    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }
    private void OnMouseDrag()
    {
        mover = transform.position;
        mover.y = GetMouseWorldPosition().y + mousePositionOffset.y;
        transform.position = mover;
    }
}