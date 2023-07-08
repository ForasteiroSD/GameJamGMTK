using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverHorizontal : MonoBehaviour
{
    private Vector3 mousePositionOffset;
    private Vector3 mover;
    private void Start()
    {
        mover = transform.position;
    }
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
        mover.x = GetMouseWorldPosition().x + mousePositionOffset.x;
        transform.position = mover;
    }
}
