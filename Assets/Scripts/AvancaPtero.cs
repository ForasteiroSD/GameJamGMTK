using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvancaPtero : MonoBehaviour
{
    [SerializeField] private float avancar;
    private Vector3 mover;
    private void Start()
    {
        mover = transform.position;
    }
    private void FixedUpdate()
    {
        mover.x += -avancar;
        transform.position = mover;
    }
}
