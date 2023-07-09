using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mosossauro : MonoBehaviour
{
    [SerializeField] private float tamanhoPulo;
    [SerializeField] private Transform jogador;
    [SerializeField] private Porrete defende;
    private Vector3 lugar;
    private Boolean atacou;


    private void Start()
    {
        lugar = transform.position;
        atacou = false;
    }
    public void ataque()
    {
        lugar.y += tamanhoPulo;
        transform.position = lugar;
        atacou = true;
    }
    public void volta()
    {
        lugar.y -= tamanhoPulo;
        transform.position = lugar;
        atacou = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(((jogador.position.x - lugar.x)> -1)&&(!atacou))
        {
            ataque();
        }
        if(((jogador.position.x - lugar.x) > 1) && (atacou))
        {
            volta();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
}
