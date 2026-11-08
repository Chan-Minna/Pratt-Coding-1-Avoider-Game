using UnityEngine;

public class cakeClick : MonoBehaviour
{
    public randomSpawner randomSpawnerReference;
    public AudioClip clickSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void DeactivateCake()
    {
        AudioSource.PlayClipAtPoint(clickSound, transform.position, 15);
        gameObject.SetActive(false);
        randomSpawnerReference.OnPrefabDeactivated();
    }
}
