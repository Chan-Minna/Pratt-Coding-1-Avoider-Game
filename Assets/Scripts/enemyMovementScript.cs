using UnityEngine;

public class enemyMovementScript : MonoBehaviour
{
    public float moveSpeed = 10;
    public float deadZone = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
