using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Windows;

public class mouseMovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Camera mainCamera;
    private Vector2 mousePosition;
    private Vector2 playerPosition;
    private bool isDragging;
    private bool isHovering;
    public timerScript timerScriptReference;
    public scoreUI scoreUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D hover = Physics2D.OverlapPoint(mainCamera.ScreenToWorldPoint(mousePosition));

        if (hover != null)
        {
            //Debug.Log("Mouse is over: " + hover.gameObject.name);
            if (hover.gameObject == gameObject)
            {
                isHovering = true;
            }
        }
        else
        {
            isHovering = false;
        }

        if (isDragging && isHovering)
        {
            playerPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            rb.MovePosition(playerPosition);
        }
        TimeUp();

    }

    public void OnClick(InputValue input)
    {
        isDragging = input.isPressed;
    }

    public void OnCursorLocation(InputValue input)
    {
        mousePosition = input.Get<Vector2>();
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

    private float timer = 0;
    private void TimeUp()
    {
        timer += Time.deltaTime;
        if(timer >= timerScriptReference.startTime)
        {
            gameObject.SetActive(false);
        }
    }

}
