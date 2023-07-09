using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAutoHorizontal : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject jogador;
    private Boolean jogadorBateu;
    private Vector2 movement;
    private void Start()
    {
        movement.y = 0;
        movement.x = 1;
        jogadorBateu = false;
    }
    private void FixedUpdate()
    {
        if (jogadorBateu)
        {
            rb.MovePosition(rb.position + movement * jogador.GetComponent<PlayerMovement>()._speed * Time.fixedDeltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            jogadorBateu = true;
        } 
    }
}
