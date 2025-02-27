using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Vector3 _mousePos;
    private Camera _mainCam;
    private Rigidbody2D _rb;

    private const float _bulletSpeed = 5f;
    private const float _bulletLifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, _bulletLifeTime);
        GetDirection();
    }

    virtual public void GetDirection()
    {
        _mainCam = FindObjectOfType<Camera>();
        _rb = GetComponent<Rigidbody2D>();
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = _mousePos - transform.position;
        Vector3 rotation = transform.position - _mousePos;
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * _bulletSpeed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ShootingEnemy>() || collision.gameObject.GetComponent<Enemy>())
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
