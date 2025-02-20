using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.GetComponent<PlayerInput>() != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.05f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
