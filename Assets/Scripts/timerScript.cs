using UnityEngine;
using TMPro;

public class timerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public int collectCount;
    
    private float elapsedTime;
    public float startTime;
    private float remainingTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = 60;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        remainingTime = Mathf.FloorToInt(startTime - elapsedTime);
        timerText.text = remainingTime.ToString();
        
    }

}
