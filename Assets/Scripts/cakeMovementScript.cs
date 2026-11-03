using UnityEngine;

public class cakeMovementScript : MonoBehaviour
{
    public float moveSpeed = 10;
    public int collectCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
        collectCount += 1;
        
    }
}
