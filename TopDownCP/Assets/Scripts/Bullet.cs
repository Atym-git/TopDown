using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private float _bulletSpeed = 2;

    private float _bulletLifetime;

    private void Start()
    {
        transform.position += new Vector3(_bulletSpeed, 0, 0);
        Destroy(gameObject, _bulletLifetime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<InputAction>() != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
