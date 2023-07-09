using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvancaPtero : MonoBehaviour
{
    [SerializeField] private float avancar;
    [SerializeField] private Porrete defende;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (defende.invulneravel)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("TomeiDano");
        }
    }
}
