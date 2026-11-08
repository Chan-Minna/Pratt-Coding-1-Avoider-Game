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
    private bool isHovering;
    private bool isHoveringCake;
    public timerScript timerScriptReference;
    public scoreUI scoreUI;
    private float baseJumpForce = 25;
    private float jumpReducer = 0.9f;
    private float cakeReducer = 5.0f;
    private int cakeCount = 0;

    public randomSpawner randomSpawnerReference;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D hover = Physics2D.OverlapPoint(mainCamera.ScreenToWorldPoint(mousePosition));
        Collider2D cakeHover = Physics2D.OverlapPoint(mainCamera.ScreenToWorldPoint(mousePosition), LayerMask.GetMask("Treat"));
        if (hover != null)
        {
            //Debug.Log("Mouse is over: " + hover.gameObject.name);
            if (hover.gameObject == gameObject)
            {
                isHovering = true;
            }
            else
            {
                isHovering = false;
            }
        }
        else
        {
            isHovering = false;
        }

        if(cakeHover != null)
        {
            if (randomSpawnerReference.currentSpawn != null)
            {
                if (cakeHover.gameObject == randomSpawnerReference.currentSpawn)
                {
                    isHoveringCake = true;
                }
                else
                {
                    isHoveringCake = false;
                }
            }
        }
        else
        {
            isHoveringCake = false;
        }

        TimeUp();
    }

    public AudioClip jumpSound;
    public void OnClick(InputValue input)
    {
        if (input.isPressed && isHovering)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            AudioSource.PlayClipAtPoint(jumpSound, transform.position, 5);
            float weightCoefficient = Mathf.Floor(cakeCount / cakeReducer);
            float jumpForce = baseJumpForce * Mathf.Pow(jumpReducer,weightCoefficient);
            Debug.Log(jumpForce);

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(input.isPressed && isHoveringCake)
        {
            //Debug.Log("clicked");
            scoreUI.OnCakePickup();
            randomSpawnerReference.currentSpawn.GetComponent<cakeClick>().DeactivateCake();
            cakeCount++;

        }
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
