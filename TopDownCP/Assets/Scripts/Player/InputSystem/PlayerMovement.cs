using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rb;

    private InputAction _movement;

    private MainControlSystem _mainInputActions;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mainInputActions = new MainControlSystem();
        Bind();
    }

    private void Bind()
    {
        _movement = _mainInputActions.Game.Movement;
        _movement.Enable();
    }

    private void FixedUpdate()
    {
        Vector2 _movement2d = _movement.ReadValue<Vector2>().normalized;
        _rb.velocity = new Vector2(_movement2d.x, _movement2d.y) * _moveSpeed;
    }

    private void OnDestroy()
    {
        _movement.Disable();
    }
}
