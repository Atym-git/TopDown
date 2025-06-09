using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 10;

    [SerializeField] private TextMeshProUGUI currHealthTMP;

    private void Start()
    {
        ShowHealth();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        ShowHealth();
        IsDead();
    }

    private void IsDead()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void ShowHealth()
    {
        currHealthTMP.text = health.ToString();
    }
}
