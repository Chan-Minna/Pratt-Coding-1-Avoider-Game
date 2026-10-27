using UnityEngine;

public class enemySpawnerScript : MonoBehaviour
{
    public GameObject enemyObject;
    public float spawnCooldown = 2;
    private float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnCooldown)
        {
            timer = 0;
            Object.Instantiate(enemyObject, transform.position, transform.rotation);
        }
    }

}
