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

    private const float _bulletSpeed = 0.1f;
    private const float _bulletLifetime = 5;

    virtual public void Start()
    {
        Destroy(gameObject, _bulletLifetime);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(_bulletSpeed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            Destroy(gameObject);
    }
}
