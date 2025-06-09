using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 _mousePos;
    private Camera _mainCam;
    private Rigidbody2D _rb;

    private const float _bulletSpeed = 6f;
    private const float _bulletLifetime = 5;

    [SerializeField] private int damage = 4;

    private Vector3 _direction;

    virtual public void Start()
    {
        Destroy(gameObject, _bulletLifetime);
        _direction = transform.parent.position - transform.parent.parent.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //transform.position += new Vector3(_bulletSpeed, 0, 0);
        _rb.velocity = new Vector2(_direction.x, _direction.y) * _bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }
            Destroy(gameObject);
    }
}
