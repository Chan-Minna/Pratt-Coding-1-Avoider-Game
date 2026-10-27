using UnityEngine;

public class enemySpawnerScript : MonoBehaviour
{
    public GameObject enemyObject;
    public float spawnCooldown = 2;
    private float timer;
    public float minPosition;
    public float maxPosition;
    public float minEnemySpeed;
    public float maxEnemySpeed;

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
        GameObject enemy = Object.Instantiate(enemyObject, randomPosition, transform.rotation);

        float randomEnemySpeed = Random.Range(minEnemySpeed, maxEnemySpeed);
        enemyMovementScript enemyMovement = enemy.GetComponent<enemyMovementScript>();
        enemyMovement.moveSpeed = randomEnemySpeed;
    }
}
