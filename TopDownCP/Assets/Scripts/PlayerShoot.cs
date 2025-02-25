using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private Object _bulletPrefab;

    private MainControlSystem _mainInputActions;
    private void Start()
    {
        LoadResources();
        _mainInputActions = new MainControlSystem();
        Bind();
    }

    private void Bind()
    {
        _mainInputActions.Game.Shoot.performed += Shoot;
        _mainInputActions.Game.Shoot.Enable();
    }

    private void Shoot(InputAction.CallbackContext value)
    {
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        Instantiate(_bulletPrefab, worldPosition, new Quaternion());
    }

    private void LoadResources()
    {
        _bulletPrefab = Resources.Load("Prefabs/Bullet");
    }
}
