using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private const float _followSpeed = 0.05f;

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.GetComponent<PlayerInput>() != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _followSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
