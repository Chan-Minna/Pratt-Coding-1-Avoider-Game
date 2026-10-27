using UnityEngine;

public class enemySpawnerScript : MonoBehaviour
{
    public GameObject enemyObject;
    public float spawnCooldown = 2;
    private float timer;
    public float minPosition;
    public float maxPosition;

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
            spawnEnemy();
        }
    }

    private void spawnEnemy()
    {
        Vector3 randomPosition = transform.position;
        randomPosition.y = Random.Range(minPosition, maxPosition);
        Object.Instantiate(enemyObject, randomPosition, transform.rotation);
    }
}
