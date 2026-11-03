using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class movementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public scoreUI scoreUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Treat"))
        {
            other.gameObject.SetActive(false);
            scoreUI.OnCakePickup();
        }

    }

    public void OnMove(InputValue input)
    {
        rb.linearVelocity = input.Get<Vector2>() * moveSpeed;
    }
}

