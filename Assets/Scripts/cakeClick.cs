using UnityEngine;

public class cakeClick : MonoBehaviour
{
    public randomSpawner randomSpawnerReference;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("cake click");
        gameObject.SetActive(false);

        randomSpawnerReference.OnPrefabDeactivated();
    }
}
