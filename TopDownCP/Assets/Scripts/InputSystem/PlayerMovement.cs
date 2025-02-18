using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Transform _playerTransform;
    private Rigidbody2D _rb;

    private Vector2 _movement = Vector2.zero;
    private void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        _movement = value.ReadValue<Vector2>().normalized;
        //_playerTransform.position += new Vector3(inputMovement.x, 0, inputMovement.y) * _moveSpeed;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_movement.x, _movement.y) * _moveSpeed;
    }
}
