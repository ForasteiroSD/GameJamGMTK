using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _tempoVariacaoVelocidade;
    [SerializeField] private float _quantidadeVariacaoVelocidade;
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _layerCollider;
    private Rigidbody2D _rigidBody;
    private float _deltaTime;     // Tempo para variar a velocidade do personagem
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _deltaTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //_rigidBody.velocity = new Vector2(_speed, _rigidBody.velocity.y);
        _deltaTime += Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, _range, _layerCollider);
        if (hit.collider)
        {
            // Para o player 
            _speed = 0;
        }
        else
        {
            
            if (_speed < _maxSpeed)
            {
                if (_deltaTime > _tempoVariacaoVelocidade)
                {
                    _speed = _speed + (Time.deltaTime * _quantidadeVariacaoVelocidade);
                    _deltaTime = 0;
                }
            }
        }
        // Debug.Log(_speed);
        _rigidBody.velocity = new Vector2(_speed, _rigidBody.velocity.y);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * _range);
    }

}
