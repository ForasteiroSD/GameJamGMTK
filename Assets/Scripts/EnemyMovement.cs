using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    [Header("Ground Detection")]
    private bool groundDetected;
    [SerializeField] Transform groundPos;
    [SerializeField] private float groundCheckSize;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Wall Detection")]
    private bool wallDetected;
    [SerializeField] Transform wallPos;
    [SerializeField] private float wallCheckSize;
    [SerializeField] private LayerMask whatIsWall;

    private int x = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    void Update()
    {
        groundDetected = Physics2D.Raycast(groundPos.position, -transform.up, groundCheckSize, whatIsGround);
        wallDetected = Physics2D.Raycast(wallPos.position, transform.right, wallCheckSize, whatIsWall);

        //Deteccion de Suelo
        if (!groundDetected)
        {
                speed = -speed;
                x = -x;
        }

        //Deteccion de Pared
        if (wallDetected)
        {
               speed = -speed;
               x = -x;
        }
        transform.localScale = new Vector3(x, 1, 1);
        rb.velocity = transform.right * speed;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundPos.position, new Vector2(groundPos.position.x, groundPos.position.y - groundCheckSize));
        Gizmos.DrawLine(wallPos.position, new Vector2(wallPos.position.x + wallCheckSize, wallPos.position.y));
    }
}
