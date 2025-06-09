using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThroughScenes : MonoBehaviour
{
    private const int gameScene = 0;

    private void OnTriggerEnter2D(Collider2D collision) // Win Game
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

}
