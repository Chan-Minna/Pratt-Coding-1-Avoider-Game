using UnityEngine;

public class randomSpawner : MonoBehaviour
{
    public GameObject spawnObject;
    private bool canSpawn;
    private BoxCollider2D spawnArea;
    public GameObject currentSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnArea = GetComponent<BoxCollider2D>();
        SpawnPrefab();
        canSpawn = false;

    }

    void Update()
    {
        if (canSpawn == true)
        {
            canSpawn = false;
            SpawnPrefab();
        }


    }

    public void SpawnPrefab()
    {
        Bounds bounds = spawnArea.bounds;
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        Vector2 randomPosition = new Vector2(randomX, randomY);

        currentSpawn = Object.Instantiate(spawnObject, randomPosition, transform.rotation);
        currentSpawn.GetComponent<cakeClick>().randomSpawnerReference = this;
    }

    public void OnPrefabDeactivated()
    {
        canSpawn = true;
    }
}
