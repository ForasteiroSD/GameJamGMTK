using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _tempoVariacaoVelocidade;
    [SerializeField] private float _quantidadeVariacaoVelocidade;
    [SerializeField] private GameObject player;
    private Rigidbody2D _rigidBody;
    private float _deltaTime;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        if(_speed < _maxSpeed)
            {
            if (_deltaTime > _tempoVariacaoVelocidade)
            {
                _speed = _speed + (Time.deltaTime * _quantidadeVariacaoVelocidade);
                _deltaTime = 0;
            }
        }
        _rigidBody.velocity = new Vector2(_speed, _rigidBody.velocity.y);
    }
}
