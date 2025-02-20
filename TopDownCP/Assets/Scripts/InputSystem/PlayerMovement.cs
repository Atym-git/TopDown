using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rb;

    private InputAction _mainInputActions;

    private Vector2 _movement = Vector2.zero;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mainInputActions = new();
        Bind();
        _mainInputActions.Enable();
    }

    private void Bind()
    {
        var movement = _mainInputActions.actionMap.FindAction("Movement");
        _mainInputActions.performed += OnMovement;
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        _movement = value.ReadValue<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_movement.x, _movement.y) * _moveSpeed;
    }
}
