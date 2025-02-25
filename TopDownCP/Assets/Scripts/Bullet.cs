using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private float _bulletSpeed = 0.01f;

    private float _bulletLifetime = 5;

    private void Start()
    {
        Destroy(gameObject, _bulletLifetime);
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(_bulletSpeed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Enemy Bullet
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //Player Bullet
        else if (collision.gameObject.GetComponent<ShootingEnemy>() || collision.gameObject.GetComponent<Enemy>())
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
