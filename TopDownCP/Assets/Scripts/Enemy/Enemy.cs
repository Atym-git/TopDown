using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _followSpeed = 0.05f;

    [SerializeField] private int damage = 3;

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.GetComponent<PlayerInput>() != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, _followSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            Destroy(gameObject);
            playerHealth.TakeDamage(damage);
        }
    }
}
