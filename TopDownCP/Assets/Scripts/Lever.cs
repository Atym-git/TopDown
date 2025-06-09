using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject breakingWall;

    [SerializeField] private KeyCode leverActivationButton;

    [SerializeField] private Animator leverAnimator;
 
    private bool _isInsideTrigger = false;

    private const string leverAnimation = "Lever";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerMovement>())
        {
            _isInsideTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.GetComponent<PlayerMovement>())
        {
            _isInsideTrigger = false;
        }
    }

    private void Update()
    {
        if (_isInsideTrigger && Input.GetKeyDown(leverActivationButton))
        {
            leverAnimator.SetTrigger(leverAnimation);
        }
    }

    public void LeverDown()
    {
        Destroy(breakingWall);
    }
}
