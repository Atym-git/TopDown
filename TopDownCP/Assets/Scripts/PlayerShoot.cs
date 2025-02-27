using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private Object _bulletPrefab;
    [SerializeField] private Transform _bulletTransform;

    private MainControlSystem _mainInputActions;

    private Vector3 _mousePos;

    [SerializeField] private Camera _mainCam;
    private void Start()
    {
        LoadResources();
        _mainInputActions = new MainControlSystem();
        Bind();
    }

    private void Update()
    {
        ShootRotation();
    }

    private void ShootRotation()
    {
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 aimDirection = (_mousePos - transform.position).normalized;

        float rotZ = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    private void Bind()
    {
        _mainInputActions.Game.Shoot.performed += Shoot;
        _mainInputActions.Game.Shoot.Enable();
    }

    private void Shoot(InputAction.CallbackContext value)
    {
        Instantiate(_bulletPrefab, _bulletTransform.position, Quaternion.identity);
    }

    private void LoadResources()
    {
        _bulletPrefab = Resources.Load("Prefabs/PlayerBullet");
    }
}
